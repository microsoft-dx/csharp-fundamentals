using System;

namespace AdvancedGenericsInterfaces
{
    public abstract class Model : IModel
    {
        public int Id { get; set; }

        public abstract void Print();
    }
}
