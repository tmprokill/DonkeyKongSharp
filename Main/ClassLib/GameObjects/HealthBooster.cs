namespace ClassLib;

public class HealthBooster : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = true;

    public override char Symbol { get; set; } = 'H';
    
    public override string Image { get; } = "HealthBooster";
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.Red;

    public static void Action((int,int) values, GameField gameField)
    {
        gameField.Objects.Player.Lives += 1;
        gameField.Field[values.Item1][values.Item2].Init = new Empty();
        gameField.Objects.Player.ItemsCollected += 1;
    }
}