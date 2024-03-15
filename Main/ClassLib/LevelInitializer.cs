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
    
    public static void InitializeLevel(Game gameboard, Player player, EnemyFlameSpawner flameSpawn, List<EnemyBarrelSpawner> barrels)
    {
        int index = 0;
        int maxDoors = 1;
        int item;
        var previous = new List<int>();
        var current = new List<int>();
        var rnd = new Random();
        
        for (int i = 0; i < gameboard.Length; i++)
        {
            if (i != 0 && i % 4 == 0)
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
                
                maxDoors += 1;
            }
            
            for (var j = 0; j < gameboard.Length; j++)
            {
                gameboard[i][j] = new Cell();
                
                if (i != 0 && i % 4 == 0)
                {
                    gameboard[i][j].Init = new Wall();
                    if (i != 24 && current.Contains(j))
                    {
                        gameboard[i][j].Init = new Door();
                    }
                }
                else if (i < 21 && ((j == 0 && i % 2 == 0) || (j == 24 && i % 2 != 0)))
                {
                    var barrel = new EnemyBarrelSpawner() { Position = new Coordinates() { X = i, Y = j } };
                    gameboard[i][j].Init = barrel;
                    barrels.Add(barrel);
                }
                else
                {
                    gameboard[i][j].Init = new Empty();
                }
            }
        }
        
        gameboard[player.Position.X][player.Position.Y].Current = player;
        gameboard[flameSpawn.Position.X][flameSpawn.Position.Y].Init = flameSpawn;
    }

    public static Coordinates SetFlameSpawn()
    {
        return new Coordinates() { X = 8, Y = new Random().Next(25) };
    }
    
}