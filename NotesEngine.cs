namespace NoteTakingApp;

internal class NoteEngine
{
    internal void WriteNote()
    {
        Note note = new();

        Console.Clear();
        Console.WriteLine("Please give your note a title. The title name will be used when saving your note...\n");
        note.Title = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"Title: {note.Title}");

        Console.WriteLine("\nAdd content to your note...\n");
        note.Content = Console.ReadLine();

        note.Date = DateTime.UtcNow;

        Note lastNote = Helpers.notes.OrderByDescending(n => n.ID).FirstOrDefault();
        int id;

        if (lastNote is null)
        {
            id = 1;
        }
        else
        {
            id = lastNote.ID + 1;
        }

        Helpers.notes.Add(note);
    }

    internal void ReadNote()
    {
        Console.WriteLine("Please enter the ID for the note you which to read...");

        
    }
}