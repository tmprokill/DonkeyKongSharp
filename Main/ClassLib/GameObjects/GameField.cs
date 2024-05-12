using ClassLib.Enums;

namespace ClassLib;

public class GameField
{
    public GameStatus Status { get; set; }

    public int Difficulty { get; set; }
    
    public bool FlameRunning { get; set; } = true;

    public bool BarrelRunning { get; set; } = true;
    
    public Cell[][] Field { get; set; }
    
    public GameObjects Objects { get; set; }

    public Level LevelSettings { get; set; } = new Level();
    
    public int Length => Field.Length; 
    
    public Cell[] this [int x]
    {
        get => Field[x];
        set => Field[x] = value;
    }
    
    public Cell this [int x, int y]
    {
        get => Field[x][y];
        set => Field[x][y] = value;
    }
}