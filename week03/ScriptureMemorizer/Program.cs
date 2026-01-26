// Showing Creativity and Exceeding Requirements
// Improvements to the previous version:
// The program now only hides the words that are still visible.
// The program now works with a library of scriptures loaded
// from an external file and selects scriptures at random.

//  Clarifications:
// To run the program correctly, copy the scriptures.txt file to:
// bin/Debug/net6.0/
//   ├----- scriptures.txt (where the program needs it)

using System;

class Program
{
    static void Main()
    {
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}
