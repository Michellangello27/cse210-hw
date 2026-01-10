using System;

//Using the library to use lists
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //The variable type int is a 32-bit signed integer and 
        //its range is -2,147,483,648 to 2,147,483,647
        //we could also use the short type
        List<int> numbers = new List<int>();

        int userNumber = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished : ");
        do
        {
            Console.Write("Enter number ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            // If it is zero, the number is not added to the list.
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        // Part 1: Calculating the sum of numbers in the list
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Part 2:Calculating the average of the list of numbers
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Part 3 and 4: to find the maximum number and the smallest positive number
        int max = numbers[0];
        int smallest_positive = 2147483647;//maximum number for an int variable
        foreach (int number in numbers)
        {
            if (number > max) // if this number is greater than the max, number is max
            {
                max = number; //max is the variable that contains the maximum number
            }
            //Stretch Challenge
            if (number > 0 && number < smallest_positive) // if this number is less than smallest_positive, number is less
            {
                smallest_positive = number; //smallest_positive is the variable that contains the smallest positive number
            }

        }
        Console.WriteLine($"The max is: {max}"); //show Part 3
        Console.WriteLine($"The smallest positive number is: {smallest_positive}"); //show Part 4

        // Part 5: Sort the numbers in the list and display the new sorted list
        numbers.Sort(); //Sorting the list in ascending order

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}