namespace ClassLib;

public class LevelInitializer
{
    public static void GenerateMatrixTemplate(int n, Game matrix)
    {
        var result = new Cell[n][];
        for (var i = 0; i < n; i++)
        {
            var row = new Cell[n];
            result[i] = row;
        }

        matrix.FieldMatrix = result;
    }
    
    public static void InitializeLevel(Game gameboard, Player player, 
        BoneFire flameSpawn, 
        List<Cannon> barrels, 
        CupCake boost,
        ExpBooster exp,
        HealthBooster health,
        Key key)
    {
        SetFlameSpawn(flameSpawn);
        SetPlayerSpawn(player);
        SetBoostSpawn(boost);
        SetExpSpawn(exp);
        SetHealthSpawn(health);
        SetKeySpawn(key); 

        int index = 0;
        int maxDoors = 1;
        int item;
        var previous = new List<int>();
        var current = new List<int>();
        var rnd = new Random();
        
        for (int i = 0; i < gameboard.Length; i++)
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
            
            for (var j = 0; j < gameboard.Length; j++)
            {
                gameboard[i][j] = new Cell();
                
                if (i % 4 == 0)
                {
                    gameboard[i][j].Init = new Wall();
                    if (i != 24 && current.Contains(j))
                    {
                        gameboard[i][j].Init = new Door();
                        if (i == 0)
                        {
                            gameboard[i][j].Init.Transparent = false;
                            key.Opens = new Coordinates() { X = i, Y = j };
                        }
                        

                    }
                }
                else if (i < 21 && ((j == 0 && i % 2 == 0) || (j == 24 && i % 2 != 0)))
                {
                    var barrel = new Cannon() { Position = new Coordinates() { X = i, Y = j } };
                    gameboard[i][j].Init = barrel;
                    barrels.Add(barrel);
                }
                else
                {
                    gameboard[i][j].Init = new Empty();
                }
            }
        }

        gameboard[boost.Position.X][boost.Position.Y].Init = boost;
        gameboard[exp.Position.X][exp.Position.Y].Init = exp;
        if (gameboard.LevelsPassed % 3 == 0)
        {
            gameboard[health.Position.X][health.Position.Y].Init = health;
        }
        gameboard[player.Position.X][player.Position.Y].Current = player;
        gameboard[flameSpawn.Position.X][flameSpawn.Position.Y].Init = flameSpawn;
        gameboard[key.Position.X][key.Position.Y].Init = key;
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

    public static void ClearAndGenerate(ObjectCollection collection)
    {
        collection.BarrelSpawners.Clear();
        collection.FlameEnemies.Clear();
        InitializeLevel(collection.Game, collection.Player, 
            collection.FlameSpawner, collection.BarrelSpawners, 
            collection.Boost, collection.Exp, collection.Health, collection.Key);
    }
}