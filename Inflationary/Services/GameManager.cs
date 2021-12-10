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

    public Player AddPlayer(string name, string connectionId)
    {
        var player = new Player(Players.Count, name, 0, connectionId);
        Players.Add(player);
        return player;
    }

    public void RemovePlayer(int id)
    {
        Players.RemoveAll(p => p.Id == id);
    }

    public Message AddMessage(string name, string input, string result, int count)
    {
        var message = new Message(Messages.Count, name, input, result, count);

        Messages.Add(message);

        Players.First(p => p.Name == message.Name).Score += message.Score;

        return message;
    }
}