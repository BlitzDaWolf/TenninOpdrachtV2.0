using System;

namespace Tennis.DAL.Attributes
{
    public class ReadDTOAttribute : Attribute
    {
        public readonly Type ReadType;

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