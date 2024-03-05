namespace ClassLib;

public class EnemyFlame : GameObject
{
    public Coordinates Position { get; set; } = new Coordinates() { X = 1, Y = 1 };
    
    public int Level { get; set; }
    
    public int HealPoints { get; set; }

    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get;} = 'F';

    public void MoveFlame(Game gameBoard)
    {
        var rnd = new Random();
        int randX = rnd.Next(2);
        int randY = (randX != 1) ? rnd.Next(2) : 0;
        
        int tempX = randX + Position.X;
        int tempY = randY + Position.Y;
    
        int lastX = Position.X;
        int lastY = Position.Y;
    
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameBoard.FieldMatrix) && !(tempX == lastX && tempY == lastY))
        {
            MovementHelper.CheckTaken((tempX,tempY), gameBoard);
            Position.X = tempX;
            Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard.FieldMatrix, this, lastX, lastY);
        }
    }
}