using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    class Custom_sort<T>
    {
        private T[] array;
        private Func<T> orderRule;
        public T[] Sort() { return null; }
        static public void Sort( T [] sortArray, Func<T,T, int> compare)
        {
            if (compare == null)
            {
                throw new NullReferenceException();
            }

            for (int i = 0; i < sortArray.Length; i++)
            {
                for (int j = 0; j < sortArray.Length; j++)
                {
                    if (compare(sortArray[j], sortArray[i]) > 0)
                    {
                        T temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
                }
            }

        }
        public Func<T> OrderRule
        {
            set { this.orderRule = value; }
        }

    }


}
