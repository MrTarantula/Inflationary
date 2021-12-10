namespace Inflationry.Models;

public class Message
{
    public string Name { get; set; }
    public string Original { get; set; }
    public string Inflated { get; set; }
    public int Score { get; set; }

    public Message(string name, string original, string inflated, int score)
    {
        Name = name;
        Original = original;
        Inflated = inflated;
        Score = score;
    }
}
