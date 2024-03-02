namespace ClassLib;

public class Field
{
    public Cell[][] FieldMatrix { get; private set; }

    public void GenerateMatrixTemplate(int n)
    {
        var result = new Cell[n][];
        for (var i = 0; i < n; i++)
        {
            var row = new Cell[n];
            result[i] = row;
        }

        FieldMatrix = result;
    }
}