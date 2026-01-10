using System;

class Program
{
    static void Main(string[] args)
    {
        //Ask the user for the percentage of grade achieved
        
        Console.Write("What is the percentage of grade achieved? ");
        string userInput = Console.ReadLine();
        int grade_percent = int.Parse(userInput);

        string letter = "";   //variable for the letter
        string message = "";  //variable for the message
        string sign = "";     // variable for the sign
        int last_digit= grade_percent % 10; //last digit calculation

        //for Stretch Challenge
        if (last_digit > 6)
            {
                sign = "+"; //if the last digit is greather than 6 the sign is "+"
            }
        else if (last_digit < 3)
            {
                sign = "-"; //if the last digit is less than 6 the sign is "-"
            }
        else
            {
                sign = " ";//if the last digit is grether or equals than 3 or less than 6 the sign is " "
            }

        if (grade_percent >= 90)
        {
            letter = "A";
            if (sign == "+")
                {
                sign = " "; //case for to recognize that there is no A+ grade, only A and A-. 
                }            
        }
        else if (grade_percent >= 80)
            {
                letter = "B";
            }
        else if (grade_percent >= 70)
            {
                letter = "C";
            }
        else if (grade_percent >= 60)
            {
                letter = "D";
            }
        else
            {
                letter = "F";
                sign = " ";//case for to recognize that there is no F+ or F- grade, only F. 
            }
        if (grade_percent >= 70)
        {
            message = "You passed!";
        }
        else
        {
            message ="Better luck next time!";
        }
        Console.WriteLine($"Your grade is: {letter}{sign}"); //Show letter with sign
        Console.WriteLine(message); //Show message passed or better luck next time
    }
}

