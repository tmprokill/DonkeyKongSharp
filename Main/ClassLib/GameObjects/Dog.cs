using ClassLib.Enums;

namespace ClassLib;

public class Dog : GameObject
{
    public Coordinates Position { get; set; }
    
    public Coordinates SpawnPoint { get; set; }
    
    public override bool Transparent { get; set; } = false;

    public bool IsAngry { get; set; } = false;

    public override string Image => IsAngry ? "AngryDog" : "CalmDog";
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.DarkCyan;

    public static void Move(GameField game)
    {
        var dog = game.Objects.Dog;
        while (game.Status != GameStatus.Stopped)
        {
            while (game.Status == GameStatus.Playing)
            {
                dog.CheckPlayerInDomain(game);
                
                dog.MoveDog(game);
                
                Thread.Sleep((int) (1000 / game.LevelSettings.MovementSpeed));
            }
            
            while (game.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }

    private void MoveDog(GameField game)
    {
        var change = MovementHelper.GetShortestPath(game, IsAngry ? game.Objects.Player.Position : SpawnPoint);
        
        int tempX = change.X + Position.X;
        int tempY = change.Y + Position.Y;

        int lastX = Position.X;
        int lastY = Position.Y;
        
        if (MovementHelper.CheckAccessibility((tempX,tempY), game))
        {
            if (MovementHelper.CheckTaken((tempX, tempY), game, IsTaken))
            {
                Player.MovePlayerSpawn(game, game.Objects.Player);
            }
            
            Position.X = tempX;
            Position.Y = tempY;
            FieldHelper.UpdateField(game, this, lastX, lastY);
        }
    }
    private static readonly Predicate<GameObject> IsTaken = o => o is Player;

    private void CheckPlayerInDomain(GameField game)
    {
        var player = game.Objects.Player;
        var dog = game.Objects.Dog;

        if (Math.Abs(dog.Position.X - player.Position.X) <= 3)
        {
            IsAngry = true;
        }
        else
        {
            IsAngry = false;
        }
        
    }
}