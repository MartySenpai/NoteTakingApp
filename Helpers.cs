namespace NoteTakingApp;

internal class Helpers
{
    internal static List<Note> notes = new();

    internal void ListNotes()
    {
        Console.Clear();
        Console.WriteLine("Notes:\n");

        foreach (Note note in notes)
        {
            Console.WriteLine($"{note.ID}.{note.Title} - {note.Date:yyyy/MM/dd HH:mm:ss}");
        }

        Console.WriteLine("\nPress any key to return to the main menu");
        Console.ReadLine();
    }
}