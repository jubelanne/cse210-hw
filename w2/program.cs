class Program
{
    static void Main()
    {
        var journal = new Journal();
        var prompts = new[] { "Best part of your day?", "Strongest emotion today?", "Something you'd redo?" };

        while (true)
        {
            Console.WriteLine("1. New Entry | 2. Display | 3. Save | 4. Load | 5. Exit");
            switch (Console.ReadLine())
            {
                case "1": AddEntry(journal, prompts); break;
                case "2": journal.Display(); break;
                case "3": SaveJournal(journal); break;
                case "4": LoadJournal(journal); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void AddEntry(Journal journal, string[] prompts)
    {
        var prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);
        journal.Add(new Entry(prompt, Console.ReadLine()));
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Filename: ");
        journal.Save(Console.ReadLine());
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Filename: ");
        journal.Load(Console.ReadLine());
    }
}
