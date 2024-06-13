using ClassLib.Enums;

namespace ClassLib;

public class Dog : GameObject
{
    public Coordinates Position { get; set; }
    
    public Coordinates SpawnPoint { get; set; }
    
    public override bool Transparent { get; set; } = false;

    public bool IsAngry { get; set; }
    
    public bool MovedLeft { get; set; }

    public override string Image => IsAngry ? 
        MovedLeft ? "AngryDogLeft" : "AngryDogRight" : 
        MovedLeft ? "CalmDogLeft" : "CalmDogRight";
    
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
                
                Thread.Sleep((int) (800 / game.LevelSettings.MovementSpeed));
            }
            
            while (game.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }

    private void MoveDog(GameField game)
    {
        var change = GetShortestPath(game);

        if (change.Item1 == 0 && change.Item2 == 0)
        {
            MovedLeft = !MovedLeft;
        }
        else
            MovedLeft = change.Item2 switch
            {
                1 => false,
                -1 => true,
                _ => MovedLeft
            };

        int tempX = change.Item1 + Position.X;
        int tempY = change.Item2 + Position.Y;

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
    
    public (int, int) GetShortestPath(GameField game)
    {
        var distances = CalculateGrassFireDistances(game);
        return IsAngry ? DetermineNextMove(distances, game) : MovementHelper.GetShortestPath(game, SpawnPoint);
    }

    private int[,] CalculateGrassFireDistances(GameField gameField)
    {
        var fieldWidth = gameField.Field[0].Length;
        var fieldHeight = gameField.Field.Length;
        var grassFireWaveDistances = new int[fieldHeight, fieldWidth];

        for (var row = 0; row < fieldHeight; row++)
        {
            for (var col = 0; col < fieldWidth; col++)
            {
                grassFireWaveDistances[row, col] = int.MaxValue;
            }
        }

        grassFireWaveDistances[gameField.Objects.Player.Position.Y, gameField.Objects.Player.Position.X] = 0;

        var positionQueue = new Queue<(int x, int y)>();
        positionQueue.Enqueue((gameField.Objects.Player.Position.X, gameField.Objects.Player.Position.Y));

        while (positionQueue.Count > 0)
        {
            (var currentX, var currentY) = positionQueue.Dequeue();
            var currentDistance = grassFireWaveDistances[currentY, currentX] + 1;

            EnqueueNeighborIfValid(currentX - 1, currentY, currentDistance, grassFireWaveDistances, positionQueue, gameField);
            EnqueueNeighborIfValid(currentX + 1, currentY, currentDistance, grassFireWaveDistances, positionQueue, gameField);
            EnqueueNeighborIfValid(currentX, currentY - 1, currentDistance, grassFireWaveDistances, positionQueue, gameField);
            EnqueueNeighborIfValid(currentX, currentY + 1, currentDistance, grassFireWaveDistances, positionQueue, gameField);
        }

        return grassFireWaveDistances;
    }

    private void EnqueueNeighborIfValid(int neighborX, int neighborY, int newDistance, 
        int[,] distances, Queue<(int x, int y)> positionQueue, GameField gameField)
    {
        if (MovementHelper.CheckAccessibility((neighborX, neighborY), gameField) 
            && distances[neighborY, neighborX] == int.MaxValue &&
            MovementHelper.CheckTransparency((neighborX, neighborY), gameField))
        {
            distances[neighborY, neighborX] = newDistance;
            positionQueue.Enqueue((neighborX, neighborY));
        }
    }
    //метод, що з'ясовує найближчу клітинку
    private (int deltaX, int deltaY) DetermineNextMove(int[,] distances, GameField gameField)
    {
        var minimumDistance = int.MaxValue;
        var deltaX = 0;
        var deltaY = 0;

        UpdateNextMoveIfValid(Position.X - 1, Position.Y, distances, ref minimumDistance, ref deltaX, ref deltaY, gameField);
        UpdateNextMoveIfValid(Position.X + 1, Position.Y, distances, ref minimumDistance, ref deltaX, ref deltaY, gameField);
        UpdateNextMoveIfValid(Position.X, Position.Y - 1, distances, ref minimumDistance, ref deltaX, ref deltaY, gameField);
        UpdateNextMoveIfValid(Position.X, Position.Y + 1, distances, ref minimumDistance, ref deltaX, ref deltaY, gameField);

        return (deltaX, deltaY);
    }
    
    private void UpdateNextMoveIfValid(int nextX, int nextY, int[,] distances, ref int minimumDistance, ref int deltaX, ref int deltaY, GameField gameField)
    {
        if (MovementHelper.CheckAccessibility((nextX, nextY), gameField) && distances[nextY, nextX] < minimumDistance)
        {
            minimumDistance = distances[nextY, nextX];
            deltaX = nextX - Position.X;
            deltaY = nextY - Position.Y;
        }
    }
    
    private static readonly Predicate<GameObject> IsTaken = o => o is Player;
}