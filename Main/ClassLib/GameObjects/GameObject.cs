namespace ClassLib;

public abstract class GameObject
{
    public abstract bool Transparent { get; set; }
    
    public abstract string Image { get;}
    
    public abstract ConsoleColor Color { get; set; }
}