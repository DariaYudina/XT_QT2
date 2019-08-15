using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersManager
    {
        public static IStorable MemoryStorage => Dependensies.NotesStorage;

        public static void AddNote(string text, DateTime creationTime)
        {
            MemoryStorage.AddNote(new Note(text) { CreationTime = creationTime });
        }
        public static void AddNote(Note note)
        {
            note.CreationTime = DateTime.Now;

            MemoryStorage.AddNote(note);
        }

        public static IEnumerable<Note> GetAllNotes()
        {
            return MemoryStorage.GetAllNotes();
        }
    }
}
