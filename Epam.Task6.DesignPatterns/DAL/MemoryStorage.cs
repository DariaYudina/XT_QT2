using DesignPatterns.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemoryStorage : IStorable
    {
        public bool AddNote(User note)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
