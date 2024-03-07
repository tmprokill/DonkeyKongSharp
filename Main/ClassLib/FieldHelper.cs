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
    public static void UpdateField(Game gameBoard, EnemyFlame enemy, int lastX, int lastY)
    {
        gameBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        gameBoard[lastX][lastY].Current = null;
    }
    //Barrel
    public static void UpdateField(Game gameBoard, EnemyBarrel enemy, int lastX, int lastY)
    {
        gameBoard[enemy.Position.X][enemy.Position.Y].Current = enemy;
        gameBoard[lastX][lastY].Current = null;
    }

    public static void RemoveEntity(Game gameBoard, EnemyBarrel enemy)
    {
        gameBoard[enemy.Position.X][enemy.Position.Y].Current = null;
    }
}