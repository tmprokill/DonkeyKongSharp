using ClassLib.Enums;

namespace ClassLib;

public class BoneFire : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    public override char Symbol { get; set; } = 'B';

    public override string Image { get; } = "BoneFire";

    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
    
    public static void Spawn(GameField gameField)
    {
        var flameList = gameField.Objects.FlameEnemies;
        var flameSpawner = gameField.Objects.FlameSpawner;
        
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {   
                if (gameField.BarrelRunning == false)
                {
                    Thread.Sleep(5000);
                    gameField.BarrelRunning = true;
                }
                
                flameList.Add(new Flame() { Position = new Coordinates(flameSpawner.Position) });
                Thread.Sleep( (int)(6000 / gameField.LevelSettings.SpawnSpeed));
            }
            
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
}