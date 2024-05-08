using ClassLib.Enums;

namespace ClassLib;

public class MovementHelper
{
    public static bool CheckAccessibility((int, int) values, GameField gameFieldBoard)
    {
        if (values.Item1 >= 0 && values.Item1 < gameFieldBoard.Length && values.Item2 >= 0 && values.Item2 < gameFieldBoard[0].Length)
        {
            return true;
        }

        return false;
    }
    
    public static bool CheckTransparency((int,int) values, GameField gameFieldBoard)
    {
        if (gameFieldBoard[values.Item1][values.Item2].Init.Transparent != true)
        {
            return false;
        }

        return true;
    }
    
    public static bool CheckTaken((int, int) values, GameField gameField, Predicate<GameObject> expression)
    {
        var item = gameField.Field[values.Item1][values.Item2].Current;
        
        if (expression(item))
        {
            gameField.Objects.Player.Lives -= 1;
            if (gameField.Objects.Player.Lives == 0)
            {
                gameField.Status = GameStatus.Paused;
            }

            return true;
        }
        
        return false;
    }
    
    public static void CheckBoost((int, int) values, GameField gameField)
    {
        var item = gameField.Field[values.Item1][values.Item2].Init;

        switch (item)
        {
            case CupCake:
                CupCake.Action(values, gameField);
                break;
            case ExpBooster:
                ExpBooster.Action(values, gameField);
                break;
            case HealthBooster:
                HealthBooster.Action(values, gameField);
                break;
            case Key:
                Key.Action(values, gameField);
                break;
        }
    }
}