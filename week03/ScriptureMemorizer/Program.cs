// Showing Creativity and Exceeding Requirements
// Improvements to the previous version:
// A menu has been implemented that allows you to choose a book 
// from the Bible, Book of Mormon, Doctrine and Covenants, and Pearl of Great Price.
// Based on your selection, the program randomly generates a scripture from that book for you to memorize.
// The Exit option allows you to exit the Scripture Memorization program.
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

        while (true)
        {
            Console.Clear();
            Console.WriteLine("From which book do you want to memorize a passage?");
            Console.WriteLine("1. Bible");
            Console.WriteLine("2. Book of Mormon");
            Console.WriteLine("3. Doctrine and Covenants");
            Console.WriteLine("4. Pearl of Great Price");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            if (choice == "5")
            {
                break;
            }

            string bookOf = "";

            switch (choice)
            {
                case "1":
                    bookOf = "Bible";
                    break;
                case "2":
                    bookOf = "Book of Mormon";
                    break;
                case "3":
                    bookOf = "Doctrine and Covenants";
                    break;
                case "4":
                    bookOf = "Pearl of Great Price";
                    break;
                default:
                    continue;
            }

            Scripture scripture = library.GetRandomScriptureByBookOf(bookOf);

            RunMemorizer(scripture);
        }
    }

    static void RunMemorizer(Scripture scripture)
    {
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
                Console.WriteLine("\nAll words are hidden. Press Enter to return to menu.");
                Console.ReadLine();
                break;
            }
        }
    }
}
