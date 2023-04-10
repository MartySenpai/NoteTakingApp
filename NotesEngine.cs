namespace NoteTakingApp;

internal class NoteEngine
{
    NoteHelpers noteHelpers = new();

    internal void WriteNote()
    {
        Note note = new();

        Console.Clear();
        Console.WriteLine("\nPlease give your note a title. The title name will be used when saving your note...\n");
        note.Title = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"Title: {note.Title}");

        Console.WriteLine("\nAdd content to your note...\n");
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

        Console.Clear();
        Console.WriteLine($"Note saved with ID {id}");
        Console.ReadLine();
    }

    internal void ReadNote()
    {
        noteHelpers.ListNotes();
        Console.WriteLine("Please enter the ID for the note you which to read...");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int id))
        {
            Note note = noteHelpers.notes.FirstOrDefault(n => n.ID == id);

            if (note != null)
            {
                Console.WriteLine($"Title: {note.Title} - Date: {note.Date}");
                Console.WriteLine($"Content: {note.Content}");
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

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}