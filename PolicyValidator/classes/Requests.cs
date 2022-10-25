using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace PolicyValidator

{

    class Requests

    {

        public string Operation { get; set; }

        public string SourceName { get; set; }

        public string SourceType { get; set; }

        public string IpAddress { get; set; }

        public string Sid { get; set; }

        public string Username { get; set; }



        private List<String> sourceAttributes = new List<String>();

        public List<String> SourceAttributes

        {

            get { return sourceAttributes; }

            set { sourceAttributes = value; }

        }

        public string TargetName { get; set; }

        public string TargetType { get; set; }



        private List<String> targetAttributes = new List<String>();

        public List<String> TargetAttributes

        {

            get { return targetAttributes; }

            set { targetAttributes = value; }

        }



        private List<String> userAttributes = new List<String>();

        public List<String> UserAttributes

        {

            get { return userAttributes; }

            set { userAttributes = value; }

        }



        public string AppName { get; set; }



        private List<String> appAttributes = new List<String>();

        public List<String> AppAttributes

        {

            get { return appAttributes; }

            set { appAttributes = value; }

        }



        private List<String> recipients = new List<String>();

        public List<String> Recipients

        {

            get { return recipients; }

            set { recipients = value; }

        }



        private List<String> additionalAttributes = new List<String>();

        public List<String> AdditionalAttributes

        {

            get { return additionalAttributes; }

            set { additionalAttributes = value; }

        }



        public bool PerformObligation { get; set; }

    }

}

