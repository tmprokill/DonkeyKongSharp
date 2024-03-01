﻿using ClassLib;
using static System.Console;
namespace Main;

public class GameExecutor
{
    public void PrintMatrix(GameObject[][] gameBoard)
    {
        SetCursorPosition(0,0);
        foreach (var t in gameBoard)
        {
            foreach (var f in t)
            {
                Write($" {f.Symbol} ");
            }

            WriteLine();
        }
    }
}