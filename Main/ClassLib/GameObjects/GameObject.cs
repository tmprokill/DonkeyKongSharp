namespace ClassLib;

public abstract class GameObject
{
    public abstract bool Transparent { get; set; }
    
    public abstract char Symbol { get;}
    
    public abstract ConsoleColor Color { get; set; }
}