namespace NoteTakingApp;

internal class Menu
{
    internal void ShowMainMenu()
    {
        bool isRunning = true;

        do{

            // Present Menu with options(read, write, save and load).
            Console.Write(@"Please choose an option to proceed:
            W - Write new notes
            R - Read existing notes
            Q - Quit application
            ");

            string mainMenuOption = Console.ReadLine();

            // Switch for menu handling.
            switch (mainMenuOption.ToLower())
            {
                case "w":
                break;
                case "r":
                break;
                case "q":
                Console.Clear();
                Console.WriteLine("Goodbye!");
                isRunning = false;
                break;
            }
        } while (isRunning);
    }
}