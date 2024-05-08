using System.Collections.Concurrent;
using OutputLib;
using ClassLib;
using ClassLib.Enums;
using FileWorkLib;

namespace ThreadLib;

public class ThreadSpawner
{
    // private static readonly Dictionary<int, Dictionary<string, double>> DifficultyCoefficients = new Dictionary<int, Dictionary<string, double>>
    // {
    //     {
    //         0, new Dictionary<string, double>
    //         {
    //             { "spawn", 0.5 }, 
    //             { "movement", 1.0 } 
    //         }
    //     },
    //     {
    //         1, new Dictionary<string, double>
    //         {
    //             { "spawn", 1.0 }, 
    //             { "movement", 1.0 } 
    //         }
    //     },
    //     {
    //         2, new Dictionary<string, double>
    //         {
    //             { "spawn", 1.5 },
    //             { "movement", 1.5 } 
    //         }
    //     }
    // };
    
    
    
    // public static void FlameSpawner(GameField gameField)
    // {
    //     var flameList = gameField.Objects.FlameEnemies;
    //     var flameSpawner = gameField.Objects.FlameSpawner;
    //     
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {   
    //             if (gameField.BarrelRunning == false)
    //             {
    //                 Thread.Sleep(5000);
    //                 gameField.BarrelRunning = true;
    //             }
    //             
    //             flameList.Add(new Flame() { Position = new Coordinates(flameSpawner.Position) });
    //             Thread.Sleep( (int)(6000 / DifficultyCoefficients[gameField.Difficulty]["spawn"]));
    //         }
    //         
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }

    // public static void CannonSpawner(GameField gameField)
    // {
    //     var cannonList = gameField.Objects.BarrelEnemies;
    //     var cannonSpawners = gameField.Objects.BarrelSpawners;
    //     
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {
    //             if (gameField.BarrelRunning == false)
    //             {
    //                 Thread.Sleep(5000);
    //                 gameField.BarrelRunning = true;
    //             }
    //             
    //             foreach (var item in cannonSpawners)
    //             {
    //                 cannonList.Add(new СannonBall { Position = new Coordinates(item.Position), Direction = item.Position.Y < 13 ? 1 : -1});
    //             }
    //             
    //             Thread.Sleep((int) (5000 / DifficultyCoefficients[gameField.Difficulty]["spawn"]));
    //         }
    //          
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(500);
    //         }
    //     }
    // }
    
    // public static void Flame(GameField gameField)
    // {
    //     var flames = gameField.Objects.FlameEnemies;
    //     var player = gameField.Objects.Player;
    //     
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {
    //             if (gameField.FlameRunning == false)
    //             {
    //                 Thread.Sleep(5000);
    //                 gameField.FlameRunning = true;
    //             }
    //             
    //             foreach (var flame in flames)
    //             {
    //                 flame.MoveFlame(gameField, player);
    //             }
    //             
    //             Thread.Sleep((int) (1000 / DifficultyCoefficients[gameField.Difficulty]["movement"]));
    //         }
    //         
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }

    // public static void CannonBall(GameField gameField)
    // {
    //     var cannonBalls = gameField.Objects.BarrelEnemies;
    //     var player = gameField.Objects.Player;
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {
    //             if (gameField.BarrelRunning == false)
    //             {
    //                 Thread.Sleep(5000);
    //                 gameField.BarrelRunning = true;
    //             }
    //             
    //             foreach (var cannonBall in cannonBalls)
    //             { 
    //                 cannonBall.MoveCannonBall(gameField, player);
    //             }
    //             
    //             Thread.Sleep((int)(800 / DifficultyCoefficients[gameField.Difficulty]["movement"]));
    //         }
    //         
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }
    
    // public static void PrintField(GameField gameField)
    // {
    //     var gameEx = new GamePrinter();
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {
    //             gameEx.PrintMatrix(gameField, gameField.Objects.Player);
    //             Thread.Sleep(1000/60);
    //         }
    //         
    //         GameFinisher(gameField);
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }
    
    // public static void KeyReader(GameField gameField)
    // {
    //     var player = gameField.Objects.Player;
    //     var keyHandler = new KeyPressHelper();
    //     
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {
    //             var keyInfo = Console.ReadKey();
    //             player.StepsAmount += 1;
    //             keyHandler.HandleKeyPress(keyInfo.Key, gameField);
    //         }
    //         
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }

    // public static void MusicPlayer(GameField gameField)
    // {
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         var music = new MusicPlayer();
    //         music.PlayMusic(gameField);
    //         
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }
    
    // public static void LevelListener(GameField gameField)
    // {
    //     while (gameField.Status != GameStatus.Stopped)
    //     {
    //         while (gameField.Status == GameStatus.Playing)
    //         {
    //             if (gameField.Objects.Player.Position.X == 0)
    //             {
    //                 if (gameField.Difficulty < 2)
    //                 {
    //                     gameField.Difficulty += 1;
    //                 }
    //                 
    //                 gameField.Objects.Player.Score += 10000;
    //                 gameField.Objects.Player.LevelsPassed += 1;
    //                 LevelInitializeHelper.ClearAndGenerate(gameField);
    //             }
    //         }
    //         
    //         while (gameField.Status == GameStatus.Paused)
    //         {
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }
    
    // private static void GameFinisher(GameField gameField)
    // {
    //     var player = gameField.Objects.Player;
    //     var highScore = ResultKeeper.GetScore();
    //     
    //     if (gameField.Status == GameStatus.Paused)
    //     {
    //         if (player.Score > highScore)
    //         {
    //             ResultKeeper.WriteScore(player.Score, player.Name);
    //             Console.WriteLine(TemplateGetter.GetWin());
    //         }
    //         else
    //         {
    //             Console.WriteLine(TemplateGetter.GetLose());
    //         }
    //
    //         var model = new StatsModel()
    //         {
    //             LevelsPassed = player.LevelsPassed,
    //             HighScore = player.Score,
    //             MovesCount = player.StepsAmount,
    //             PrizesCollected = player.ItemsCollected,
    //             Name = player.Name,
    //             LosesCount = 1
    //         };
    //         
    //         StatsSaver.UpdateStats(model);
    //         
    //         Console.WriteLine($"{player.Name}'s gameScore: {player.Score}");
    //     }
    // }
}