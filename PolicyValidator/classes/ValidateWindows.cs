using System;
using System.Runtime.InteropServices;
using System.Reflection;
using CETYPE;
using log4net;
using NextLabs.CSCInvoke;
using CEApplication = CETYPE.CEApplication;
using CEResource = CETYPE.CEResource;
using CEUser = CETYPE.CEUser;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Specialized;


namespace PolicyValidator
{
    class ValidateWindows : IValidate
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IntPtr _connectionHandle = IntPtr.Zero;
        public string ApplicationName { get; set; }
        public string Sid { get; set; }
        public string Username { get; set; }
        public string PdpIpAddress { get; set; }
        public float TimeoutS { get; set; }
        public string ConnectionResult { get; private set; }


        public bool ConnectToPC(string applicationName, string sid, string username, string pdpIpAddress, int port, float timeoutS)
        {
            ApplicationName = applicationName;
            Sid = sid;
            Username = username;
            PdpIpAddress = pdpIpAddress;
            TimeoutS = timeoutS;

            Log.Debug("Attempting to connect to PC.");

            if (_connectionHandle == IntPtr.Zero)
            {
                Log.Debug("Connection handle = IntPtr.Zero.");

                var app = new CEApplication(null, ApplicationName, null);
                var user = new CEUser(Username, Sid);

                Log.Debug("Connection Params : ");
                Log.Debug("Application Name  : " + ApplicationName);
                Log.Debug("Windows SID       : " + Sid);
                Log.Debug("Username          : " + Username);
                Log.Debug("PC IP Address     : " + PdpIpAddress);
                Log.Debug("Timeout           : " + TimeoutS);

                CEResult_t result = CESDKAPI.CECONN_Initialize(app, user, PdpIpAddress, out _connectionHandle, (int)(timeoutS * 1000));

                ConnectionResult = result.ToString();
                Log.Debug("PC response : " + result.ToString());

                if (result != CEResult_t.CE_RESULT_SUCCESS)
                {
                    Log.Error("Could not connect to PC.");
                    return false;
                }

                Log.Info("Connected to PC.");
            }
            else
            {
                Console.WriteLine("Connection handle != IntPtr.Zero. Already connected to PC?");
            }
            return true;
        }


        public bool DisconnectFromPC()
        {
            Log.Debug("Attempting to disconnect to PC.");
            if (_connectionHandle == IntPtr.Zero)
            {
                Log.Info("Not connected to PC.");
                return true;
            }

            CEResult_t result = CESDKAPI.CECONN_Close(_connectionHandle, 10000);

            if (result != CEResult_t.CE_RESULT_SUCCESS)
            {
                Log.Warn("Could not disconnect from PC.");
                return false;
            }
            _connectionHandle = IntPtr.Zero;
            Log.Info("Disconnected from PC.");
            return true;
        }



        public bool Evaluate(Requests[] req, string pql, bool ignoreBuiltInPolicies, out EnforcementResult[] enforcement, int timeout)
        {
            Log.Info("ValidateWindows Evaluate() received " + req.Count() + " requests");
            Dictionary<Requests, int> dict = new Dictionary<Requests, int>();
            enforcement = new EnforcementResult[req.Length];
            for (int z = 0; z < req.Count(); z++)
            {
                dict[req[z]] = z;
            }

            var dictionary = req.GroupBy(x => x.IpAddress).ToDictionary(v => v, v => v.ToArray());

            foreach (var entry in dictionary.Values)
            {
                String individualIpAddress = entry[0].IpAddress;
                EnforcementResult[] innerenforcement;
                bool res = InnerEvaluate(entry, pql, ignoreBuiltInPolicies, individualIpAddress, out innerenforcement, timeout);
                if (res == true)
                {
                    for (int y = 0; y < entry.Count(); y++)
                    {
                        if (dict.ContainsKey(entry[y]))
                        {
                            enforcement[dict[entry[y]]] = innerenforcement[y];
                        }
                    }
                }
                else
                {
                    Log.Debug("Evaluation failed for IPAddress: " + individualIpAddress);
                    return false;
                }
            }
            return true;
        }



