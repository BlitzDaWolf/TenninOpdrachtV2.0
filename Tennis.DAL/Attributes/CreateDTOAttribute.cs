using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DAL.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CreateDTOAttribute : Attribute
    {
        public readonly Type ReadType;

        public CreateDTOAttribute(Type readType)
        {
            this.ReadType = readType;
        }

        public static CreateDTOAttribute GetAttribute(Type t)
        {
            // Get instance of the attribute.
            CreateDTOAttribute MyAttribute = (CreateDTOAttribute)Attribute.GetCustomAttribute(t, typeof(CreateDTOAttribute));
            if (MyAttribute == null) return null;
            return MyAttribute;
        }
    }
}
