using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _durationInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int durationInSeconds)
    {
        _title = title;
        _author = author;
        _durationInSeconds = durationInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetDuration()
    {
        return _durationInSeconds;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}
