// Exceeding requirements:
// - Added mood, time, and tags to each journal entry
// - Improved user reflection and context awareness
// - The program now saves and loads .csv files that can be opened in Excel.
// - The program correctly handles quotation marks and commas in its content.

using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal theJournal = new Journal();
        int option = 0;

        Console.WriteLine("Welcome to the Journal Program (CSV Version)!");

        do
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load from CSV");
            Console.WriteLine("4. Save to CSV");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            if (!int.TryParse(Console.ReadLine(), out option)) continue;

            switch (option)
            {
                case 1:
                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._time = DateTime.Now.ToShortTimeString();
                    
                    Console.Write("How are you feeling today? ");
                    newEntry._mood = Console.ReadLine();
                    
                    Console.Write("What tag would you like to add? ");
                    newEntry._tag = Console.ReadLine();
                    
                    newEntry._promptText = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {newEntry._promptText}");
                    Console.Write("> ");
                    newEntry._entryText = Console.ReadLine();

                    theJournal.AddEntry(newEntry);
                    break;

                case 2:
                    theJournal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter the filename ==>e.g., journal.csv : ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case 4:
                    Console.Write("Enter the filename to save ==> e.g., journal.csv: ");
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