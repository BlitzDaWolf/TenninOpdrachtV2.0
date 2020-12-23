using System;
using System.Reflection;

namespace Tennis.DTO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DropDownAttribute : Attribute
    {
        public Type Target { get; set; }
        public string SelectName { get; set; }
        public string Endpoint { get; set; }

        public DropDownAttribute(Type t, string selectName, string endpoint = "")
        {
            Target = t;
            SelectName = selectName;
            Endpoint = endpoint;
        }

        public static DropDownAttribute GetAttribute(PropertyInfo t)
        {
            DropDownAttribute MyAttribute = (DropDownAttribute)Attribute.GetCustomAttribute(t, typeof(DropDownAttribute));
            if (MyAttribute == null) return null;
            return MyAttribute;
        }
    }
}