namespace ClassLib;

public class СannonBall : GameObject
{
    public Coordinates Position { get; set; }
    
    public int Direction { get; set; } = 1;
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get; } = '*';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkRed;

    public void MoveCannonBall(Game gameBoard, Player player)
    {
        //Удаление бочки
        if (Position.Y == 0 || Position.Y == gameBoard[0].Length - 1) 
            FieldHelper.RemoveEntity(gameBoard, this);
        
        int tempY = Direction + Position.Y;
        
        int lastY = Position.Y;
    
        if (MovementHelper.CheckAccessibility((Position.X,tempY), gameBoard))
        {
            if (MovementHelper.CheckTakenEnemy((Position.X, tempY), gameBoard, player))
            {
                Player.MovePlayerSpawn(gameBoard, player);
            }
            
            Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard, this, Position.X, lastY);
        }
    }
}