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
    }
}
