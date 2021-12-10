using Inflationary.Services;
using Inflationry.Models;
using Microsoft.AspNetCore.SignalR;

namespace Inflationry.Hubs;

public class GameHub : Hub
{

    private readonly GameManager _gameManager;
    private readonly TranslationService _translationService;

    public GameHub(TranslationService translationService, GameManager gameManager)
    {
        _translationService = translationService;
        _gameManager = gameManager;
    }

    public Player Join(string name)
    {
        var player = _gameManager.AddPlayer(name);

        Clients.All.SendAsync("players", _gameManager.Players);
        Clients.All.SendAsync("messages", _gameManager.Messages);
        Clients.All.SendAsync("alert", $"{name} has joined!");
        return player;
    }
    public void Leave(int id)
    {
        var name = _gameManager.Players.First(p => p.Id == id);

        _gameManager.RemovePlayer(id);

        Clients.All.SendAsync("players", _gameManager.Players);

        Clients.All.SendAsync("alert", $"{name} has left!");
    }
    public void Inflate(string name, string input)
    {
        var inflated = _translationService.Translate(input);

        var newMessage = _gameManager.AddMessage(new Message(name, input, inflated.Result, inflated.Count));

        Clients.All.SendAsync("players", _gameManager.Players);
        Clients.All.SendAsync("message", newMessage);
    }
}
