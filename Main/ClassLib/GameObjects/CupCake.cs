namespace ClassLib;

public class CupCake : GameObject
{
    public Coordinates Position { get; set; }
    
    public override bool Transparent { get; set; } = true;
    
    public override string Image { get; } = "CupCake";

    public override ConsoleColor Color { get; set; } = ConsoleColor.Magenta;

    public static void Action((int, int) values, GameField gameField)
    {
        FreezeEnemies(gameField);
        gameField.Field[values.Item1][values.Item2].Init = new Empty();
        gameField.Objects.Player.ItemsCollected += 1;
    }
    
    private static void FreezeEnemies(GameField gameField)
    {
        gameField.FlameRunning = false;
        gameField.BarrelRunning = false;
    }
}