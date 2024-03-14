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
    
    public static void InitializeLevel(Game gameboard, Player player, EnemyBarrelSpawner barrelSpawn, EnemyFlameSpawner flameSpawn)
    {
        int maxLadders = 1;
        int ladderCounter = 0;
        int item;
        var previous = new List<int>();
        var current = new List<int>();
        var rnd = new Random();
        
        for (int i = 0; i < gameboard.Length; i++)
        {
            if (i != 0 && ladderCounter % 4 == 0)
            { 
                previous = new List<int>(current);
                current.Clear();
                
                for (int wallCounter = 0; wallCounter < maxLadders; wallCounter++) 
                {
                   item = rnd.Next(25);
                   while (previous.Contains(item) || current.Contains(item))
                   {
                       item = rnd.Next(2,25);
                   }
                   current.Add(item); 
                } 
                
                maxLadders += 1;
            }
            
            for (var j = 0; j < gameboard.Length; j++)
            {
                gameboard[i][j] = new Cell();
                
                if (i != 0 && i % 4 == 0)
                {
                    gameboard[i][j].Init = new Wall();
                    if (i != 24 && current.Contains(j))
                    {
                        gameboard[i][j].Init.Transparent = true;
                    }
                }
                else if (current.Contains(j))
                {
                    gameboard[i][j].Init = new Ladder(); // Создаем лестницы от верхней до нижней границы
                }
                else
                {
                    gameboard[i][j].Init = new Empty();
                }
            }
            ladderCounter += 1;
        }
        
        gameboard[player.Position.X][player.Position.Y].Current = player;
        gameboard[barrelSpawn.Position.X][barrelSpawn.Position.Y].Init = barrelSpawn;
        gameboard[flameSpawn.Position.X][flameSpawn.Position.Y].Init = flameSpawn;
    }

    public static Coordinates SetFlameSpawn()
    {
        return new Coordinates() { X = 8, Y = new Random().Next(25) };
    }

    public static Coordinates SetBarrelSpawn()
    {
        return new Coordinates() { X = 3, Y = new Random().Next(25) };
    }
}