using ClassLib.Enums;

namespace ClassLib;

public class Cannon : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = 'S';

    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
    
    public static void Spawn(GameField gameField)
    {
        var cannonList = gameField.Objects.BarrelEnemies;
        var cannonSpawners = gameField.Objects.BarrelSpawners;
        
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {
                if (gameField.BarrelRunning == false)
                {
                    Thread.Sleep(5000);
                    gameField.BarrelRunning = true;
                }
                
                foreach (var item in cannonSpawners)
                {
                    cannonList.Add(new СannonBall { Position = new Coordinates(item.Position), Direction = item.Position.Y < 13 ? 1 : -1});
                }
                
                Thread.Sleep((int) (5000 / gameField.LevelSettings.SpawnSpeed));
            }
             
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(500);
            }
        }
    }
}