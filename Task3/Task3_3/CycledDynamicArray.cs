using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3and4
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {

        public CycledDynamicArray() : base(8) { }

        public CycledDynamicArray(int capacity) : base(capacity) { }

        public CycledDynamicArray(IEnumerable<T> toArray) : base(toArray) { }

        public T[] ToArray()
        {
            T[] array = new T[this.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = this[i];
            }
            return array;
        }
        public void CapacityResize(int newSize)
        {
            T[] tempArray = new T[newSize];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = this[i];
            }
            Array = tempArray;
        }
    }
}
