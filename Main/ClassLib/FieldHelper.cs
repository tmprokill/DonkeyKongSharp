namespace ClassLib;

public class FieldHelper
{
    //player
    public static void UpdateField(Game gameBoard, Player player, int lastX, int lastY)
    {
        gameBoard[player.Position.X][player.Position.Y].Current = player;
        gameBoard[lastX][lastY].Current = null;
    }
    
    //Flame
    public static void UpdateField(Game gameBoard, Flame enemy, int lastX, int lastY)
    {
        gameBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        gameBoard[lastX][lastY].Current = null;
    }
    //Cannon
    public static void UpdateField(Game gameBoard, Сannonball enemy, int lastX, int lastY)
    {
        gameBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        gameBoard[lastX][lastY].Current = null;
    }

    public static void RemoveEntity(Game gameBoard, Сannonball enemy)
    {
        gameBoard[enemy.Position.X][enemy.Position.Y].Current = null;
    }
}