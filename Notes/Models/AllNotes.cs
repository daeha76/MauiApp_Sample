using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{
    public class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public AllNotes() => LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stroed.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Note> notes = Directory
                // Select the file names frome the directory
                .EnumerateFiles(appDataPath, "*.notes.txt")

                // Each file name is used to create a Note
                .Select(fileName => new Note
                {
                    Filename = fileName,
                    Date = File.GetCreationTime(fileName),
                    Text = File.ReadAllText(fileName)
                })
                .OrderBy(note => note.Date);

            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
