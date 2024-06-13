namespace ClassLib;

public class ExpBooster : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = true;

    public override char Symbol { get; set; } = 'E';
    
    public override string Image { get; } = "Star";

    public override ConsoleColor Color { get; set; } = ConsoleColor.Yellow;

    public static void Action((int, int) values, GameField gameField)
    {
        gameField.Objects.Player.Score += 1000;
        gameField.Field[values.Item1][values.Item2].Init = new Empty();
        gameField.Objects.Player.ItemsCollected += 1;
    }
}