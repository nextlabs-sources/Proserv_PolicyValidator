using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using ikvm.extensions;
using log4net;

namespace PolicyValidator
{
    public class Subject
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string _userName;
        private string _windowsSid;
        private string _applicationName;
        private string _ipAddress;
        private List<string>_subjectDynamicAttributes;


        public Subject(string userName, string windowsSid, string applicationName, string ipAddress, List<string> subjectDynamicAttributes)
        {
            Username = userName;
            WindowsSid = windowsSid;
            ApplicationName = applicationName;
            IpAddress = ipAddress;
            SubjectDynamicAttributes = subjectDynamicAttributes;
        }

        [DataMember()]
        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember()]
        public string WindowsSid
        {
            get { return _windowsSid; }
            set { _windowsSid = value; }
        }

        [DataMember()]
        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        [DataMember()]
        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }

        [DataMember()]
        public List<string> SubjectDynamicAttributes
        {
            get { return _subjectDynamicAttributes; }
            set { _subjectDynamicAttributes = value; }
        }

        public void AddSubjectAttribute(string key, string value)
        {
            SubjectDynamicAttributes.Add(key);
            SubjectDynamicAttributes.Add(value);
        }
    }
}
