// Imports the System namespace, which contains basic classes
// such as Console, String, Int32, and others.
using System;

public class Job // Defines a public class called Job
{
    
    public string _jobTitle; // Public field that stores the job title

    public string _company; // Public field that stores the company name

    public int _startYear; // Public field that stores the starting year of the job

    public int _endYear;// Public field that stores the ending year of the job

    public void Display() // Public method that displays the job information on the console
    {
        // Prints the job title, company name, and the range of years worked
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}