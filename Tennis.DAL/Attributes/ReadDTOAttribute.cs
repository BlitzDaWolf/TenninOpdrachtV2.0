using System;
using System.Runtime.CompilerServices;

namespace Tennis.DAL.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ReadDTOAttribute : Attribute
    {
        public readonly Type ReadType;
        public override object TypeId => base.TypeId;

        public ReadDTOAttribute(Type readType)
        {
            this.ReadType = readType;
        }

        public static ReadDTOAttribute GetAttribute(Type t)
        {
            // Get instance of the attribute.
            ReadDTOAttribute MyAttribute = (ReadDTOAttribute)Attribute.GetCustomAttribute(t, typeof(ReadDTOAttribute));
            if (MyAttribute == null) return null;
            return MyAttribute;
        }
    }
}