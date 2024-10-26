using System;
using System.Collections.Generic;

public abstract class GameAccount
{
    private int rating = 1;
    public string UserName { get; private set; }
    public int CurrentRating
    {
        get
        { return rating; }
        set
        { if (value < 1) 
            {
                rating = 1;
            }
            else
            {
                rating = value;
            }
        }
    }

    public int GamesCount { get { return gamesHistory.Count; } }

    private List<Game> gamesHistory;

    public GameAccount(string userName)
    {
        UserName = userName;
        gamesHistory = new List<Game>();
    }

    public abstract void WinGame(Game game);
    public abstract void LoseGame(Game game);
    public abstract int Calculate_Score(Game game);

    protected void AddGame(Game game)
    {
        gamesHistory.Add(game);
    }

    public void GetStats()
    {
        Console.WriteLine($"Stats of {UserName}:");
        Console.WriteLine($"Number of games played: {GamesCount}");
        Console.WriteLine("| Game Index | Game Type     |  Opponent   | Result    | Rating  |");
        foreach (var game in gamesHistory)
        {
            string result = game.IsWin ? "Victory" : "Defeat";
            Console.WriteLine($"| {game.GameIndex,-11}| {game.GameType,-13} |  {game.OpponentName,-10} | {result,-9} | {game.Rating,-7} |");
        }
        Console.WriteLine($"Current Rating: {CurrentRating}\n");
    }
}

public class Standard_account : GameAccount
{
    public Standard_account(string userName) : base(userName) { }

    public override void WinGame(Game game)
    {
        CurrentRating += Calculate_Score(game);
        game.IsWin = true;
        AddGame(game);
    }

    public override void LoseGame(Game game)
    {
        CurrentRating -= Calculate_Score(game);
        game.IsWin = false;
        AddGame(game);
    }

    public override int Calculate_Score(Game game) 
    {
        return game.Calculate_Rating();
    }
}

public class Premium_account : GameAccount
{
    public Premium_account(string userName) : base(userName) { }

    public override void WinGame(Game game)
    {
        CurrentRating += Calculate_Score(game);
        game.IsWin = true;
        AddGame(game);
    }

    public override void LoseGame(Game game)
    {
        CurrentRating -= (Calculate_Score(game) / 2); // - Рейтинг / 2
        game.IsWin = false;
        AddGame(game);
    }

    public override int Calculate_Score(Game game)
    {
        return game.Calculate_Rating();
    }
}

public class WinStreak_account : GameAccount
{
    private int winStreak = 0;
    public WinStreak_account(string userName) : base(userName) { }

    public override void WinGame(Game game)
    {
        winStreak++;
        if (game.GameType != "Тренувальна гра") // Перевірка типу гри
        {
            CurrentRating += game.Calculate_Rating() + (winStreak > 2 ? winStreak * 2 : 0); // Якщо перемагати > 2 ігор, то N перемог * 2
        }
        else
        {
            CurrentRating += game.Calculate_Rating();
        }
        game.IsWin = true;
        AddGame(game);
    }

    public override void LoseGame(Game game)
    {
        winStreak = 0;
        CurrentRating -= game.Calculate_Rating();
        game.IsWin = false;
        AddGame(game);
    }

    public override int Calculate_Score(Game game)
    {
        return game.Calculate_Rating();
    }


}
