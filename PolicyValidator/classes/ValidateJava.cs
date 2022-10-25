using System;
using System.Net;
using System.Reflection;
using com.nextlabs.destiny.sdk;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace PolicyValidator
{
    class ValidateJava : IValidate
    {
        //Using Old API for Connection initialize and close. Obsolete Code.
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private CESdk _ceSDk = new CESdk();
        private long _connectionHandle;
        public string ApplicationName { get; set; }
        public string Sid { get; set; }
        public string Username { get; set; }
        public int Port { get; set; }
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
            Port = port;

            Log.Debug("Attempting to connect to PC.");

            if (_connectionHandle == 0)
            {
                Log.Debug("Connection handle = IntPtr.Zero.");
                CEApplication app = new CEApplication(null, ApplicationName, null);
                CEUser user = new CEUser(Username, Sid);

                try
                {
                    _connectionHandle = _ceSDk.Initialize(app, user, PdpIpAddress, port, (int)(TimeoutS * 1000));
                }
                catch (Exception ex)
                {
                    Log.Error("An error occurred while connecting to Java PC. ", ex);
                    _connectionHandle = -1;
                }

                ConnectionResult = _connectionHandle.ToString();

                Log.Debug("PC response : " + _connectionHandle);

                if (_connectionHandle >= 0)
                {
                    Log.Info("Connected to PC.");
                }
            }
            else
            {
                Log.Warn("Connection handle != IntPtr.Zero. Already connected to PC?");
            }

            return _connectionHandle >= 0;
        }


        public bool DisconnectFromPC()
        {
            Log.Debug("Attempting to Disconnect.");

            if (_connectionHandle == 0)
                return true;

            _ceSDk.Close(_connectionHandle, (int)(TimeoutS * 1000));
            _connectionHandle = 0;

            Log.Debug("Successfully disconnected from PC.");

            return true;
        }


        public bool Evaluate(Requests[] req, string pql, bool ignoreBuiltInPolicies, out EnforcementResult[] enforcement, int timeout)
        {
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

            CESdk _ceSDk = new CESdk(PdpIpAddress, Port);
            uint ipNumber = Util.IpAddressToIpNumber(ipAddress);

            java.util.List enforcementList = new java.util.ArrayList();
            java.util.List requestList = new java.util.ArrayList();

            for (int i = 0; i < ceRequests.Length; i++)
            {
                requestList.add(ceRequests[i]);
            }
            enforcement = new EnforcementResult[requestList.size()];

            Log.Debug("RequestList Size: " + requestList.size());

            try
            {
                enforcementList = _ceSDk.checkResources(requestList, pql, ignoreBuiltInPolicies, (int)ipNumber, timeout * 1000);
            }
            catch (CESdkException ce)
            {
                Log.Error("CESdkException: " + ce);
                return false;
            }

            for (int i = 0; i < requestList.size(); i++)
            {
                enforcement[i] = new EnforcementResult();
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                FieldInfo fInfo = enforcementList.get(i).GetType().GetField("response", BindingFlags.NonPublic | BindingFlags.Instance);
                string res = (string)Convert.ToString(fInfo.GetValue(enforcementList.get(i)));
                if (res == "ALLOW")
                {
                    enforcement[i].response = Decision.Allow;
                }
                else if (res == "DENY")
                {
                    enforcement[i].response = Decision.Deny;
                }
                else
                {
                    enforcement[i].response = Decision.Error;
                }
                Log.Debug("Enforcement Response " + i + " : " + enforcement[i].response);
                FieldInfo fInfo1 = enforcementList.get(i).GetType().GetField("obligations", BindingFlags.NonPublic | BindingFlags.Instance);
                Object obj = (Object)fInfo1.GetValue(enforcementList.get(i));

                FieldInfo fInfo2 = obj.GetType().GetField("attributes", BindingFlags.NonPublic | BindingFlags.Instance);
                Object obj1 = (Object)fInfo2.GetValue(obj);

                FieldInfo fInfo3 = obj1.GetType().GetField("elementData", BindingFlags.NonPublic | BindingFlags.Instance);
                Object[] obj2 = (Object[])fInfo3.GetValue(obj1);

                Attribute[] javaAttribute = new Attribute[obj2.Count()];
                if (obj2.Count() != 0)
                {
                    for (int j = 0; j < obj2.Count(); j++)
                    {
                        FieldInfo fInfo4 = obj2[j].GetType().GetField("key", BindingFlags.NonPublic | BindingFlags.Instance);
                        Object obj3 = (Object)fInfo4.GetValue(obj2[j]);
                        FieldInfo fInfo5 = obj2[j].GetType().GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
                        Object obj4 = (Object)fInfo5.GetValue(obj2[j]);
                        if (obj3 != null && obj4 != null)
                        {
                            Attribute attr = new Attribute((string)fInfo4.GetValue(obj2[j]), (string)fInfo5.GetValue(obj2[j]));
                            javaAttribute[j] = attr;
                        }
                    }
                    enforcement[i].attributes = javaAttribute;
                }
                else
                {
                    enforcement[i].attributes = null;
                }
            }
            return true;
        }


        private CERequest PrepareRequest(Requests req)
        {
            var app = new CEApplication(req.AppName, null, null);
            var user = new CEUser(req.Username, req.Sid);
            const int noiseLevel = ICESdk.__Fields.CE_NOISE_LEVEL_USER_ACTION;
            string operation = req.Operation;
            bool performObligation = req.PerformObligation;
            string[] recipients = null;
            for (int i = 0; i < req.Recipients.Count; i = i + 1)
            {
                recipients[i] = req.Recipients[i];
            }
            com.nextlabs.destiny.sdk.CEResource javaSrcRes = new com.nextlabs.destiny.sdk.CEResource(req.SourceName, req.SourceType);
            com.nextlabs.destiny.sdk.CEResource javaDestRes;
            if (req.TargetName == null || req.TargetType == null)
            {
                javaDestRes = null;
            }
            else
            {
                javaDestRes = new com.nextlabs.destiny.sdk.CEResource(req.TargetName, req.TargetType);
            }

            CEAttributes sourceAttributes = new CEAttributes();
            for (int i = 0; i < req.SourceAttributes.Count; i = i + 2)
            {
                sourceAttributes.add(req.SourceAttributes[i], req.SourceAttributes[i + 1]);
            }

            CEAttributes targetAttributes = new CEAttributes();
            for (int i = 0; i < req.TargetAttributes.Count; i = i + 2)
            {
                targetAttributes.add(req.TargetAttributes[i], req.TargetAttributes[i + 1]);
            }

            CEAttributes userAttributes = new CEAttributes();
            for (int i = 0; i < req.UserAttributes.Count; i = i + 2)
            {
                userAttributes.add(req.UserAttributes[i], req.UserAttributes[i + 1]);
            }

            CEAttributes appAttributes = new CEAttributes();
            for (int i = 0; i < req.AppAttributes.Count; i = i + 2)
            {
                appAttributes.add(req.AppAttributes[i], req.AppAttributes[i + 1]);
            }

            //Additional Attributes not used currently. Hard-Coded to null
            //CENamedAttributes[] additionalAttributes1 = new CENamedAttributes[1] { new CENamedAttributes("Test", new String[] { "key", "value" }) };
            CENamedAttributes[] additionalAttributes = null;
            CERequest ceRequest = new CERequest(operation, javaSrcRes, sourceAttributes, javaDestRes, targetAttributes, user, userAttributes, app, appAttributes, recipients, additionalAttributes, performObligation, noiseLevel);

            return ceRequest;
        }
    }
}

