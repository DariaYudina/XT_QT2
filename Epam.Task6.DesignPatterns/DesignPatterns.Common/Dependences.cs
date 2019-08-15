using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Common
{
    class Dependences
    {
        public static IStorable NotesStorage { get; } = new MemoryStorage();
    }
}