        public bool InnerEvaluate(Requests[] req, string pql, bool ignoreBuiltInPolicies, string ipAddress, out EnforcementResult[] enforcement, int timeout)
        {
            CERequest[] ceRequests = new CERequest[req.Length];

            for (int i = 0; i < req.Length; i++)
            {
                ceRequests[i] = PrepareRequest(req[i]);
            }

            //PQL input is ignored. Currently passing it as an IntPtr.Zero for the CSCINVOKE_CEEVALUATE_CheckResourcesEx Call. 
            //If PQL support is to be enabled, implement the logic to convert the input string to an appropriate IntPtr.
            IntPtr ipPQL = IntPtr.Zero;

            uint ipNumber = Util.IpAddressToIpNumber(ipAddress);
            int sizeEnforcement = Marshal.SizeOf(new CEEnforcement_t());
            int iSizeCEString = Marshal.SizeOf(new CEString());
            IntPtr ipCERequest = IntPtr.Zero;
            IntPtr ipEnforcements = IntPtr.Zero;
            enforcement = new EnforcementResult[ceRequests.Length];
            ipCERequest = Marshal.AllocCoTaskMem(Marshal.SizeOf(ceRequests[0]) * ceRequests.Length);
            Log.Debug("Number of requests: " + ceRequests.Length);
            for (int i = 0; i < ceRequests.Length; i++)
            {
                IntPtr temp = new IntPtr(ipCERequest.ToInt32() + i * Marshal.SizeOf(new CERequest()));
                Marshal.StructureToPtr(ceRequests[i], temp, false);
            }

            ipEnforcements = Marshal.AllocCoTaskMem(sizeEnforcement * ceRequests.Length);
            CEEnforcement_t[] ceenforcements = new CEEnforcement_t[ceRequests.Length];

            for (int i = 0; i < ceRequests.Length; i++)
            {
                IntPtr ipobligation = Marshal.AllocCoTaskMem(Marshal.SizeOf(ipNumber));
                ceenforcements[i] = new CEEnforcement_t();
                ceenforcements[i].result = 0;
                ceenforcements[i].obligation = ipobligation;
                IntPtr temp = new IntPtr(ipEnforcements.ToInt32() + sizeEnforcement * i);
                Marshal.StructureToPtr(ceenforcements[i], temp, false);
            }

            Thread.BeginThreadAffinity();
            var result = NextLabs.CSCInvoke.CESDKAPI_Signature.CSCINVOKE_CEEVALUATE_CheckResourcesEx(_connectionHandle, ipCERequest, ceRequests.Length, ipPQL, ignoreBuiltInPolicies, ipNumber, ipEnforcements, timeout * 1000);
            Thread.EndThreadAffinity();
            Log.Debug("Result: " + result);
            if (result == CETYPE.CEResult_t.CE_RESULT_SUCCESS)
            {
                for (int i = 0; i < ceRequests.Length; i++)
                {
                    enforcement[i] = new EnforcementResult();
                    CEEnforcement_t ceenforcement = new CEEnforcement_t();
                    IntPtr temp = new IntPtr(ipEnforcements.ToInt32() + sizeEnforcement * i);
                    Marshal.PtrToStructure(temp, ceenforcement);
                    if (ceenforcement.result == 0)
                    {
                        enforcement[i].response = Decision.Deny;
                    }
                    else if (ceenforcement.result == 1)
                    {
                        enforcement[i].response = Decision.Allow;
                    }
                    else
                    {
                        enforcement[i].response = Decision.Error;
                    }

                    Log.Debug("Enforcement Response " + i + " : " + enforcement[i].response);
                    CEAttributes attrs = new CEAttributes();

                    if (ceenforcement.obligation != IntPtr.Zero)
                    {
                        Marshal.PtrToStructure(ceenforcement.obligation, attrs);
                        Attribute[] ceAttribute = new Attribute[attrs.count];
                        for (int j = 0; j < attrs.count; j++)
                        {
                            CEAttribute attr = new CEAttribute();
                            IntPtr ipObAttr = new IntPtr(attrs.attrs.ToInt32() + Marshal.SizeOf(attr) * j);
                            Marshal.PtrToStructure(ipObAttr, attr);
                            if (attr != null)
                            {
                                if (attr.key != IntPtr.Zero && attr.value != IntPtr.Zero)
                                {
                                    CEString ceObKey = new CEString();
                                    Marshal.PtrToStructure(attr.key, ceObKey);
                                    CEString ceObValue = new CEString();
                                    Marshal.PtrToStructure(attr.value, ceObValue);
                                    if (ceObKey != null && ceObValue != null)
                                    {
                                        Attribute attr1 = new Attribute(ceObKey.buf, ceObValue.buf);
                                        ceAttribute[j] = attr1;
                                    }
                                }
                            }
                        }
                        enforcement[i].attributes = ceAttribute;
                    }
                    if (attrs.count == 0)
                    {
                        enforcement[i].attributes = null;
                    }
                }

                try
                {
                    if (ipPQL != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(ipPQL);
                    }
                    if (ipCERequest != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(ipCERequest);
                    }
                    if (ipEnforcements != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(ipEnforcements);
                    }
                }
                catch (Exception ex)
                {
                    Log.Debug("bear free memory Exception:" + ex.Message);
                }
                return true;
            }
            else
            {
                try
                {
                    if (ipPQL != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(ipPQL);
                    }
                    if (ipCERequest != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(ipCERequest);
                    }
                    if (ipEnforcements != IntPtr.Zero)
                    {
                        for (int i = 0; i < ceRequests.Length; i++)
                        {
                            IntPtr temp = new IntPtr(ipEnforcements.ToInt32() + sizeEnforcement * i);
                            Marshal.FreeCoTaskMem(temp);
                        }
                        Marshal.FreeCoTaskMem(ipEnforcements);
                    }
                }
                catch (Exception ex)
                {
                    Log.Debug("Free memory Exception:" + ex.Message);
                }
                return false;
            }
        }


