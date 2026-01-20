using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal theJournal = new Journal();

        int option = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    Entry newEntry = new Entry();

                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = promptGenerator.GetRandomPrompt();

                    Console.WriteLine(newEntry._promptText);
                    Console.Write("Your response: ");
                    newEntry._entryText = Console.ReadLine();

                    theJournal.AddEntry(newEntry);
                    break;

                case 2:
                    theJournal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter the filename to load: ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case 4:
                    Console.Write("Enter the filename to save: ");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile);
                    break;

                case 5:
                    Console.WriteLine("See you tomorrow, have a blessed day!");
                    break;

                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }

        } while (option != 5);
    }
}
