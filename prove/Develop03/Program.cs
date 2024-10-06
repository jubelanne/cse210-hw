using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture("Trust in the Lord with all your heart and lean not on your own understanding", reference);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input == "quit") break;
            scripture.HideWords(3);  // Hide 3 random words
        }
        Console.Clear();
        scripture.Display();
        Console.WriteLine("Memorization complete!");
    }
}

class Scripture
{
    private List<Word> words;
    private Reference reference;

    public Scripture(string text, Reference reference)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.GetFormatted());
        Console.WriteLine(string.Join(" ", words.Select(w => w.GetDisplayText())));
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        var wordsToHide = words.Where(w => !w.IsHidden).OrderBy(w => random.Next()).Take(count);
        foreach (var word in wordsToHide) word.Hide();
    }

    public bool AllWordsHidden() => words.All(w => w.IsHidden);
}

class Word
{
    private string text;
    public bool IsHidden { get; private set; }

    public Word(string text) { this.text = text; IsHidden = false; }
    public void Hide() { IsHidden = true; }
    public string GetDisplayText() => IsHidden ? "_____" : text;
}

class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse = 0)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse > 0 ? endVerse : startVerse;
    }

    public string GetFormatted() => $"{book} {chapter}:{startVerse}-{endVerse}";
}
