using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_3and4;

namespace Task3_3and4
{
    class DynamicArray<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        T[] array;

        int length;

        private bool isReadOnly = false;

        public DynamicArray()
            : this(8)
        {
        }

        public DynamicArray(IEnumerable<T> collection)
            : this(0)
        {
            AddRange(collection);
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "capacity must be greater than 0");
            }
            array = new T[capacity];
        }

        public int Capacity
        {
            get { return array.Length; }
        }
        public int Length
        {
            get { return length; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index >= length)
                {
                    throw new IndexOutOfRangeException();
                }
                array[index] = value;
            }
        }

        void Expand(int addLength)
        {
            if (addLength < 0)
            {
                throw new ArgumentOutOfRangeException("addLength", "length must be greater than 0");
            }

            if (!NeedExpand(addLength)) { return; }

            T[] tempArr = new T[length];
            array.CopyTo(tempArr, 0);
            int log = (int)Math.Ceiling(Math.Log(length + addLength, 2));
            int newCapacity = (int)Math.Pow(2, log);
            array = new T[newCapacity];
            tempArr.CopyTo(array, 0);
        }

        void AddElement(T newValue, int position = -1)
        {
            if (length >= Capacity)
            {
                throw new InvalidOperationException("Array must have free space for new element");
            }

            if (position == -1)
            {
                position = length;
            }

            array[position] = newValue;
            length++;
        }

        bool NeedExpand(int addLength)
        {
            return length + addLength > Capacity;
        }

        public void Add(T newValue)
        {
            if (NeedExpand(1))
            {
                Expand(1);
            }
            AddElement(newValue);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int count = collection.Count();

            if (NeedExpand(count))
            {
                Expand(count);
            }

            foreach (T newValue in collection)
            {
                AddElement(newValue);
            }
        }

        public int IndexOf(T item)
        {
            int position = -1;

            for (int i = 0; i < length; i++)
            {
                if (this[i].Equals(item))
                {
                    position = i;
                    break;
                }
            }
            return position;
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Collection is read-only");
            }

            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Collection is read-only");
            }

            for (int i = 0; i < length; i++)
            {
                this[i] = default;
            }
            length = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) > -1 ? true : false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "array must be initialized");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "arrayIndex must be non-negative");
            }
            if (array.Length - arrayIndex < length)
            {
                throw new ArgumentException(
                    "The number of elements in the collection is greater than the available space from arrayIndex to the end of the destination array.");
            }

            for (int i = 0; i < length; i++)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        public int Count
        {
            get { return length; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > length)
            {
                throw new ArgumentOutOfRangeException(
                    "index",
                    "index is not a valid index in the collection");
            }

            if (NeedExpand(1))
            {
                Expand(1);
            }

            for (int i = length; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            AddElement(item, index);
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Collection is read-only");
            }
            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException("index", "index is not a valid in the collection");
            }

            for (int i = index; i < length - 1; i++)
            {
                this[i] = this[i + 1];
            }
            array[length - 1] = default;
            length--;
        }
    }
}
