using System;

namespace Generics
{
    public class Generic<T>
    {
        public T Property { get; set; }

        public Generic()
        {
        }

        public Generic(T property)
        {
            Property = property;
        }

        public override string ToString()
        {
            return Property.ToString();
        }
    }
}
