using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DAL.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class UpdateDTOAttribute : Attribute
    {
        public readonly Type ReadType;

        public UpdateDTOAttribute(Type readType)
        {
            this.ReadType = readType;
        }

        public static UpdateDTOAttribute GetAttribute(Type t)
        {
            // Get instance of the attribute.
            UpdateDTOAttribute MyAttribute = (UpdateDTOAttribute)GetCustomAttribute(t, typeof(UpdateDTOAttribute));
            if (MyAttribute == null) return null;
            return MyAttribute;
        }
    }
}
