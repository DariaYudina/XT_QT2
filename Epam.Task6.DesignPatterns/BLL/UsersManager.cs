using System;
using System.Collections.Generic;
using DesignPatterns.DAL;
using DesignPatterns.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersManager
    {
        public static IStorable MemoryStorage => Dependences.CacheStorage;
        public static IStorable FileStorage => Dependences.FileStorage;

        public static void AddNote(string text, DateTime creationTime)
        {
            MemoryStorage.AddNote(new User(text) { CreationTime = creationTime });
        }
        public static void AddNote(User note)
        {
            note.CreationTime = DateTime.Now;

            MemoryStorage.AddNote(note);
        }

        public static IEnumerable<User> GetAllNotes()
        {
            return MemoryStorage.GetAllNotes();
        }
    }
}
