namespace ClassLib;

public class Flame : GameObject
{
    public Coordinates Position { get; set; } = new Coordinates() { X = 1, Y = 1 };
    
    public int Level { get; set; }
    
    public int HealPoints { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol => 'F';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;
    
    public Coordinates LastChange { get; set; } = new Coordinates() { X = 0, Y = 0 };
    
    public void MoveFlame(Game gameBoard, Player player)
    {
        var change = new FlameHelper().GetRandomDirection(LastChange);
        
        int tempX = change.X + Position.X;
        int tempY = change.Y + Position.Y;

        int lastX = Position.X;
        int lastY = Position.Y;
        
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameBoard))
        {
            if (MovementHelper.CheckTakenEnemy((tempX, tempY), gameBoard, player))
            {
                Player.MovePlayerSpawn(gameBoard, player);
            }
            
            Position.X = tempX;
            Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard, this, lastX, lastY);
        }
    }
}