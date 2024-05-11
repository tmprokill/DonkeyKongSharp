namespace ClassLib;

public class Coordinates
{
    public int X { get; set; }
    
    public int Y { get; set; }

    public Coordinates()
    {
        
    }
    public Coordinates(Coordinates coordinates)
    {
        X = coordinates.X;
        Y = coordinates.Y;
    }
}