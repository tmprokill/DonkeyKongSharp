namespace ClassLib;

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
    
    public static bool CheckTakenEnemy((int,int) values, Game gameBoard, Player player)
    {
        //End the game, проверка идёт по следующей позиции.
        var item = gameBoard.FieldMatrix[values.Item1][values.Item2].Current;
        if (item != null && item.Symbol == 'P')
        {
            player.Lives -= 1;
            
            if (player.Lives == 0)
            {
                gameBoard.Status = -1;
            }

            return true;
        }
        return false;
    }
    
    public static bool CheckTakenPlayer((int,int) values, Game gameBoard, Player player)
    {
        //End the game, проверка идёт по следующей позиции.
        var item = gameBoard.FieldMatrix[values.Item1][values.Item2].Current;
        if (item != null && item.Symbol is '*' or 'F')
        {
            player.Lives -= 1;
            if (player.Lives == 0)
            {
                gameBoard.Status = -1;
            }

            return true;
        }

        return false;
    }

    public static void CheckBoost((int, int) values, Game gameBoard, Player player)
    {
        var item = gameBoard.FieldMatrix[values.Item1][values.Item2].Init;
        
        if (item != null && item.Symbol is 'C')
        {
            FreezeBarrels(gameBoard);
            FreezeFlames(gameBoard);
            gameBoard.FieldMatrix[values.Item1][values.Item2].Init = new Empty();
            gameBoard.ItemsCollected += 1;
        }
        else if (item != null && item.Symbol is 'E')
        {
            gameBoard.Score += 1000;
            gameBoard.FieldMatrix[values.Item1][values.Item2].Init = new Empty();
            gameBoard.ItemsCollected += 1;
        }
        else if (item != null && item.Symbol is 'H')
        {
            player.Lives += 1;
            gameBoard.FieldMatrix[values.Item1][values.Item2].Init = new Empty();
            gameBoard.ItemsCollected += 1;
        }
        
    }
    
    private static void FreezeFlames(Game game)
    {
        game.FlameRunning = false;
    }
    
    private static void FreezeBarrels(Game game)
    {
        game.BarrelRunning = false;
    }
}