namespace NoteTakingApp;

internal class Menu
{
    internal void ShowMainMenu()
    {
        bool isRunning = true;

        do
        {
            Console.Clear();
            string mainMenuMessage = @"
Please choose an option to proceed:
W - Write new notes
R - Read existing notes
Q - Quit application";

            Console.WriteLine(mainMenuMessage);

            string mainMenuOption = Console.ReadLine() ?? "";

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
                default:
                    Console.WriteLine("Invalid input, press enter to continue and enter a valid key.");
                    Console.ReadLine();
                    break;
            }
        } while (isRunning);
    }
}