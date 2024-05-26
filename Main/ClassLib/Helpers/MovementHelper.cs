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
                //Changed
                gameField.Status = GameStatus.Stopped;
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

    public static Coordinates GetShortestPath(GameField game, Coordinates target)
    {
        var current = game.Objects.Dog.Position;
        int stepX = 0;
        int stepY = 0;

        if (current.X < target.X && game[current.X + 1][current.Y].Init.Transparent)
        {
            stepX++;
        }
        else if (current.X > target.X && game[current.X - 1][current.Y].Init.Transparent)
        {
            stepX--;
        }
    
        if (current.Y < target.Y && game[current.X][current.Y + 1 ].Init.Transparent) 
        {
            stepY++;
        }
        else if (current.Y > target.Y && game[current.X][current.Y - 1].Init.Transparent) 
        {
            stepY--;
        }
    
        return new Coordinates { X = stepX, Y = stepY };
    }
}