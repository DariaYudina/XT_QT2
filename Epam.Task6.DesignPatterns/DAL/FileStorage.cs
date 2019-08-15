using DesignPatterns.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileStorage : IStorable
    {
        public bool AddNote(User note)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAllNotes()
        {
            throw new NotImplementedException();
        }
    }
}
