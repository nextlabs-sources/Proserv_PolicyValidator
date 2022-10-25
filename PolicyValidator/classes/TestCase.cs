using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using ikvm.extensions;
using log4net;
using PolicyValidator;



namespace PolicyValidator
{

    [DataContractAttribute()]

    public class TestCase
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string _name;
        private string _testSet;
        private TargetSystem _targetSystem;
        private Decision _expectedResult;
        private PolicyType _policyType;
        private Subject _subject;

        private string _action;
        private Resource _fromResource;
        private Resource _toResource;
        private List<Subject> _recipients;
        private string _emailSubject;
        private string _emailBody;


        public TestCase()
        {
            Name = "";
            TestSet = "";
            TargetSystem = TargetSystem.Filesystem;
            ExpectedResult = Decision.Deny;
            PolicyType = PolicyType.Document;
            Subject = new Subject("", "", "", "", new List<string>());
            Action = "";
            EmailSubject = "";
            EmailBody = "";
            FromResource = new Resource("", new List<string>());
            ToResource = new Resource("", new List<string>());
            Recipients = new List<Subject>();
            ExpectedResult = Decision.Deny;
        }

        public TestCase(string name, string testSet, TargetSystem system, PolicyType type)
        {
            Name = name;
            TestSet = testSet;
            TargetSystem = system;
            PolicyType = type;
            ExpectedResult = Decision.Deny;
            Subject = new Subject("", "", "", "", new List<string>());
            Action = "";
            FromResource = new Resource("", new List<string>());
            ToResource = new Resource("", new List<string>());
            Recipients = new List<Subject>();
            EmailSubject = "";
            EmailBody = "";
            ExpectedResult = Decision.Deny;

        }

