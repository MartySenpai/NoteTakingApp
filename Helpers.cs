namespace NoteTakingApp;

internal class Helpers
{
    internal static List<Note> notes = new();

    internal void ListNotes()
    {
        Console.Clear();
        Console.WriteLine("Notes:\n");

        int i = 1;
        foreach (Note note in notes)
        {
            Console.WriteLine($"{i}.{note.Title} - {note.Date:yy/MM/dd HH:mm:ss}");
            i++;
        }

        Console.WriteLine("\nPress any key to return to the main menu");
        Console.ReadLine();
    }
}