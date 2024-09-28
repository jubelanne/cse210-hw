public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void Add(Entry entry) => entries.Add(entry);

    public void Display() => entries.ForEach(e => Console.WriteLine(e));

    public void Save(string filename)
    {
        File.WriteAllLines(filename, entries.Select(e => $"{e.Prompt}~|~{e.Response}~|~{e.Date}"));
    }

    public void Load(string filename)
    {
        entries = File.ReadAllLines(filename).Select(line =>
        {
            var parts = line.Split("~|~");
            return new Entry(parts[0], parts[1], parts[2]);
        }).ToList();
    }
}
