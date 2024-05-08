namespace ClassLib;

public class Level
{
    public double SpawnSpeed { get; set; } = 0.5;
    
    public double MovementSpeed { get; set; } = 1.0;
    
    private double _speedIncreaseFactor = 1.5; // Начальный коэффициент увеличения

    public static void IncreaseSpeed(GameField gameField)
    {
        if (gameField.Difficulty % 2 == 0)
        {
            gameField.LevelSettings.MovementSpeed *= gameField.LevelSettings._speedIncreaseFactor;
        }
        
        gameField.LevelSettings.SpawnSpeed *=  gameField.LevelSettings._speedIncreaseFactor;
        
        if (gameField.LevelSettings._speedIncreaseFactor > 1.1)
        {
            gameField.LevelSettings._speedIncreaseFactor -= 0.1;
        }
    }
}