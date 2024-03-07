namespace ClassLib;

public class EnemyBarrel : GameObject
{
    public Coordinates Position { get; set; } = new Coordinates() { X = 1, Y = 2 };
    public int Direction { get; set; } = 1;
    public override bool Transparent { get; set; } = false;
    public override char Symbol { get; } = '*';

    //определить как я буду менять дайрекшн
    public void MoveBarrel(Game gameBoard)
    {
        //Удаление бочки
        if (Position.X == gameBoard.Length - 1 && Position.Y == gameBoard[0].Length - 1) 
            FieldHelper.RemoveEntity(gameBoard, this);
        
        int x = 0;
        int y = 0;
        
        if (MovementHelper.CheckBarrelDown(gameBoard, this)) x = 1;
        else y = Direction * 1;
        
        int tempX = x + Position.X;
        int tempY = y + Position.Y;
    
        int lastX = Position.X;
        int lastY = Position.Y;
    
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameBoard))
        {
            MovementHelper.CheckTakenEnemy((tempX,tempY), gameBoard);
            Position.X = tempX;
            Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard, this, lastX, lastY);
        }
    }
}