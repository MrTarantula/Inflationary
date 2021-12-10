using Inflationry.Models;

namespace Inflationary.Services;

public class GameManager
{
    public List<Message> Messages { get; set; }
    public List<Player> Players { get; set; }

    public GameManager()
    {
        Messages = new();
        Players = new();
    }

    public Player AddPlayer(string name)
    {
        var player = new Player(Players.Count, name, 0);
        Players.Add(player);
        return player;
    }

    public void RemovePlayer(int id)
    {
        Players.RemoveAll(p => p.Id == id);
    }

    public Message AddMessage(Message message)
    {
        Messages.Add(message);

        Players.First(p => p.Name == message.Name).Score += message.Score;

        return message;
    }
}