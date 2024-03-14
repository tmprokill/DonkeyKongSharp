namespace HelperLib;

public class MovementHelper
{
    public static bool CheckAccessibility((int, int) values, Game gameBoard)
    {
        if (values.Item1 >= 0 && values.Item1 < gameBoard.Length && values.Item2 >= 0 && values.Item2 < gameBoard[0].Length)
        {
            return true;
        }

        return false;
    }
    public static bool CheckTransparity((int,int) values, Game gameBoard)
    {
        if (gameBoard[values.Item1][values.Item2].Init.Transparent != true)
        {
            return false;
        }

        return true;
    }
    public static bool CheckBarrelDown(Game gameBoard, EnemyBarrel barrel)
    {
        if (barrel.Position.X + 1 == gameBoard.FieldMatrix.Length)
        {
            return false;
        }

        if (gameBoard.FieldMatrix[barrel.Position.X + 1][barrel.Position.Y].Init.Transparent)
        {
            return true;
        }

        return false;
    }
    public static void CheckTakenEnemy((int,int) values, Game gameBoard)
    {
        //End the game, проверка идёт по следующей позиции.
        var item = gameBoard.FieldMatrix[values.Item1][values.Item2].Current;
        if (item != null && item.Symbol == 'P')
        {
            gameBoard.Status = -1;
        }
    }
    public static void CheckTakenPlayer((int,int) values, Game gameBoard)
    {
        //End the game, проверка идёт по следующей позиции.
        var item = gameBoard.FieldMatrix[values.Item1][values.Item2].Current;
        if (item != null && item.Symbol is '*' or 'F')
        {
            gameBoard.Status = -1;
        }
    }
    
}