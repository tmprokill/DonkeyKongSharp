using ClassLib.Enums;

namespace ClassLib;

public class LevelInitializeHelper
{
    public static void LevelListener(GameField gameField)
    {
        while (gameField.Status != GameStatus.Stopped)
        {
            while (gameField.Status == GameStatus.Playing)
            {
                if (gameField.Objects.Player.Position.X == 0)
                {
                    gameField.Difficulty += 1;
                    
                    gameField.Objects.Player.Score += 10000;
                    gameField.Objects.Player.LevelsPassed += 1;
                    ClearAndGenerate(gameField);
                }
            }
            
            while (gameField.Status == GameStatus.Paused)
            {
                Thread.Sleep(1000);
            }
        }
    }
    
    public static void Invoke(int n, GameField gameField)
    {
        GenerateMatrixTemplate(n, gameField);
        InitializeLevel(gameField);
    }
    
    private static void GenerateMatrixTemplate(int n, GameField matrix)
    {
        var result = new Cell[n][];
        for (var i = 0; i < n; i++)
        {
            var row = new Cell[n];
            result[i] = row;
        }

        matrix.Field = result;
    }
    private static void InitializeLevel(GameField gameField)
    {
        var objects = gameField.Objects;
        SetFlameSpawn(objects.FlameSpawner);
        SetPlayerSpawn(objects.Player);
        SetBoostSpawn(objects.CupCake);
        SetExpSpawn(objects.ExpBooster);
        SetHealthSpawn(objects.HealthBooster);
        SetKeySpawn(objects.Key); 
        SetDogSpawn(objects.Dog);

        int index = 0;
        int maxDoors = 1;
        int item;
        var previous = new List<int>();
        var current = new List<int>();
        var rnd = new Random();
        
        for (int i = 0; i < gameField.Length; i++)
        {
            if (i % 4 == 0)
            { 
                previous = new List<int>(current);
                current.Clear();
                
                for (int doorCounter = 0; doorCounter < maxDoors; doorCounter++) 
                {
                   item = rnd.Next(2, 23);
                   while (previous.Contains(item) || current.Contains(item))
                   {
                       item = rnd.Next(2, 23);
                   }
                   current.Add(item); 
                }

                if (i != 0)
                {
                   maxDoors += 1; 
                }
            }
            
            for (var j = 0; j < gameField.Length; j++)
            {
                gameField[i][j] = new Cell();
                
                if (i % 4 == 0)
                {
                    gameField[i][j].Init = new Wall();
                    if (i != 24 && current.Contains(j))
                    {
                        gameField[i][j].Init = new Door();
                        if (i == 0)
                        {
                            gameField[i][j].Init.Transparent = false;
                            objects.Key.Opens = new Coordinates() { X = i, Y = j };
                        }
                    }
                }
                else if (i < 21 && ((j == 0 && i % 2 == 0) || (j == 24 && i % 2 != 0)))
                {
                    var barrel = new Cannon() { Position = new Coordinates() { X = i, Y = j } };
                    gameField[i][j].Init = barrel;
                    objects.BarrelSpawners.Add(barrel);
                }
                else
                {
                    gameField[i][j].Init = new Empty();
                }
            }
        }

        gameField[objects.CupCake.Position.X][objects.CupCake.Position.Y].Init = objects.CupCake;
        gameField[objects.ExpBooster.Position.X][objects.ExpBooster.Position.Y].Init = objects.ExpBooster;
        
        if (objects.Player.LevelsPassed % 3 == 0)
        {
            gameField[objects.HealthBooster.Position.X][objects.HealthBooster.Position.Y].Init = objects.HealthBooster;
        }

        if (objects.Player.LevelsPassed % 2 == 0)
        {
            gameField[objects.Dog.Position.X][objects.Dog.Position.Y].Current = objects.Dog;
        }
        
        gameField[objects.Player.Position.X][objects.Player.Position.Y].Current = objects.Player;
        gameField[objects.FlameSpawner.Position.X][objects.FlameSpawner.Position.Y].Init = objects.FlameSpawner;
        gameField[objects.Key.Position.X][objects.Key.Position.Y].Init = objects.Key;
    }

    private static void SetPlayerSpawn(Player player)
    {
        var xList = new List<int> { 21,22,23 };
        var rndXIndex = new Random().Next(0, xList.Count);
        
        var temp = new Coordinates() { X = xList[rndXIndex], Y = new Random().Next(3, 22) };
        
        player.Spawn = temp;
        player.Position = new Coordinates(temp);
    }
    
    private static void SetFlameSpawn(BoneFire flame)
    {
        var xList = new List<int> { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        var rndXIndex = new Random().Next(0, xList.Count);
        
        flame.Position = new Coordinates() { X = xList[rndXIndex], Y = new Random().Next(3, 22) };
    }
    
    private static void SetBoostSpawn(CupCake boost)
    {
        var xList = new List<int> { 10, 11, 14, 17, 18, 19 };
        var rndXIndex = new Random().Next(0, xList.Count);
        
        boost.Position = new  Coordinates() { X = xList[rndXIndex], Y = new Random().Next(1, 24) };
    }
    
    private static void SetExpSpawn(ExpBooster boost)
    {
        var xList = new List<int> { 2, 3, 7, 13, 15, 18, 19 };
        var rndXIndex = new Random().Next(0, xList.Count);
        
        boost.Position = new  Coordinates() { X = xList[rndXIndex], Y = new Random().Next(1, 24) };
    }
    
    private static void SetHealthSpawn(HealthBooster boost)
    {
        var xList = new List<int> { 2, 3, 7, 13, 21, 22,};
        var rndXIndex = new Random().Next(0, xList.Count);
        
        boost.Position = new  Coordinates() { X = xList[rndXIndex], Y = new Random().Next(1, 24) };
    }

    private static void SetKeySpawn(Key key)
    {
        var xList = new List<int> { 1, 2, 3, 5, 9, 11, 22,};
        var rndXIndex = new Random().Next(0, xList.Count);
        
        key.Position = new  Coordinates() { X = xList[rndXIndex], Y = new Random().Next(1, 24) };
    }

    private static void SetDogSpawn(Dog key)
    {
        var xList = new List<int> { 7, 11, 15};
        var rndXIndex = new Random().Next(0, xList.Count);

        var x = xList[rndXIndex];
        var y = new Random().Next(8, 18);
        key.Position = new Coordinates() { X = x, Y = y };
        key.SpawnPoint = new Coordinates() { X = x, Y = y };
    }
    
    public static void ClearAndGenerate(GameField gameField)
    {
        gameField.Objects.BarrelSpawners.Clear();
        gameField.Objects.FlameEnemies.Clear();
        //game.Objects.BarrelEnemies.Clear();
        InitializeLevel(gameField);
    }
}