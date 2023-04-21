namespace NoteTakingApp;

internal class NoteHelpers
{
    internal List<Note> notes = new();

    internal void ListNotes()
    {
        Console.Clear();
        Console.WriteLine("Notes:\n");

        foreach (Note note in notes)
        {
            Console.WriteLine($"{note.ID}.{note.Title} - {note.Date:yyyy/MM/dd HH:mm:ss}");
        }
    }

    internal void EditNote(Note note)
    {
        Console.Clear();
        Console.WriteLine("Editing Mode:\n");
        Console.WriteLine($"Note-ID {note.ID} - Last modified: {note.Date}\n");
        Console.WriteLine($"Title: {note.Title}\n");
        Console.Write($"Content:\n{note.Content}");

        string editedContent = note.Content;
        int cursorPosition = Console.CursorLeft;
        int cursorRow = Console.CursorTop - editedContent.Split('\n').Length + 1;

        // Refactor to NoteHelpers
        bool isEditing = true;

        do
        {
            Console.SetCursorPosition(cursorPosition, cursorRow);
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (cursorPosition > 0)
                {
                    cursorPosition--;
                }
                else
                {
                    cursorRow--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                if (cursorPosition < Console.WindowWidth)
                {
                    cursorPosition++;
                }
                else
                {
                    cursorRow++;
                    Console.SetCursorPosition(cursorPosition - editedContent.Length, cursorRow);
                }
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                cursorRow--;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                cursorRow++;
            }
            else if (pressedKey.Key == ConsoleKey.Backspace)
            {
                if (!string.IsNullOrEmpty(editedContent))
                {
                    editedContent = editedContent.Remove(cursorPosition -1, 1);
                    cursorPosition--;
                }
            }
            else
            {
                editedContent = editedContent.Insert(cursorPosition, pressedKey.KeyChar.ToString());
                cursorPosition++;
            }
            
            Console.Clear();
            Console.WriteLine("Editing Mode:\n");
            Console.WriteLine($"Note-ID {note.ID} - Last modified: {note.Date}\n");
            Console.WriteLine($"Title: {note.Title}\n");
            Console.Write($"Content:\n{editedContent}");
        }
        while (isEditing);
    }
}