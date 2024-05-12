using ClassLib.Enums;
using ClassLib.Interfaces;

namespace ClassLib;

public class СannonBall : GameObject
{
    public Coordinates Position { get; set; }
    
    public int Direction { get; set; } = 1;
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = '*';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;

    public static void Move(GameField gameField)
    {
        var cannonBalls = gameField.Objects.BarrelEnemies;
        var player = gameField.Objects.Player;
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {
                if (gameField.BarrelRunning == false)
                {
                    Thread.Sleep(5000);
                    gameField.BarrelRunning = true;
                }
                
                foreach (var cannonBall in cannonBalls)
                { 
                    cannonBall.MoveCannonBall(gameField, player);
                }
                
                Thread.Sleep((int)(800 / gameField.LevelSettings.MovementSpeed));
            }
            
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
    
    private void MoveCannonBall(GameField gameFieldBoard, Player player)
    {
        //Удаление бочки
        if (Position.Y == 0 || Position.Y == gameFieldBoard[0].Length - 1) 
            FieldHelper.RemoveEntity(gameFieldBoard, this);
        
        int tempY = Direction + Position.Y;
        
        int lastY = Position.Y;
    
        if (MovementHelper.CheckAccessibility((Position.X,tempY), gameFieldBoard))
        {
            if (MovementHelper.CheckTaken((Position.X, tempY), gameFieldBoard, IsTaken))
            {
                Player.MovePlayerSpawn(gameFieldBoard, player);
            }
            
            Position.Y = tempY;
            FieldHelper.UpdateField(gameFieldBoard, this, Position.X, lastY);
        }
    }
    
    private static readonly Predicate<GameObject> IsTaken = o => o is Player;
}