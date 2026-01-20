using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal theJournal = new Journal();
        Entry anEntry = new Entry();
        anEntry.Display();

        Console.WriteLine("Welcome to the Journal Program!");
        int opcion = 0;
        do
        {
            //Console.Clear();
            Console.WriteLine("Please select one of the following choices");
            Console.WriteLine(" 1. Write" +
                              "\n 2. Display" +
                              "\n 3. Load" +
                              "\n 4. Save" +
                              "\n 5. Quit");
            Console.Write("What would you like to do?");
            opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    break;
                case 2:
                    Console.WriteLine("Display");
                    break;
                case 3:
                    Console.WriteLine("Load");
                    break;
                case 4:
                    Console.WriteLine("Save");
                    break;
                case 5:
                    Console.WriteLine("See you tomorrow, have a blessed day!" + "\n+ goodbye");
                    break;
                default:
                    Console.WriteLine("Please enter a valid option");
                    break;
            }
            Console.ReadKey();
        } while (opcion != 5);
    }
}