namespace ClassLib;

public class Enemy : GameObject
{
    public string Direction { get; set; }
    
    public int Level { get; set; }
    
    public int HealPoints { get; set; }
    
    public override char Symbol { get;} = 'E';
}