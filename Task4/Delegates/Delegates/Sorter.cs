namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    internal class Sorter<T>
    {
        private T[] array;
        private Func<T> orderRule;        

        public Sorter(T[] array, Func<T> orderRule)
        {
            this.Array = array;
            this.orderRule = orderRule;
        }

        internal delegate int Func<CompareType>(CompareType first, CompareType second);

        public event EventHandler<EventArgs> Sorted;

        public T[] Array
        {
            get
            {
                return this.array;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("array");
                }

                this.array = value;
            }
        }

        public Func<T> OrderRule 
        { 
            set { this.orderRule = value; } 
        }

        public static void OrderArray<OrderType>(OrderType[] array, Func<OrderType> orderRule)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (orderRule != null)
                    {
                        if (orderRule(array[i], array[j]) > 0)
                        {
                            OrderType temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }

        public void ThreadSort()
        {
            Thread thread = new Thread(this.ThreadOrderArray);
            thread.Start();
        }

        protected virtual void OnSorted()
        {
            if (this.Sorted != null)
            {
                this.Sorted(this, EventArgs.Empty);
            }
        }

        private void ThreadOrderArray()
        {
            OrderArray(this.array, this.orderRule);
            this.OnSorted();
        }
    }
}
