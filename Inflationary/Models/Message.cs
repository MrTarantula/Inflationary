namespace Inflationry.Models;

public class Message
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Original { get; set; }
    public string Inflated { get; set; }
    public int Score { get; set; }

    public Message(int id, string name, string original, string inflated, int score)
    {
        Id = id;
        Name = name;
        Original = original;
        Inflated = inflated;
        Score = score;
    }
}
