using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        PlayerData playerData = new PlayerData();
        GameAccount player1 = new Standard_account("Player1");
        GameAccount player2 = new Premium_account("Player2");
        GameAccount player3 = new WinStreak_account("Player3");

        playerData.AddPlayer(player1);
        playerData.AddPlayer(player2);
        playerData.AddPlayer(player3);

        Game standard1 = GameFactory.CreateGame("Standard", "Player1", 10);
        Game standard2 = GameFactory.CreateGame("Standard", "Player2", 10);
        Game standard3 = GameFactory.CreateGame("Standard", "Player3", 20);
        Game standard4 = GameFactory.CreateGame("Standard", "Player1", 20);

        Game training1 = GameFactory.CreateGame("Training", "Player1");
        Game training2 = GameFactory.CreateGame("Training", "Player2");
        Game training3 = GameFactory.CreateGame("Training", "Player3");
       
        Game solo1 = GameFactory.CreateGame("Solo", "Player2", 12);
        Game solo2 = GameFactory.CreateGame("Solo", "Player2", 8);
        Game solo3 = GameFactory.CreateGame("Solo", "Player3", 17);
        Game solo4 = GameFactory.CreateGame("Solo", "Player3", 12);


        player1.WinGame(standard2);
        player1.WinGame(standard3);
        player1.LoseGame(training1);
        player1.LoseGame(solo1);
       
        player2.WinGame(solo2);
        player2.WinGame(training2);
        player2.LoseGame(standard1);
        player2.WinGame(standard4);

        player3.LoseGame(training3);
        player3.WinGame(standard3);
        player3.WinGame(standard4);
        player3.WinGame(solo3); 
        player3.WinGame(solo3); 
        player3.WinGame(solo4);
        player3.WinGame(solo4);

        // Виводимо статистику всіх гравців
        playerData.DisplayAllPlayersStats();
    }
}
