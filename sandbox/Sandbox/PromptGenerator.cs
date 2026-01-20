using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "How did you feel the Spirit and the hand of the Lord in your life today?",
        "What is the most important activity or task you have to do today?",
        "What is the greatest blessing you have in your life that you want to be thankful for today?",
        "What was the best part of my day?",
        "Is there anything that made you happy today?",
        "What are you worried about today?",
        "In your personal study of the Scriptures, what did you learn today?",
        "What was the strongest emotion you felt today?",
        "What was the highlight of your day?",
        "Was there a challenge you faced? How did you handle it?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int ind_question = random.Next(_prompts.Count);
        return _prompts[ind_question];
    }
}