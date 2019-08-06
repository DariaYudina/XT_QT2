using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4
{
    class MyString
    {
        private char[] symbols;
        private int length;

        public int Length
        {
            get { return length; }
        }

        public MyString(char[] value)
        {
            this.length = value.Length;
            symbols = new char[length];
            value.CopyTo(symbols, 0);
        }

        public MyString(string value)
        {
            this.length = value.Length;
            symbols = new char[length];
            value.CopyTo(0, symbols, 0, value.Length);
        }

        public override string ToString()
        {
            return this;
        }

        public char this[int index]
        {
            get
            {
                if (index >= length || index < 0)
                {
                    throw new ArgumentOutOfRangeException("index", "index must be positive and less than length");
                }
                return symbols[index];
            }
            set
            {
                if (index >= length || index < 0)
                {
                    throw new ArgumentOutOfRangeException("index", "index must be positive and less than length");
                }
                symbols[index] = value;
            }
        }

        static public MyString operator +(MyString ms1, MyString ms2)
        {
            int length;
            length = ms1.length + ms2.length;

            char[] newMS = new char[length];
            ms1.symbols.CopyTo(newMS, 0);
            ms2.symbols.CopyTo(newMS, ms1.length);
            return new MyString(newMS);
        }

        static public bool operator ==(MyString ms1, MyString ms2)
        {
            if (ms1.length != ms2.length)
            {
                return false;
            }
            for (int i = 0; i < ms1.length; i++)
            {
                if (ms1[i] != ms2[i])
                {
                    return false;
                }
            }
            return true;
        }

        static public bool operator !=(MyString ms1, MyString ms2)
        {
            return !(ms1 == ms2);
        }

        static public implicit operator MyString(string s)
        {
            return new MyString(s);
        }
        static public implicit operator String(MyString ms)
        {
            return new string(ms.symbols);
        }

        public override bool Equals(object obj)
        {
            MyString ms = obj as MyString;
            if (ms == null)
            {
                return false;
            }
            return this == ms;
        }

        public override int GetHashCode()
        {
            string str = this;
            return str.GetHashCode();
        }

        public int IndexOf(char value)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public MyString Replace(char oldValue, char newValue)
        {
            MyString ms = new MyString(this.symbols);
            for (int i = 0; i < symbols.Length; i++)
            {
                if (ms[i] == oldValue)
                {
                    ms[i] = newValue;
                }
            }
            return ms;
        }

        public MyString Remove(int startIndex, int count)
        {
            if (startIndex < 0 || count < 0 || startIndex + count >= length)
            {
                throw new ArgumentOutOfRangeException(
                    "startIndex",
                    "startIndex must be greater or equal 0 and sum of startIndex and count must be in array range");
            }
            char[] newSymbols = new char[length - count];
            int newIndex = 0;
            for (int i = 0; i < startIndex; i++, newIndex++)
            {
                newSymbols[newIndex] = symbols[i];
            }
            for (int i = startIndex + count; i < symbols.Length; i++, newIndex++)
            {
                newSymbols[newIndex] = symbols[i];
            }
            return new MyString(newSymbols);
        }

        public MyString Remove(int startIndex)
        {
            return Remove(startIndex, this.length);
        }
    }
}
