namespace ClassLib;

public class FieldHelper
{
    //player
    public static void UpdateField(GameField gameFieldBoard, Player player, int lastX, int lastY)
    {
        gameFieldBoard[player.Position.X][player.Position.Y].Current = player;
        gameFieldBoard[lastX][lastY].Current = null;
    }
    //Flame
    public static void UpdateField(GameField gameFieldBoard, Flame enemy, int lastX, int lastY)
    {
        gameFieldBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        gameFieldBoard[lastX][lastY].Current = null;
    }
    //Cannon
    public static void UpdateField(GameField gameFieldBoard, СannonBall enemy, int lastX, int lastY)
    {
        gameFieldBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        gameFieldBoard[lastX][lastY].Current = null;
    }
    //Dog
    public static void UpdateField(GameField gameFieldBoard, Dog enemy, int lastX, int lastY)
    {
        gameFieldBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        if (enemy.Position.X != lastX || enemy.Position.Y != lastY)
        {
            gameFieldBoard[lastX][lastY].Current = null;
        }
        
    }
    public static void RemoveEntity(GameField gameFieldBoard, СannonBall enemy)
    {
        gameFieldBoard[enemy.Position.X][enemy.Position.Y].Current = null;
    }
}