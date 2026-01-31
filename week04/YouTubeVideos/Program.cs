using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Video 1 → 4 comments
        Video video1 = new Video("OOP in C#", "Alex Christensen", 600);
        video1.AddComment(new Comment("Ángel Cornejo", "Very good video, clear and concise."));
        video1.AddComment(new Comment("Aliya Agbetoba", "Excellent explanation."));
        video1.AddComment(new Comment("Godwin Inyang", "It helped me a lot, thank you."));
        video1.AddComment(new Comment("António Andrade", "Very good practical example."));
        videos.Add(video1);

        // Video 2 → 3 comments
        Video video2 = new Video("Abstraction in Programming", "Anders Hejlsberg", 480);
        video2.AddComment(new Comment("Stephanie Obeng", "Great content."));
        video2.AddComment(new Comment("Adeline Scott", "Now I understand it better."));
        video2.AddComment(new Comment("Alyssa Stringham","Perfect for beginners." ));
        videos.Add(video2);

        // Video 3 → 4 comments
        Video video3 = new Video("Encapsulation in C#", "Scott Wiltamuth", 720);
        video3.AddComment(new Comment("Josef Truman", "Very useful."));
        video3.AddComment(new Comment("Spencer Engmann", "Simple and clear explanation."));
        video3.AddComment(new Comment("Christian Guevara", "Good practical example."));
        video3.AddComment(new Comment("Helama Rodrigues", "Very clear content."));
        videos.Add(video3);

        // Video 4 → 3 comments
        Video video4 = new Video("SOLID Principles", "Peter Golde", 540);
        video4.AddComment(new Comment("Vishal Vaid", "Excellent summary."));
        video4.AddComment(new Comment("Paul of Tarsus", "Very well explained."));
        video4.AddComment(new Comment("Mahonri Moriáncumer", "It helped me a lot."));
        videos.Add(video4);

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("■═════════════════════════════════════════════════════■");
            Console.WriteLine($" Title: {video.GetTitle()}");
            Console.WriteLine($" Author: {video.GetAuthor()}");
            Console.WriteLine($" Duration: {video.GetDuration()} seconds");
            Console.WriteLine($" Number of comments: {video.GetCommentCount()}");
            Console.WriteLine(" Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetAuthor()}: {comment.GetText()}");
            }
        }
    }
}
