using System.Text.RegularExpressions;

namespace FileWorkLib;

public class ResultKeeper
{
    public static int GetScore()
    {
        var temp = Path.GetTempPath();
        var name = "Scores.txt";
        var path = Path.Combine(temp, name);
        
        if (!File.Exists(path)) 
        {
            using (File.Create(path)) {} 
        }
        
        string line = "";
        
        try
        {
            var sr = new StreamReader(path);
            line = sr.ReadLine();
            sr.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
        
        if (!string.IsNullOrEmpty(line))
        {
            return MatchAndParse(line);
        }

        return -1;
    }

    public static void WriteScore(int score, string? playerName)
    {
        var temp = Path.GetTempPath();
        var name = "Scores.txt";
        var path = Path.Combine(temp, name);
        
        if (!File.Exists(path)) 
        {
            using (File.Create(path)) {} 
        }
        
        try
        {
            string existingContent = File.ReadAllText(path);

            string updatedContent = $"{playerName}: {score}" + Environment.NewLine + existingContent;

            File.WriteAllText(path, updatedContent);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
    
    public static int MatchAndParse(string line)
    {
        int result = 0;
        string value = line[line.IndexOf(':')..];
        var pattern = new Regex("^[0-9]+$");
        
        if (pattern.IsMatch(line))
        {
            int.TryParse(line, out result);
        }

        return result;
    }
}