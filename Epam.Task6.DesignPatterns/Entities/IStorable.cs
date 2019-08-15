using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DAL
{
    public interface IStorable
    {
        bool AddNote(User note);

        ICollection<User> GetAllNotes();
    }
}
