using ClassLib;
using static System.Console;
namespace Main;

public class GameExecutor
{
    public void PrintMatrix(Cell[][] gameBoard)
    {
        SetCursorPosition(0,0);
        foreach (var t in gameBoard)
        {
            foreach (var f in t)
            {
                Write(f.Current != null ? $" {f.Current.Symbol} " : $" {f.Init.Symbol} ");
            }

            WriteLine();
        }
    }
}