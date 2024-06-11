namespace ClassLib;

public class Key : GameObject
{
    public Coordinates Position { get; set; }

    public Coordinates Opens { get; set; }
    
    public override bool Transparent { get; set; } = true;
    
    public override string Image { get; } = "Key";
    
    public override ConsoleColor Color { get; set; } = ConsoleColor.White;

    public static void Action((int, int) values, GameField gameField)
    {
        var key = (Key) gameField.Field[values.Item1][values.Item2].Init;
        gameField.Field[key.Opens.X][key.Opens.Y].Init.Transparent = true;
        gameField.Field[values.Item1][values.Item2].Init = new Empty();
            
        gameField.Objects.Player.ItemsCollected += 1;
    }
}