        public TestCase(string name, string testSet, TargetSystem targetSystem, Decision expectedResult, PolicyType policyType,
            Subject subject, string action, Resource fromResource,
            Resource toResource, List<Subject> recipients, string emailSubject, string emailBody
        )
        {
            Name = name;
            TestSet = testSet;
            TargetSystem = targetSystem;
            PolicyType = policyType;
            ExpectedResult = expectedResult;
            Subject = subject;
            Action = action;
            FromResource = fromResource;
            ToResource = toResource;
            Recipients = recipients;
            EmailSubject = emailSubject;
            EmailBody = emailBody;
        }


        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(Subject.Username) && string.IsNullOrEmpty(Subject.WindowsSid) &&
                string.IsNullOrEmpty(Subject.ApplicationName) && string.IsNullOrEmpty(Subject.IpAddress) && string.IsNullOrEmpty(Action) &&
                string.IsNullOrEmpty(FromResource.ResourceName) && string.IsNullOrEmpty(ToResource.ResourceName) &&
                Subject.SubjectDynamicAttributes.Count == 0 && FromResource.ResourceDynamicAttributes.Count == 0 &&
                ToResource.ResourceDynamicAttributes.Count == 0 && string.IsNullOrEmpty(EmailSubject) && string.IsNullOrEmpty(EmailBody))
            {
                return true;
            }
            return false;
        }

        public bool IsIncomplete()
        {
            if (PolicyType.Equals(PolicyType.Communication))
            {
                if (Recipients.Count == 0 || string.IsNullOrEmpty(Subject.Username) || string.IsNullOrEmpty(Subject.WindowsSid) ||
                string.IsNullOrEmpty(Subject.ApplicationName) || string.IsNullOrEmpty(Subject.IpAddress) || string.IsNullOrEmpty(Action))
                {
                    return true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Subject.Username) || string.IsNullOrEmpty(Subject.WindowsSid) ||
                string.IsNullOrEmpty(Subject.ApplicationName) || string.IsNullOrEmpty(Subject.IpAddress) || string.IsNullOrEmpty(Action) ||
                string.IsNullOrEmpty(FromResource.ResourceName))
                {
                    return true;
                }
            }
            return false;
        }


        [DataMember()]
        public Decision ExpectedResult
        {
            get { return _expectedResult; }
            set { _expectedResult = value; }
        }

        [DataMember()]
        public PolicyType PolicyType
        {
            get { return _policyType; }
            set { _policyType = value; }
        }


        [DataMember()]
        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }


        [DataMember()]
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }


        [DataMember()]
        public Resource FromResource
        {
            get { return _fromResource; }
            set { _fromResource = value; }
        }



        [DataMember()]
        public Resource ToResource
        {
            get { return _toResource; }
            set { _toResource = value; }
        }



        [DataMember()]
        public TargetSystem TargetSystem
        {
            get { return _targetSystem; }
            set { _targetSystem = value; }
        }


        [DataMember()]

        public string EmailSubject
        {
            get { return _emailSubject; }
            set { _emailSubject = value; }
        }


        [DataMember()]

        public string EmailBody
        {
            get { return _emailBody; }
            set { _emailBody = value; }
        }


        [DataMember()]

        public List<Subject> Recipients
        {
            get { return _recipients; }
            set { _recipients = value; }
        }


        [DataMember()]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        [DataMember()]
        public string TestSet
        {
            get { return _testSet; }
            set { _testSet = value; }
        }



        public void AddRecipient(Subject value)
        {
            Recipients.Add(value);
        }



        public string PrintToRichTextBox()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\\b\\cf1\\fs23 Test Case Parameters\\b0:\\line");

            sb.Append("\\fs21 ");

            sb.AppendLine("".PadLeft(4) + "Username".PadRight(35, '.') + ": " + Subject.Username + "\\line");
            sb.AppendLine("".PadLeft(4) + "Windows SID".PadRight(35, '.') + ": " + Subject.WindowsSid + "\\line");
            sb.AppendLine("".PadLeft(4) + "Application Name".PadRight(35, '.') + ": " + Subject.ApplicationName + "\\line");
            sb.AppendLine("".PadLeft(4) + "IP Address".PadRight(35, '.') + ": " + Subject.IpAddress + "\\line");
            sb.AppendLine("".PadLeft(4) + "Subject Dynamic Attributes : " + "\\line");

            if (Subject.SubjectDynamicAttributes.Count > 0)
            {
                StringBuilder builder1 = new StringBuilder();
                for (int j = 0; j < Subject.SubjectDynamicAttributes.Count; j = j + 2)
                {
                    sb.AppendLine("".PadLeft(7) + Subject.SubjectDynamicAttributes[j].PadRight(32, '.') + ": " + Subject.SubjectDynamicAttributes[j + 1].toString() + "\\line");
                }
            }

            else
            {
                sb.AppendLine("".PadLeft(7) + "No dynamic subject attributes." + "\\line");
            }

            sb.AppendLine("\\line");

            sb.Append("".PadLeft(4) + "Recipients : ");
            if (Recipients.Count > 0)
            {
                for (int j = 0; j < Recipients.Count - 1; j = j + 1)
                {
                    sb.Append(Recipients[j].Username + "; ");
                }
                sb.AppendLine(Recipients[Recipients.Count - 1].Username + "\\line");
            }
            else
            {
                sb.AppendLine("No recipients" + "\\line");
            }

            sb.AppendLine("\\line");

            sb.AppendLine("".PadLeft(4) + "Action".PadRight(35, '.') + ": " + Action + "\\line");

            sb.AppendLine("\\line");

            sb.AppendLine("".PadLeft(4) + "From Resource Name".PadRight(35, '.') + ": " + FromResource.ResourceName + "\\line");
            sb.AppendLine("".PadLeft(4) + "From Resource Dynamic Attributes : " + "\\line");
            if (FromResource.ResourceDynamicAttributes.Count > 0)
            {
                for (int j = 0; j < FromResource.ResourceDynamicAttributes.Count; j = j + 2)
                {
                    sb.AppendLine("".PadLeft(7) + FromResource.ResourceDynamicAttributes[j].PadRight(32, '.') + ": " + FromResource.ResourceDynamicAttributes[j + 1].toString() + "\\line");
                }
            }
            else
            {
                sb.AppendLine("".PadLeft(7) + "No dynamic from resource attributes." + "\\line");
            }

            sb.AppendLine("\\line");

            sb.AppendLine("".PadLeft(4) + "To Resource Name".PadRight(35, '.') + ": " + ToResource.ResourceName + "\\line");
            sb.AppendLine("".PadLeft(4) + "To Resource Dynamic Attributes : " + "\\line");
            if (ToResource.ResourceDynamicAttributes.Count > 0)
            {
                for (int j = 0; j < ToResource.ResourceDynamicAttributes.Count; j = j + 2)
                {
                    sb.AppendLine("".PadLeft(7) + ToResource.ResourceDynamicAttributes[j].PadRight(32, '.') + ": " + ToResource.ResourceDynamicAttributes[j + 1].toString() + "\\line");
                }
            }

            else
            {
                sb.AppendLine("".PadLeft(7) + "No dynamic to resource attributes." + "\\line");
            }

            sb.AppendLine("\\line");

            return sb.toString();
        }



        public Dictionary<string, string> ToDictionary()
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("Expected Result", ExpectedResult.toString());
            dict.Add("Target System", TargetSystem.toString());
            dict.Add("Policy Type", PolicyType.ToString());
            dict.Add("Username", Subject.Username);
            dict.Add("Windows SID", Subject.WindowsSid);
            dict.Add("Application Name", Subject.ApplicationName);
            dict.Add("IP Address", Subject.IpAddress);

            if (Subject.SubjectDynamicAttributes.Count != 0)
            {
                StringBuilder builder1 = new StringBuilder();
                for (int j = 0; j < Subject.SubjectDynamicAttributes.Count; j = j + 2)
                {
                    builder1.Append(Subject.SubjectDynamicAttributes[j]);
                    builder1.Append(":");
                    builder1.Append(Subject.SubjectDynamicAttributes[j + 1]);
                    builder1.Append("; ");
                }

                builder1.Length -= 2;
                dict.Add("[SA]", builder1.toString());
            }

            dict.Add("Action", Action);
            dict.Add("From Resource Name", FromResource.ResourceName);

            if (FromResource.ResourceDynamicAttributes.Count != 0)
            {
                StringBuilder builder1 = new StringBuilder();
                for (int j = 0; j < FromResource.ResourceDynamicAttributes.Count; j = j + 2)
                {
                    builder1.Append(FromResource.ResourceDynamicAttributes[j]);
                    builder1.Append(":");
                    builder1.Append(FromResource.ResourceDynamicAttributes[j + 1]);
                    builder1.Append("; ");
                }

                builder1.Length -= 2;
                dict.Add("[FRA]", builder1.toString());
            }
            dict.Add("To Resource Name", ToResource.ResourceName);

            if (ToResource.ResourceDynamicAttributes.Count != 0)
            {
                StringBuilder builder1 = new StringBuilder();
                for (int j = 0; j < ToResource.ResourceDynamicAttributes.Count; j = j + 2)
                {
                    builder1.Append(ToResource.ResourceDynamicAttributes[j]);
                    builder1.Append(":");
                    builder1.Append(ToResource.ResourceDynamicAttributes[j + 1]);
                    builder1.Append("; ");
                }
                builder1.Length -= 2;
                dict.Add("[TRA]", builder1.toString());
            }

            if (PolicyType.Equals(PolicyType.Communication))
            {
                StringBuilder recipientString = new StringBuilder();
                foreach (Subject rep in Recipients) {
                    recipientString.Append(rep.Username + ";");
                }
                dict.Add("Recipients", recipientString.ToString());
                dict.Add("Email Subject", EmailSubject);
                dict.Add("Email Body", EmailBody);
            }
            return dict;
        }
    }
}



