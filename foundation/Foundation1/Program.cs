using System;
using System.Collections.Generic;

class Video
{
    public string Title, Author; public int Length; public List<Comment> Comments = new();
    public Video(string title, string author, int length) => (Title, Author, Length) = (title, author, length);
    public void AddComment(string name, string text) => Comments.Add(new Comment(name, text));
    public void Display() {
        Console.WriteLine($"{Title} by {Author}, Length: {Length} sec, Comments: {Comments.Count}");
        Comments.ForEach(c => Console.WriteLine($"- {c.Name}: {c.Text}"));
    }
}

class Comment
{
    public string Name, Text;
    public Comment(string name, string text) => (Name, Text) = (name, text);
}

class Program
{
    static void Main() {
        var videos = new List<Video> {
            new Video("C# Basics", "Code Academy", 600),
            new Video("Advanced C#", "Tech Guru", 1200),
            new Video("C# for Beginners", "Learning Hub", 900)
        };
        videos[0].AddComment("Alice", "Great tutorial!"); videos[0].AddComment("Bob", "Very helpful."); videos[0].AddComment("Charlie", "I learned a lot!");
        videos[1].AddComment("Diana", "Too advanced."); videos[1].AddComment("Edward", "Superb."); videos[1].AddComment("Fiona", "Loved it.");
        videos[2].AddComment("George", "Perfect for beginners!"); videos[2].AddComment("Helen", "Could use more examples."); videos[2].AddComment("Irene", "Good pace.");

        videos.ForEach(v => { v.Display(); Console.WriteLine(); });
    }
}
