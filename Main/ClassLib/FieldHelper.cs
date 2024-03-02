namespace ClassLib;

public class FieldHelper
{
    //придумать как сохранять в клетках прошлые значения и также понимать, когда будут стенки доступными для прохождения.
    public void InitializeGameField(Cell[][] gameboard)
    {
        for (int i = 0; i < gameboard.Length; i++)
        {
            for (var j = 0; j < gameboard.Length; j++)
            {
                gameboard[i][j] = new Cell();
                if (i % 4 == 0)
                {
                    gameboard[i][j].Init = new Wall();
                    if (j == 1 || j == 5 || j == 11 || j == 15)
                    {
                        gameboard[i][j].Init.Transparent = true;
                    }
                }
                else if (j == 1 || j == 5 || j == 11 || j == 15)
                {
                    gameboard[i][j].Init = new Ladder(); // Создаем лестницы от верхней до нижней границы
                }
                else
                {
                    gameboard[i][j].Init = new Empty();
                }
            }
        }
    }
    
    public void UpdateField(Cell[][] gameboard, Player player)
    {
        gameboard[player.Position.X][player.Position.Y].Current = player;
    }
}