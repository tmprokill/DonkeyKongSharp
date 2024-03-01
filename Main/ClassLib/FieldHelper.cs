namespace ClassLib;

public class FieldHelper
{
    //придумать как сохранять в клетках прошлые значения и также понимать, когда будут стенки доступными для прохождения.
    public void InitializeGameField(GameObject[][] gameboard)
    {
        for (int i = 0; i < gameboard.Length; i++)
        {
            for (var j = 0; j < gameboard.Length; j++)
            {
                if (i % 4 == 0)
                {
                    gameboard[i][j] = new Wall(){Transparent = false};
                    if (j == 1 || j == 5 || j == 11 || j == 15)
                    {
                        ((Wall) gameboard[i][j]).Transparent = true;
                    }
                }
                else if (j == 1 || j == 5 || j == 11 || j == 15)
                {
                    gameboard[i][j] = new Ladder(); // Создаем лестницы от верхней до нижней границы
                }
                else
                {
                    gameboard[i][j] = new EmptyCell();
                }
            }
        }
    }
    
    public void UpdateField(GameObject[][] gameboard, Player player)
    {
        gameboard[player.Position.X][player.Position.Y] = player;
    }
}