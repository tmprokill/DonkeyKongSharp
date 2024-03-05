namespace ClassLib;

public class MovementHelper
{
    public static bool CheckAccessibility((int, int) values, Cell[][] gameBoard)
    {
        if (values.Item1 >= 0 && values.Item1 < gameBoard.Length && values.Item2 >= 0 && values.Item2 < gameBoard[0].Length)
        {
            return true;
        }

        return false;
    }
    public static bool CheckTransparity((int,int) values, Cell[][] gameBoard)
    {
        if (gameBoard[values.Item1][values.Item2].Init.Transparent != true)
        {
            return false;
        }

        return true;
    }

    public static void CheckTaken((int,int) values, Game gameBoard)
    {
        //End the game, проверка идёт по следующей позиции.
        if (gameBoard.FieldMatrix[values.Item1][values.Item2].Current != null)
        {
            gameBoard.Status = -1;
        }
    }
}