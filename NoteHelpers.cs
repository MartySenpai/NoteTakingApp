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

        int originalCursorPosition = Console.CursorLeft;
        int originalCursorRow  = Console.CursorTop;

        // Refactor to NoteHelpers
        bool isEditing = true;

        do
        {
            Console.SetCursorPosition(cursorPosition, cursorRow);
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            // starting cursor row when more than 2 rows are present is wrong, it zeros out the cursor itself.
            // so we need to set it back to the original position.
            int lineStartPosition = ((cursorRow - originalCursorRow) * Console.WindowWidth) + cursorPosition;

            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                if (cursorPosition > 0)
                {
                    cursorPosition--;
                }
                else
                {
                    cursorPosition = Console.WindowWidth;
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
                cursorRow++;
            }
            else if (pressedKey.Key == ConsoleKey.Backspace)
            {
                if (cursorPosition > 0)
                {
                    editedContent = editedContent.Remove(lineStartPosition - 1, 1);
                    cursorPosition--;
                }
                else if (cursorRow > 7 && cursorPosition <= 0)
                {
                    cursorRow--;
                    cursorPosition = Console.WindowWidth;
                    editedContent = editedContent.Remove(lineStartPosition, 1);
                }
            }
            else
            {
                if (cursorPosition != Console.WindowWidth)
                {
                editedContent = editedContent.Insert(lineStartPosition, pressedKey.KeyChar.ToString());
                cursorPosition++;
                }
                else
                {
                    cursorPosition = 0;
                    cursorRow++;

                    editedContent = editedContent.Insert(lineStartPosition, pressedKey.KeyChar.ToString());
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