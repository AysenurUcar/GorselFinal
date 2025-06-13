using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using GorselFinal.Modeller;

namespace GorselFinal.Modeller
{
    internal static class DL
    {
        static FirebaseClient client = new FirebaseClient("https://gorselfinal-35fd7-default-rtdb.firebaseio.com/");

        public static bool AddNote(Notes note)
        {
            client.Child($"gorselfinal/{note.Id}").PutAsync(note);
            return true;
        }

        public static bool EditNote(Notes note)
        {
            client.Child($"gorselfinal/{note.Id}").PutAsync(note);
            return true;
        }

        public static bool DeleteNote(Notes note)
        {
            client.Child($"gorselfinal/{note.Id}").DeleteAsync();
            return true;
        }

        public static ObservableCollection<Notes> GetAllNotes()
        {
            ObservableCollection<Notes> notes = new ObservableCollection<Notes>();
            var _notes = client.Child("gorselfinal").OnceAsync<Notes>();

            foreach (var n in _notes.Result)
            {
                notes.Add(n.Object);
            }

            return notes;
        }
    }
}
