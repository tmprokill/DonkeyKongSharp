using ClassLib.Enums;

namespace ClassLib;

public class Flame : GameObject
{
    public Coordinates Position { get; set; } = new Coordinates() { X = 1, Y = 1 };
    
    public int Level { get; set; }
    
    public int HealPoints { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override string Image => "Flame";
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
    
    public Coordinates LastChange { get; set; } = new Coordinates() { X = 0, Y = 0 };
    
    public static void Move(GameField gameField)
    {
        var flames = gameField.Objects.FlameEnemies;
        var player = gameField.Objects.Player;
        
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {
                if (gameField.FlameRunning == false)
                {
                    Thread.Sleep(5000);
                    gameField.FlameRunning = true;
                }
                
                foreach (var flame in flames)
                {
                    flame.MoveFlame(gameField, player);
                }
                
                Thread.Sleep((int) (1000 / gameField.LevelSettings.MovementSpeed));
            }
            
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
    
    private void MoveFlame(GameField gameFieldBoard, Player player)
    {
        var change = new FlameHelper().GetRandomDirection(LastChange);
        
        int tempX = change.X + Position.X;
        int tempY = change.Y + Position.Y;

        int lastX = Position.X;
        int lastY = Position.Y;
        
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameFieldBoard))
        {
            if (MovementHelper.CheckTaken((tempX, tempY), gameFieldBoard, IsTaken))
            {
                Player.MovePlayerSpawn(gameFieldBoard, player);
            }
            
            Position.X = tempX;
            Position.Y = tempY;
            FieldHelper.UpdateField(gameFieldBoard, this, lastX, lastY);
        }
    }
    private static readonly Predicate<GameObject> IsTaken = o => o is Player;
}