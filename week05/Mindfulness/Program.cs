using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("***********************************");
            Console.WriteLine("**      Mindfulness Program      **");
            Console.WriteLine("***********************************");
            Console.WriteLine("**          Menu Options         **");
            Console.WriteLine("** 1. Start breathing Activity   **");
            Console.WriteLine("** 2. Start reflecting Activity  **");
            Console.WriteLine("** 3. Start listing Activity     **");
            Console.WriteLine("** 4. Quit                       **");
            Console.WriteLine("***********************************");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice != null)
            {
                choice = choice.Trim();
            }

            Activity activity = null;

            if (choice == "1") activity = new BreathingActivity();
            else if (choice == "2") activity = new ReflectingActivity();
            else if (choice == "3") activity = new ListingActivity();
            else if (choice == "4") return;

            if (activity == null)
            {
                Console.WriteLine("Invalid option. Press Enter...");
                Console.ReadLine();
                continue;
            }

            Console.Clear();
            activity.Run();
        }
    }
}
