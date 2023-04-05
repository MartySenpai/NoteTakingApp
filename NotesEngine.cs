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

        Helpers.notes.Add(note);
    }   
}