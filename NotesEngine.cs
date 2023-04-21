namespace NoteTakingApp;

internal class NoteEngine
{
    NoteHelpers noteHelpers = new();
    Note note = new();

    internal void WriteNote()
    {
        Note note = new();

        Console.Clear();
        Console.WriteLine("\nPlease give your note a title:\n");
        note.Title = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"Title: {note.Title}");

        Console.WriteLine("\nAdd content to your note:\n");
        note.Content = Console.ReadLine();
        note.Date = DateTime.UtcNow;

        Note lastNote = noteHelpers.notes.OrderByDescending(n => n.ID).FirstOrDefault();
        int id;

        if (lastNote is null)
        {
            id = 1;
        }
        else
        {
            id = lastNote.ID + 1;
        }

        note.ID = id;
        noteHelpers.notes.Add(note);

        Console.WriteLine($"\nNote saved with ID: {id}");
        Console.ReadLine();
    }

    internal void ReadNote()
    {
        noteHelpers.ListNotes();
        Console.WriteLine("\nPlease enter the ID for the note you wish to read...");

        string inputID = Console.ReadLine();

        // Refactor input and validation to NoteHelpers as a function for reusability.
        if (int.TryParse(inputID, out int id))
        {
            note = noteHelpers.notes.FirstOrDefault(n => n.ID == id);

            if (note != null)
            {
                Console.Clear();
                Console.WriteLine($"Note-ID {note.ID} - Last modified: {note.Date}\n");
                Console.WriteLine($"Title: {note.Title}\n");
                Console.WriteLine($"Content:\n{note.Content}\n");
            }
            else
            {
                Console.WriteLine("Note not found with the given ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for note ID.");
        }

        Console.WriteLine("Press 'E' key to edit the current note, or any other key to return to the main menu...");
        string returnOrEdit = Console.ReadLine();

        if (returnOrEdit.ToLower() == "e")
        {
            noteHelpers.EditNote(note);
        }
    }
}