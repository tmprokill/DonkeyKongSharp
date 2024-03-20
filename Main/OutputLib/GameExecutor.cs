﻿using static System.Console;
using ClassLib;

namespace OutputLib;

public class GameExecutor
{
    public void PrintMatrix(Game gameBoard, Player player)
    {
        
        SetCursorPosition(0,0);
        foreach (var t in gameBoard.FieldMatrix)
        {
            foreach (var f in t)
            {
                //без двойной проверки наворачивается.
                ForegroundColor = f.Current != null ? f.Current.Color : f.Init.Color;
                
                //Escape console 
                Write("\x1b[?25l");
                Write(f.Current != null ? $" {f.Current.Symbol} " : $" {f.Init.Symbol} ");
                
                ForegroundColor = default;
            }
            
            WriteLine();
        }
        
        WriteLine($"Player Lives: {player.Lives}");
        WriteLine($"Score: {gameBoard.Score}");
    }
}