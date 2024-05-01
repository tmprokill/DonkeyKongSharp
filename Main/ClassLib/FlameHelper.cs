namespace ClassLib;

public class FlameHelper
{
    private readonly Dictionary<int, Coordinates> _directions = new Dictionary<int, Coordinates>()
    {
        {0, new Coordinates(){X = -1, Y = 0}},
        {1, new Coordinates(){X = 1, Y = 0}},
        {2, new Coordinates(){X = 0, Y = -1}},
        {3, new Coordinates(){X = 0, Y = 1}},
    };

    public Coordinates GetRandomDirection(Coordinates last)
    {
        var rnd = _directions[new Random().Next(0,4)];
        //проверка на возвращение на предыдущую клетку.
        while (rnd.X == -1 * last.X && rnd.Y == -1 * last.Y)
        {
            rnd = _directions[new Random().Next(0,4)];
        }

        //обновление последнего перемещения
        last.X = rnd.X;
        last.Y = rnd.Y;
        
        return rnd;
    }
}