namespace ClassLib;

public class FieldHelper
{
    public void InitializeGameField(char[][] gameboard)
    {
        var rnd = new Random();
        for (int i = 0; i < gameboard.Length;i++)
        {
            for (var j = 0; j < gameboard.Length; j++)
            {
                if (i % 4 == 0)
                {
                    gameboard[i][j] = '#'; 
                }
                else
                {
                    gameboard[i][j] = '.';
                }
            }
        }
    }
    
    public void UpdateField(char[][] gameboard, Player player)
    {
        gameboard[player.Position.X][player.Position.Y] = 'P';
    }
}