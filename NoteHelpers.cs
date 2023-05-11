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
        int cursorRow = Console.CursorTop;

        // Refactor to NoteHelpers
        bool isEditing = true;

        do
        {
            Console.SetCursorPosition(cursorPosition, cursorRow);
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            int contentLength = editedContent.Length;

            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (cursorPosition > 0)
                {
                    cursorPosition--;
                }
                else
                {
                    cursorPosition = Console.WindowWidth - 1;
                    cursorRow--;
                }
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {

                // Add whitespace when moving right after content length.
                if (cursorPosition < Console.WindowWidth)
                {
                    cursorPosition++;
                }
                else
                {
                    cursorPosition = 0;
                    cursorRow++;
                }
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                cursorRow--;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                // Add whitespace when moving right after content length.
                cursorRow++;
            }
            else if (pressedKey.Key == ConsoleKey.Backspace)
            {
                if (cursorPosition > 0)
                {
                    editedContent = editedContent.Remove(contentLength - 1, 1);
                    cursorPosition--;
                }
                else if (cursorRow > 7 && cursorPosition <= 0)
                {
                    cursorRow--;
                    cursorPosition = Console.WindowWidth - 1;
                    editedContent = editedContent.Remove(contentLength - 1, 1);
                }
            }
            else
            {
                if (cursorPosition != Console.WindowWidth)
                {
                editedContent = editedContent.Insert(contentLength, pressedKey.KeyChar.ToString());
                cursorPosition++;
                }
                else
                {
                    cursorPosition = 0;
                    cursorRow++;

                    editedContent = editedContent.Insert(contentLength, pressedKey.KeyChar.ToString());
                    cursorPosition++;
                }
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