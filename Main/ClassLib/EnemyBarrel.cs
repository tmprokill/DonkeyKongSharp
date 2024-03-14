namespace ClassLib;

public class EnemyBarrel : GameObject
{
    public Coordinates Position { get; set; }
    
    public int Direction { get; set; } = 1;
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = '*';

    //определить как я буду менять дайрекшн
    public void MoveBarrel(Game gameBoard)
    {
        //Удаление бочки
        if (Position.X == gameBoard.Length - 1 && Position.Y == gameBoard[0].Length - 1) 
            FieldHelper.RemoveEntity(gameBoard, this);

        int change = (Position.Y > 13) ? -1 : 1;
        
        int tempY = change + Position.Y;
        
        int lastY = Position.Y;
    
        if (MovementHelper.CheckAccessibility((Position.X,tempY), gameBoard))
        {
            MovementHelper.CheckTakenEnemy((Position.X,tempY), gameBoard);
            Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard, this, Position.X, lastY);
        }
    }
}