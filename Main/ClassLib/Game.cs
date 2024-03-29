namespace ClassLib;

public class Game
{
    public int Status { get; set; } = 0;

    public int Difficulty { get; set; }

    public int Score { get; set; } = 0;
    
    public bool FlameRunning { get; set; } = true;

    public bool BarrelRunning { get; set; } = true;
    
    public Cell[][] FieldMatrix { get; set; }
    
    public int Length => FieldMatrix.Length; 
    
    public Cell[] this [int x]
    {
        get => FieldMatrix[x];
        set => FieldMatrix[x] = value;
    }
    
    public Cell this [int x, int y]
    {
        get => FieldMatrix[x][y];
        set => FieldMatrix[x][y] = value;
    }
}