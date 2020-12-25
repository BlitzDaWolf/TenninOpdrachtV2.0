using System;
using System.Collections.Generic;
using System.Reflection;

namespace Tennis.DTO.Attributes
{
    public class FilterAttribute : Attribute
    {
        public static FilterAttribute GetAttribute(PropertyInfo t)
        {
            FilterAttribute MyAttribute = (FilterAttribute)Attribute.GetCustomAttribute(t, typeof(FilterAttribute));
            if (MyAttribute == null) return null;
            return MyAttribute;
        }
    }
}