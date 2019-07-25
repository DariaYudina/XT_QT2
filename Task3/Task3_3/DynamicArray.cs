using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3
{
    class DynamicArray<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        private T[] array;
        private int length;
        public DynamicArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "capacity must be greater than 0");
            }
            array = new T[capacity];
        }
        public DynamicArray()
           : this(8)
        {
        }

    }
}
