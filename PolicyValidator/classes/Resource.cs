using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using ikvm.extensions;
using log4net;

namespace PolicyValidator
{
    public class Resource
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string _resourceName;
        private List<string> _resourceDynamicAttributes;

        public Resource(string resourceName, List<string> resourceDynamicAttributes)
        {
            ResourceName = resourceName;
            ResourceDynamicAttributes = resourceDynamicAttributes;
        }

        [DataMember()]
        public string ResourceName
        {
            get { return _resourceName; }
            set { _resourceName = value; }
        }

        [DataMember()]
        public List<string> ResourceDynamicAttributes
        {
            get { return _resourceDynamicAttributes; }
            set { _resourceDynamicAttributes = value; }
        }

        public void AddResourceAttribute(string key, string value)
        {
            ResourceDynamicAttributes.Add(key);
            ResourceDynamicAttributes.Add(value);
        }
    }
}
