namespace ClassLib;

public class Field
{
    public char[][]? FieldMatrix { get; private set; }

    public void GenerateMatrixTemplate(int n)
    {
        var result = new char[n][];
        for (var i = 0; i < n; i++)
        {
            var row = new char[n];
            result[i] = row;
        }

        FieldMatrix = result;
    }
}