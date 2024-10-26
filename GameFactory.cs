using System;
using System.Collections.Generic;

public static class GameFactory
{
    public static Game CreateGame(string type, string opponentName, int rating = 0)
    {
        switch (type)
        {
            case "Standard":
                return new Game_Standard(opponentName, rating);
            case "Training":
                return new Game_Practice(opponentName);
            case "Solo":
                return new Game_Solo(opponentName, rating);
            default:
                throw new ArgumentException("Невідомий тип гри.");
        }
    }
}

public class PlayerData
{
    public List<GameAccount> Players { get; private set; }

    public PlayerData()
    {
        Players = new List<GameAccount>();
    }

    public void AddPlayer(GameAccount player)
    {
        if (player == null)
        {
            throw new ArgumentException("Rating is less than 0.");
        }
        Players.Add(player);
    }

    public void DisplayAllPlayersStats()
    {
        foreach (var player in Players)
        {
            player.GetStats();
        }
    }
}
