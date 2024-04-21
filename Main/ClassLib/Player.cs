namespace ClassLib;

public class Player : GameObject
{
    public string Name { get; set; }
    public int Lives { get; set; } = 3;
    
    public Coordinates Spawn { get; set; }    
    
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get;} = 'P';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.Green;
    
    public static void MovePlayer(Coordinates cord, Player player, Game gameBoard)
    {
        int tempX = cord.X + player.Position.X;
        int tempY = cord.Y + player.Position.Y;
        
        int lastX = player.Position.X;
        int lastY = player.Position.Y;
        
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameBoard) 
            && MovementHelper.CheckTransparity((tempX, tempY), gameBoard))
        {
            MovementHelper.CheckBoost((tempX,tempY), gameBoard, player);
            if (MovementHelper.CheckTakenPlayer((tempX, tempY), gameBoard, player))
            {
                player.Position = new Coordinates(player.Spawn);
            }
            else
            {
                player.Position.X = tempX;
                player.Position.Y = tempY;
            }
            
            FieldHelper.UpdateField(gameBoard, player, lastX, lastY);
        }
    }

    public static void MovePlayerSpawn(Game game, Player player)
    {
        var last = player.Position;
        player.Position = new Coordinates(player.Spawn);
        
        FieldHelper.UpdateField(game, player, last.X, last.Y);
    }
}