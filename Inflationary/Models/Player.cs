namespace Inflationry.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public string ConnectionId { get; set; }

    public Player(int id, string name, int score, string connectionId)
    {
        Id = id;
        Name = name;
        Score = score;
        ConnectionId = connectionId;
    }
}
