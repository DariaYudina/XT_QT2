using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3and4
{
    class CircleDynamicArrayEnumerator<T> : DynamicArrayEnumerator<T>
    {
        public CircleDynamicArrayEnumerator(DynamicArray<T> dynamicArray) : base(dynamicArray)
        {
        }

        public override bool MoveNext()
        {
            position++;
            //if (position >= this.dynamicArray.Count) return true;
            return (position < this.dynamicArray.Count);
        }
    }
}
