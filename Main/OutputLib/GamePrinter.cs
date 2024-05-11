using static System.Console;
using ClassLib;
using ClassLib.Enums;
using FileWorkLib;

namespace OutputLib;

public class GamePrinter
{
    public static void PrintField(GameField gameField)
    {
        var gameEx = new GamePrinter();
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {
                gameEx.PrintMatrix(gameField, gameField.Objects.Player);
                Thread.Sleep(1000/60);
            }
            
            Finish(gameField);
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
    
    private void PrintMatrix(GameField gameFieldBoard, Player player)
    {
        SetCursorPosition(0,0);
        
        foreach (var t in gameFieldBoard.Field)
        {
            foreach (var f in t)
            {
                var currentObject  = f.Current ?? f.Init;
                ForegroundColor = currentObject.Color;
                
                Write($" {currentObject.Symbol} ");
                
                ForegroundColor = default;
            }
            
            WriteLine();
        }
        
        WriteLine($"{player.Name}'s Lives: {player.Lives}");
        WriteLine($"Score: {player.Score}");
    }
    
    private static void Finish(GameField gameField)
    {
        var player = gameField.Objects.Player;
        var highScore = ResultKeeper.GetScore();
        
        if (gameField.Status == GameStatus.Paused)
        {
            if (player.Score > highScore)
            {
                ResultKeeper.WriteScore(player.Score, player.Name);
                WriteLine(TemplateGetter.GetWin());
            }
            else
            {
                WriteLine(TemplateGetter.GetLose());
            }

            var model = new StatsModel()
            {
                LevelsPassed = player.LevelsPassed,
                HighScore = player.Score,
                MovesCount = player.StepsAmount,
                PrizesCollected = player.ItemsCollected,
                Name = player.Name,
                LosesCount = 1
            };
            
            StatsSaver.UpdateStats(model);
            
            WriteLine($"{player.Name}'s gameScore: {player.Score}");
        }
    }
}