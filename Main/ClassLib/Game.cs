namespace ClassLib;

public class Game
{
    public int Status { get; set; } = 0;
    
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