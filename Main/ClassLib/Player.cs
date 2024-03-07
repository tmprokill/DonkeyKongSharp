namespace ClassLib;

public class Player : GameObject
{
    public Coordinates Position { get; set; }
    public override bool Transparent { get; set; } = false;
    public override char Symbol { get;} = 'P';
    public static void MovePlayer(Coordinates cord, Player player, Game gameBoard)
    {
        int tempX = cord.X + player.Position.X;
        int tempY = cord.Y + player.Position.Y;
        
        int lastX = player.Position.X;
        int lastY = player.Position.Y;
        
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameBoard) && MovementHelper.CheckTransparity((tempX, tempY), gameBoard))
        {
            MovementHelper.CheckTakenPlayer((tempX,tempY), gameBoard);
            player.Position.X = tempX;
            player.Position.Y = tempY;
            FieldHelper.UpdateField(gameBoard, player, lastX, lastY);
        }
    }
}