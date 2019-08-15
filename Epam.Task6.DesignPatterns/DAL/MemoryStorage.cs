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
        private static List<User> Notes { get; set; }

        static MemoryStorage()
        {
            Notes = new List<User>();
        }

        public bool AddNote(User note)
        {
            if (Notes.Any(n => n.Id == note.Id))
                return false;

            Notes.Add(note);

            return true;
        }

        public ICollection<User> GetAllNotes()
        {
            return Notes;
        }
    }
}
