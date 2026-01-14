using System;

public class Resume
{
    public string _name;

    public List<Job> _jobs = new List<Job>();//initialize the list to a new List before use it.

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs List:");
        int jobNumber = 0; //Initialize job counter
        foreach (Job job in _jobs)// Using the "Job" data type in the loop
        {
            jobNumber++;// Increment the job counter for each job
            Console.Write($"{jobNumber} : ");// Print the job number
            job.Display();// For each iteration, call the Display method
        }
    }
}