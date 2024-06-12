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
        var distances = CalculateWavefrontDistances(game);
        return IsAngry ? DetermineNextMove(distances, game) : (0,0);
    }

    private int[,] CalculateWavefrontDistances(GameField gameField)
    {
        int fieldWidth = gameField.Field[0].Length;
        int fieldHeight = gameField.Field.Length;
        var wavefrontDistances = InitializeWavefrontDistances(fieldHeight, fieldWidth);

        var playerPosition = gameField.Objects.Player.Position;
        wavefrontDistances[playerPosition.Y, playerPosition.X] = 0;

        var positionQueue = new Queue<(int x, int y)>();
        positionQueue.Enqueue((playerPosition.X, playerPosition.Y));

        while (positionQueue.Count > 0)
        {
            var (currentX, currentY) = positionQueue.Dequeue();
            int currentDistance = wavefrontDistances[currentY, currentX] + 1;

            EnqueueValidNeighbors(currentX, currentY, currentDistance, wavefrontDistances, positionQueue, gameField);
        }

        return wavefrontDistances;
    }

    private int[,] InitializeWavefrontDistances(int fieldHeight, int fieldWidth)
    {
        var distances = new int[fieldHeight, fieldWidth];
        for (int row = 0; row < fieldHeight; row++)
        {
            for (int col = 0; col < fieldWidth; col++)
            {
                distances[row, col] = int.MaxValue;
            }
        }
        return distances;
    }

    private void EnqueueValidNeighbors(int x, int y, int newDistance, int[,] wavefrontDistances, 
        Queue<(int x, int y)> positionQueue, GameField gameField)
    {
        EnqueueNeighborIfValid(x - 1, y, newDistance, wavefrontDistances, positionQueue, gameField);
        EnqueueNeighborIfValid(x + 1, y, newDistance, wavefrontDistances, positionQueue, gameField);
        EnqueueNeighborIfValid(x, y - 1, newDistance, wavefrontDistances, positionQueue, gameField);
        EnqueueNeighborIfValid(x, y + 1, newDistance, wavefrontDistances, positionQueue, gameField);
    }

    private void EnqueueNeighborIfValid(int neighborX, int neighborY, int newDistance, int[,] wavefrontDistances, Queue<(int x, int y)> positionQueue, GameField gameField)
    {
        if (IsNeighborValid(neighborX, neighborY, wavefrontDistances, gameField))
        {
            wavefrontDistances[neighborY, neighborX] = newDistance;
            positionQueue.Enqueue((neighborX, neighborY));
        }
    }

    private bool IsNeighborValid(int x, int y, int[,] wavefrontDistances, GameField gameField)
    {
        return MovementHelper.CheckAccessibility((x, y), gameField) && 
               wavefrontDistances[y, x] == int.MaxValue &&
               MovementHelper.CheckTransparency((x, y), gameField);
    }

    private (int deltaX, int deltaY) DetermineNextMove(int[,] wavefrontDistances, GameField gameField)
    {
        int minDistance = int.MaxValue;
        int deltaX = 0, deltaY = 0;

        var playerPosition = gameField.Objects.Player.Position;
        UpdateNextMoveIfValid(playerPosition.X - 1, playerPosition.Y, wavefrontDistances, ref minDistance, ref deltaX, ref deltaY, gameField);
        UpdateNextMoveIfValid(playerPosition.X + 1, playerPosition.Y, wavefrontDistances, ref minDistance, ref deltaX, ref deltaY, gameField);
        UpdateNextMoveIfValid(playerPosition.X, playerPosition.Y - 1, wavefrontDistances, ref minDistance, ref deltaX, ref deltaY, gameField);
        UpdateNextMoveIfValid(playerPosition.X, playerPosition.Y + 1, wavefrontDistances, ref minDistance, ref deltaX, ref deltaY, gameField);

        return (deltaX, deltaY);
    }

    private void UpdateNextMoveIfValid(int nextX, int nextY, int[,] wavefrontDistances, ref int minDistance, ref int deltaX, ref int deltaY, GameField gameField)
    {
        if (IsNextMoveValid(nextX, nextY, wavefrontDistances, ref minDistance, gameField))
        {
            minDistance = wavefrontDistances[nextY, nextX];
            deltaX = nextX - gameField.Objects.Player.Position.X;
            deltaY = nextY - gameField.Objects.Player.Position.Y;
        }
    }

    private bool IsNextMoveValid(int x, int y, int[,] wavefrontDistances, ref int minDistance, GameField gameField)
    {
        return MovementHelper.CheckAccessibility((x, y), gameField) && 
               wavefrontDistances[y, x] < minDistance;
    }
        
    private static readonly Predicate<GameObject> IsTaken = o => o is Player;
}