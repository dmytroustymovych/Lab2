using System;

public abstract class Game
{
    private static int gameCounter = 0;
    public int GameIndex { get; private set; }
    public string OpponentName { get; set; }
    public int Rating { get; set; }
    public bool IsWin { get; set; }
    public string GameType { get; private set; } 

    public Game(string opponentName, int rating, string gameType)
    {
        GameIndex = ++gameCounter;
        OpponentName = opponentName;
        Rating = rating;
        GameType = gameType;
    }

    public abstract int Calculate_Rating();
}


public class Game_Standard : Game
{
    public Game_Standard(string opponentName, int rating)
        : base(opponentName, rating, "Standard Game") { }

    public override int Calculate_Rating()
    {
        return Rating;
    }
}


public class Game_Practice : Game
{
    public Game_Practice(string opponentName)
        : base(opponentName, 0, "Practice Game") { } 

    public override int Calculate_Rating()
    {
        return 0; // Рейтинг не змінюється
    }
}

public class Game_Solo : Game
{
    public Game_Solo(string opponentName, int rating)
        : base("Bot", rating, "Solo Game") { } 

    public override int Calculate_Rating()
    {
        return Rating;
    }
}

