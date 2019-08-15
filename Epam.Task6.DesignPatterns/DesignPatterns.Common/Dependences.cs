using DesignPatterns.DAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Common
{
    public static class Dependences
    {
        public static IStorable UsersStorage { get; } = new MemoryStorage();
    }
}
