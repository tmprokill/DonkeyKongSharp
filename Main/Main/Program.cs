﻿using ClassLib;

namespace Main;

class Program
{
    static void Main(string[] args)
    {
        //initialization
        var player = new Player() { Position = new Coordinates() { X = 3, Y = 5 } };
        var gameFieldHelper = new FieldHelper();
        var movementHelper = new MovementHelper();
        var gameField = new Field();
        var gameExecutor = new GameExecutor();


        gameField.GenerateMatrixTemplate(25);

        gameFieldHelper.InitializeGameField(gameField.FieldMatrix);
        gameFieldHelper.UpdateField(gameField.FieldMatrix, player);

        gameExecutor.PrintMatrix(gameField.FieldMatrix);


        while (true)
        {
            var keyInfo = Console.ReadKey();

            movementHelper.HandleKeyPress(keyInfo.Key, player, gameField.FieldMatrix);
            gameFieldHelper.UpdateField(gameField.FieldMatrix, player);
            gameExecutor.PrintMatrix(gameField.FieldMatrix);
        }
    }
}