        private NextLabs.CSCInvoke.CERequest PrepareRequest(Requests req)
        {
            //Outlook Policies not supported currently. (Recipients section below is commented. Need to debug further and convert it into correct IntPtr, if support for Outlook is to be enabled.)
            //(Won't work directly - Use as reference only) 
            var app = new CETYPE.CEApplication(req.AppName, req.AppName, null);
            var user = new CETYPE.CEUser(req.Username, req.Sid);
            const CENoiseLevel_t noiseLevel = CENoiseLevel_t.CE_NOISE_LEVEL_USER_ACTION;

            int sizeEnforcement = Marshal.SizeOf(new CEEnforcement_t());
            int iSizeCEString = Marshal.SizeOf(new CEString());
            CERequest ceRequest = new CERequest();

            #region operation
            IntPtr ipOperation = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString csOperation = getCEString(req.Operation);
            Marshal.StructureToPtr(csOperation, ipOperation, false);
            ceRequest.operation = ipOperation;
            #endregion

            #region source
            NextLabs.CSCInvoke.CEResource cesReource = new NextLabs.CSCInvoke.CEResource();
            IntPtr ipsourceName = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString cssourceName = getCEString(req.SourceName);
            Marshal.StructureToPtr(cssourceName, ipsourceName, false);
            cesReource.resourceName = ipsourceName;

            IntPtr ipsourceType = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString cssourceType = getCEString(req.SourceType);
            Marshal.StructureToPtr(cssourceType, ipsourceType, false);
            cesReource.resourceType = ipsourceType;

            IntPtr ipsource = Marshal.AllocCoTaskMem(Marshal.SizeOf(cesReource));
            Marshal.StructureToPtr(cesReource, ipsource, false);
            ceRequest.source = ipsource;
            #endregion

            #region sourceAttributes
            CEAttributes sourceAttrs = new CEAttributes();
            CEAttribute[] sourceArryAttrs = new CEAttribute[req.SourceAttributes.Count / 2];
            for (int j = 0; j < sourceArryAttrs.Length; j++)
            {
                sourceArryAttrs[j] = new CEAttribute();
                CEString attrKey = getCEString(req.SourceAttributes[j * 2]);
                IntPtr ipAttrKey = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrKey, ipAttrKey, false);
                sourceArryAttrs[j].key = ipAttrKey;

                CEString attrVal = getCEString(req.SourceAttributes[j * 2 + 1]);
                IntPtr ipAttrValue = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrVal, ipAttrValue, false);
                sourceArryAttrs[j].value = ipAttrValue;
            }
            int iSizeCEAttribute = Marshal.SizeOf(sourceArryAttrs[0]);
            IntPtr ipSourceArryAttrs = Marshal.AllocCoTaskMem(iSizeCEAttribute * sourceArryAttrs.Length);
            for (int k = 0; k < sourceArryAttrs.Length; k++)
            {
                IntPtr temp;
                temp = new IntPtr(ipSourceArryAttrs.ToInt32() + k * iSizeCEAttribute);
                Marshal.StructureToPtr(sourceArryAttrs[k], temp, false);
            }

            sourceAttrs.count = sourceArryAttrs.Length;
            sourceAttrs.attrs = ipSourceArryAttrs;
            int iSizeResourceAttrs = Marshal.SizeOf(sourceAttrs);
            IntPtr ipSourceAttrs = Marshal.AllocCoTaskMem(iSizeResourceAttrs);
            Marshal.StructureToPtr(sourceAttrs, ipSourceAttrs, false);
            ceRequest.sourceAttributes = ipSourceAttrs;
            #endregion

            #region target
            NextLabs.CSCInvoke.CEResource ceTarget = new NextLabs.CSCInvoke.CEResource();
            IntPtr ipTargetName = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceTagName = getCEString(req.TargetName);
            Marshal.StructureToPtr(ceTagName, ipTargetName, false);
            ceTarget.resourceName = ipTargetName;

            IntPtr ipTargetType = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceTagType = getCEString(req.TargetType);
            Marshal.StructureToPtr(ceTagType, ipTargetType, false);
            ceTarget.resourceType = ipTargetType;

            IntPtr iptarget = Marshal.AllocCoTaskMem(Marshal.SizeOf(ceTarget));
            Marshal.StructureToPtr(ceTarget, iptarget, false);
            ceRequest.target = iptarget;
            #endregion

            #region targetAttributes
            CEAttributes targetAttrs = new CEAttributes();
            CEAttribute[] targetArryAttrs = new CEAttribute[req.TargetAttributes.Count / 2];
            for (int j = 0; j < targetArryAttrs.Length; j++)
            {
                targetArryAttrs[j] = new CEAttribute();
                CEString attrKey = getCEString(req.TargetAttributes[j * 2]);
                IntPtr ipAttrKey = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrKey, ipAttrKey, false);
                targetArryAttrs[j].key = ipAttrKey;

                CEString attrVal = getCEString(req.TargetAttributes[j * 2 + 1]);
                IntPtr ipAttrValue = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrVal, ipAttrValue, false);
                targetArryAttrs[j].value = ipAttrValue;
            }
            IntPtr ipTargetArryAttrs = Marshal.AllocCoTaskMem(iSizeCEAttribute * targetArryAttrs.Length);
            for (int k = 0; k < targetArryAttrs.Length; k++)
            {
                IntPtr temp;
                temp = new IntPtr(ipTargetArryAttrs.ToInt32() + k * iSizeCEAttribute);
                Marshal.StructureToPtr(targetArryAttrs[k], temp, false);
            }

            targetAttrs.count = targetArryAttrs.Length;
            targetAttrs.attrs = ipTargetArryAttrs;
            IntPtr ipTargetAttrs = Marshal.AllocCoTaskMem(iSizeResourceAttrs);
            Marshal.StructureToPtr(targetAttrs, ipTargetAttrs, false);
            ceRequest.targetAttributes = ipTargetAttrs;
            #endregion

            #region user
            NextLabs.CSCInvoke.CEUser ceUser = new NextLabs.CSCInvoke.CEUser();
            IntPtr ipUserName = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceUserName = getCEString(user.userName);
            Marshal.StructureToPtr(ceUserName, ipUserName, false);
            ceUser.userName = ipUserName;

            IntPtr ipUserId = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceUserId = getCEString(user.userID);
            Marshal.StructureToPtr(ceUserId, ipUserId, false);
            ceUser.userID = ipUserId;

            IntPtr ipuser = Marshal.AllocCoTaskMem(Marshal.SizeOf(ceUser));
            Marshal.StructureToPtr(ceUser, ipuser, false);
            ceRequest.user = ipuser;
            #endregion

            #region userAttributes
            CEAttributes userAttrs = new CEAttributes();
            CEAttribute[] userArryAttrs = new CEAttribute[req.UserAttributes.Count / 2];
            for (int j = 0; j < userArryAttrs.Length; j++)
            {
                userArryAttrs[j] = new CEAttribute();
                CEString attrKey = getCEString(req.UserAttributes[j * 2]);
                IntPtr ipAttrKey = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrKey, ipAttrKey, false);
                userArryAttrs[j].key = ipAttrKey;

                CEString attrVal = getCEString(req.UserAttributes[j * 2 + 1]);
                IntPtr ipAttrValue = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrVal, ipAttrValue, false);
                userArryAttrs[j].value = ipAttrValue;
            }
            IntPtr ipuserArryAttrs = Marshal.AllocCoTaskMem(iSizeCEAttribute * userArryAttrs.Length);
            for (int k = 0; k < userArryAttrs.Length; k++)
            {
                IntPtr temp;
                temp = new IntPtr(ipuserArryAttrs.ToInt32() + k * iSizeCEAttribute);
                Marshal.StructureToPtr(userArryAttrs[k], temp, false);
            }

            userAttrs.count = userArryAttrs.Length;
            userAttrs.attrs = ipuserArryAttrs;
            IntPtr ipuserAttrs = Marshal.AllocCoTaskMem(iSizeResourceAttrs);
            Marshal.StructureToPtr(userAttrs, ipuserAttrs, false);
            ceRequest.userAttributes = ipuserAttrs;
            #endregion

            #region app
            NextLabs.CSCInvoke.CEApplication ceApp = new NextLabs.CSCInvoke.CEApplication();
            IntPtr ipAppName = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceAppName = getCEString(app.appName);
            Marshal.StructureToPtr(ceAppName, ipAppName, false);
            ceApp.appName = ipAppName;

            IntPtr ipAppPath = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceAppPath = getCEString(app.appPath);
            Marshal.StructureToPtr(ceAppPath, ipAppPath, false);
            ceApp.appPath = ipAppPath;

            IntPtr ipAppUrl = Marshal.AllocCoTaskMem(iSizeCEString);
            CEString ceAppUrl = getCEString(app.appURL);
            Marshal.StructureToPtr(ceAppUrl, ipAppUrl, false);
            ceApp.appURL = ipAppUrl;

            IntPtr ipapp = Marshal.AllocCoTaskMem(Marshal.SizeOf(ceApp));
            Marshal.StructureToPtr(ceApp, ipapp, false);
            ceRequest.app = ipapp;
            #endregion

            #region appAttributes
            CEAttributes appAttrs = new CEAttributes();
            CEAttribute[] appArryAttrs = new CEAttribute[req.AppAttributes.Count / 2];
            for (int j = 0; j < appArryAttrs.Length; j++)
            {
                appArryAttrs[j] = new CEAttribute();
                CEString attrKey = getCEString(req.AppAttributes[j * 2]);
                IntPtr ipAttrKey = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrKey, ipAttrKey, false);
                appArryAttrs[j].key = ipAttrKey;

                CEString attrVal = getCEString(req.AppAttributes[j * 2 + 1]);
                IntPtr ipAttrValue = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(attrVal, ipAttrValue, false);
                appArryAttrs[j].value = ipAttrValue;
            }

            IntPtr ipappArryAttrs = Marshal.AllocCoTaskMem(iSizeCEAttribute * appArryAttrs.Length);
            for (int k = 0; k < appArryAttrs.Length; k++)
            {
                IntPtr temp;
                temp = new IntPtr(ipappArryAttrs.ToInt32() + k * iSizeCEAttribute);
                Marshal.StructureToPtr(appArryAttrs[k], temp, false);
            }

            appAttrs.count = appArryAttrs.Length;
            appAttrs.attrs = ipappArryAttrs;
            IntPtr ipappAttrs = Marshal.AllocCoTaskMem(iSizeResourceAttrs);
            Marshal.StructureToPtr(appAttrs, ipappAttrs, false);
            ceRequest.appAttributes = ipappAttrs;
            #endregion

            #region recipients

            CEString[] ceArryRecipients = new CEString[req.Recipients.Count];

            IntPtr ipArryRecipient = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(IntPtr)) * ceArryRecipients.Length);
            for (int j = 0; j < req.Recipients.Count; j++)
            {
                ceArryRecipients[j] = getCEString(req.Recipients[j]);
                IntPtr ptrRecipient = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(ceArryRecipients[j], ptrRecipient, false);

                IntPtr temp = new IntPtr(ipArryRecipient.ToInt32() + j * Marshal.SizeOf(typeof(IntPtr)));
                Marshal.StructureToPtr(ptrRecipient, temp, false);
            }

            ceRequest.recipients = ipArryRecipient;
            ceRequest.numRecipients = ceArryRecipients.Length;

            #endregion

            #region nameAttributes
            CENamedAttributes[] ceNameAttrs = new CENamedAttributes[3];
            for (int j = 0; j < ceNameAttrs.Length; j++)
            {
                ceNameAttrs[j] = new CENamedAttributes();
                CEString ceAttrName = getCEString("ceAttrName");
                IntPtr ipAttrName = Marshal.AllocCoTaskMem(iSizeCEString);
                Marshal.StructureToPtr(ceAttrName, ipAttrName, false);
                ceNameAttrs[j].name = ipAttrName;
                ceNameAttrs[j].attrs = sourceAttrs;
            }
            int iSizeCeNameAttrs = Marshal.SizeOf(ceNameAttrs[0]);
            IntPtr ipNameAttrs = Marshal.AllocCoTaskMem(iSizeCeNameAttrs * ceNameAttrs.Length);
            for (int j = 0; j < ceNameAttrs.Length; j++)
            {
                IntPtr temp = new IntPtr(ipNameAttrs.ToInt32() + j * iSizeCeNameAttrs);
                Marshal.StructureToPtr(ceNameAttrs[j], temp, false);
            }
            ceRequest.additionalAttributes = ipNameAttrs;

            ceRequest.numAdditionalAttributes = ceNameAttrs.Length;
            #endregion

            ceRequest.performObligation = req.PerformObligation;
            ceRequest.noiseLevel = (int)noiseLevel;

            return ceRequest;
        }



        private static CEString getCEString(string str)
        {
            CEString ceString = new CEString();
            if (str != null)
            {
                ceString.buf = str;
                ceString.length = str.Length;
            }
            else
            {
                ceString.buf = null;
                ceString.length = 0;
            }
            return ceString;
        }
    }
}

