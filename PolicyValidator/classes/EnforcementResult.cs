using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PolicyValidator
{

    public class EnforcementResult
    {
        public Decision response { get; set; }
        public Attribute[] attributes { get; set; }
        public TestCase SourceTestCase { get; set; }
        public EnforcementResult[] subResults { get; set; }
        public string policyMessage {get; set;}


        public string PrintToRichTextBoxDocument()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\\b\\fs23 Enforcement Result :");
            if (response == Decision.Allow)
            {
                sb.AppendLine("".PadLeft(2) + "Allow\\b0\\line");
            }
            else
            {
                sb.AppendLine("".PadLeft(2) + "Deny\\b0\\line");
            }
            sb.AppendLine("\\line");
            sb.Append("\\fs21 ");
            sb.AppendLine("".PadLeft(4) + "Obligations : \\line");
            if (attributes != null && attributes.Length > 0)
            {
                for (int j = 0; j < attributes.Length; j++)
                {
                    sb.AppendLine("".PadLeft(7) + attributes[j].key.PadRight(35, '.') + " : " + attributes[j].value + "\\line");
                }
            }
            else
            {
                sb.AppendLine("".PadLeft(7) + "No Obligations.\\line");
            }
            sb.AppendLine("".PadLeft(4) + "Error : \\line");
            if (response != Decision.Error)
            {
                sb.AppendLine("".PadLeft(7) + "No Error.\\line");
            }
            else
            {
                sb.AppendLine("".PadLeft(7) + response.ToString() + "\\line");
            }
            return sb.ToString();
        }

        public string PrintToRichTextBoxCommunication()
        {
            StringBuilder sb = new StringBuilder();
            if (response == Decision.Allow)
            {
                sb.AppendLine("".PadLeft(1) + "\\b Allow\\b0\\line");
            }
            else
            {
                sb.AppendLine("".PadLeft(1) + "\\b Deny\\b0\\line");
            }
            sb.Append("\\fs21 ");
            sb.AppendLine("".PadLeft(7) + "Obligations : \\line");
            if (attributes != null && attributes.Length > 0)
            {
                for (int j = 0; j < attributes.Length; j++)
                {
                    sb.AppendLine("".PadLeft(10) + attributes[j].key.PadRight(35, '.') + " : " + attributes[j].value + "\\line");
                }
            }
            else
            {
                sb.AppendLine("".PadLeft(10) + "No Obligations.\\line");
            }
            sb.AppendLine("".PadLeft(7) + "Error : \\line");
            if (response != Decision.Error)
            {
                sb.AppendLine("".PadLeft(10) + "No Error.\\line");
            }
            else
            {
                sb.AppendLine("".PadLeft(10) + response.ToString() + "\\line");
            }
            sb.AppendLine("\\line");
            return sb.ToString();
        }
    }



    public struct Attribute
    {
        public string key;
        public string value;
        public Attribute(string k, string v)
        {
            key = k;
            value = v;
        }
    }



    public struct CEResource
    {
        public string name;
        public string type;

        public CEResource(string n, string t)
        {
            name = n;
            type = t;
        }
    }
}

