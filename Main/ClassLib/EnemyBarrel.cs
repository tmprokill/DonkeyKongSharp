namespace ClassLib;

public class EnemyBarrel : GameObject
{
    public Coordinates Position { get; set; }
    
    public int Direction { get; set; } = 1;
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = '*';

    public void MoveBarrel(Game gameBoard)
    {
        //Удаление бочки
        if (Position.Y == 0 || Position.Y == gameBoard[0].Length - 1) 
            FieldHelper.RemoveEntity(gameBoard, this);
        
        int tempY = Direction + Position.Y;
        
        int lastY = Position.Y;
    
        if (MovementHelper.CheckAccessibility((Position.X,tempY), gameBoard))
        {
            MovementHelper.CheckTakenEnemy((Position.X,tempY), gameBoard);
            Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard, this, Position.X, lastY);
        }
    }
}