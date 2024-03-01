namespace ClassLib;

public class Field
{
    public GameObject[][] FieldMatrix { get; private set; }

    public void GenerateMatrixTemplate(int n)
    {
        var result = new GameObject[n][];
        for (var i = 0; i < n; i++)
        {
            var row = new GameObject[n];
            result[i] = row;
        }

        FieldMatrix = result;
    }
}