using ClassLib;

namespace Main;

internal class Program
{
    
    internal static void Main(string[] args)
    {
        //initialization
        var player = new Player() { Position = new Coordinates() { X = 23, Y = 1 } };
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