using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"{CommenterName}: {CommentText}");
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // length in seconds
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        foreach (var comment in Comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create 3-4 videos
        Video video1 = new Video("C# Tutorial", "John Doe", 500);
        Video video2 = new Video("Cooking with John", "John Oliver", 800);
        Video video3 = new Video("Guitar Lessons", "Mark Knopfler", 1100);

        // Add comments to video1
        video3.AddComment(new Comment("George", "Mark's playing is legendary!"));
        video3.AddComment(new Comment("Hannah", "Clear instructions, thank you."));
        video3.AddComment(new Comment("Ian", "Can't wait for the next lesson."));

        // Add comments to video2
        video2.AddComment(new Comment("Diana", "Yummy recipes!"));
        video2.AddComment(new Comment("Edward", "John, you're the best!"));
        video2.AddComment(new Comment("Fiona", "Easy to follow steps."));

        // Add comments to video3
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very informative, thanks."));
        video1.AddComment(new Comment("Charlie", "Loved it, helped me a lot!"));
       

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video information
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
