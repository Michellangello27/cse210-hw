using System;

class Program
{
    /*
     I M P R O V E M E N T S   M A D E:
     **********************************
    1) A new activity was added: ScriptureActivity.
        - It reads scriptures from the scriptures.txt file.
        - The scriptures are NOT repeated until all have been used in the session.
        - It asks the user what ideas or principles come to mind.
    2) A (persistent) record is kept of how many times each activity is performed.
        - It is saved in activity_counts.txt.
    3) Random repetition of prompts/questions/scriptures (Listing/Reflecting/Scripture) was avoided until all have been used at least once per session.
        - It was implemented with simple classes (NonRepeatingStringPicker and NonRepeatingScripturePicker).
    4) The breathing animation was improved:
        - A bar with the ASCII character ▓ is used, which grows rapidly and then shrinks.

    */

    static void Main()
    {
        ActivityTracker tracker = new ActivityTracker("activity_counts.txt");

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
            Console.WriteLine("** 4. Start scripture Activity   **");
            Console.WriteLine("** 5. View activity counts       **");
            Console.WriteLine("** 6. Quit                       **");
            Console.WriteLine("***********************************");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice != null) choice = choice.Trim();
            else choice = "";

            Activity activity = null;

            if (choice == "1") activity = new BreathingActivity();
            else if (choice == "2") activity = new ReflectingActivity();
            else if (choice == "3") activity = new ListingActivity();
            else if (choice == "4") activity = new ScriptureActivity("scriptures.txt");
            else if (choice == "5")
            {
                Console.Clear();
                tracker.DisplayCounts();
                Console.WriteLine("\nPress Enter to return...");
                Console.ReadLine();
                continue;
            }
            else if (choice == "6") return;

            if (activity == null)
            {
                Console.WriteLine("Invalid option. Press Enter...");
                Console.ReadLine();
                continue;
            }

            Console.Clear();
            activity.Run(tracker);
        }
    }
}
