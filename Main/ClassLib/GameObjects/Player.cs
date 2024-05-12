namespace ClassLib;

public class Player : GameObject
{
    public string Name { get; set; }
    
    public int Lives { get; set; } = 3;
    
    public int Score { get; set; } = 0;
    
    public int StepsAmount { get; set; }

    public int LevelsPassed { get; set; }
    
    public int ItemsCollected { get; set; }
    
    public Coordinates Spawn { get; set; }    
    
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = false;
    
    public override char Symbol { get;} = 'P';
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.Green;
    
    public static void MovePlayer(Coordinates cord, Player player, GameField gameField)
    {
        int tempX = cord.X + player.Position.X;
        int tempY = cord.Y + player.Position.Y;
        
        int lastX = player.Position.X;
        int lastY = player.Position.Y;
        
        if (MovementHelper.CheckAccessibility((tempX,tempY), gameField) 
            && MovementHelper.CheckTransparency((tempX, tempY), gameField))
        {
            MovementHelper.CheckBoost((tempX,tempY), gameField);
            if (MovementHelper.CheckTaken((tempX, tempY), gameField, IsTaken))
            {
                player.Position = new Coordinates(player.Spawn);
            }
            else
            {
                player.Position.X = tempX;
                player.Position.Y = tempY;
            }
            
            FieldHelper.UpdateField(gameField, player, lastX, lastY);
        }
    }

    public static void MovePlayerSpawn(GameField gameField, Player player)
    {
        var last = player.Position;
        player.Position = new Coordinates(player.Spawn);
        
        FieldHelper.UpdateField(gameField, player, last.X, last.Y);
    }

    private static readonly Predicate<GameObject> IsTaken = o => o is Flame or СannonBall;
}