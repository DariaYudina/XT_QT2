using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    class Lost
    {
        public int lostMethod(int N)
        {
            int[] listPerson = new int[N];
            for (int i = 0; i < listPerson.Length; i++)
            {
                listPerson[i] = i + 1;
            }

            Queue<int> list = new Queue<int>(listPerson);

            while (list.Count != 1)
            {
                list.Enqueue(list.Dequeue());
                list.Dequeue();
            }
            return list.Peek();
        }
    }
}
