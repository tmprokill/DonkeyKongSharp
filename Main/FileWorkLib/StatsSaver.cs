using System.Text.Json;
using System.Text.Json.Nodes;
using ClassLib;

namespace FileWorkLib;

public static class StatsSaver
{
    public static void GetResults(string playerName)
    {
        var temp = Path.GetTempPath();
        var name = "Stats.json";
        var path = Path.Combine(temp, name);
        
        
        if (!File.Exists(path)) 
        {
            using (File.Create(path)) {}

            using (StreamWriter w = new StreamWriter(path))
            {
                var obj = new JsonObject();
                w.Write(new JsonObject());
            }
        }
        
        var result = new StatsModel(){Name = playerName};
        
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            var models = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            
            foreach (var pair in models)
            {
                if (pair.Key == playerName)
                {
                    result = JsonSerializer.Deserialize<StatsModel>(pair.Value);
                }
            }
        }
        
        Console.WriteLine($"{result.Name}'s Results:");
        Console.WriteLine($"High score is: {result.HighScore}");
        Console.WriteLine($"{result.LevelsPassed} Levels passed");
        Console.WriteLine($"{result.PrizesCollected} Prizes Collected");
        Console.WriteLine($"{result.MovesCount}");
        Console.WriteLine($"{result.LosesCount}");
    }

    public static void UpdateStats(StatsModel model)
    {
        var temp = Path.GetTempPath();
        var name = "Stats.json";
        var path = Path.Combine(temp, name);

        if (!File.Exists(path)) 
        {
            using (File.Create(path)) {}

            using (StreamWriter w = new StreamWriter(path))
            {
                var obj = new JsonObject();
                w.Write(new JsonObject());
            }
        }

        var result = "";
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            var models = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            
            var key = model.Name;
            if (models.TryGetValue(key, out var value))
            {
                var item = JsonSerializer.Deserialize<StatsModel>(value);
            
                item.LevelsPassed += model.LevelsPassed;
                item.LosesCount += model.LosesCount;
                item.MovesCount += model.MovesCount;
                item.PrizesCollected += model.PrizesCollected;
                item.HighScore = item.HighScore > model.HighScore ? item.HighScore : model.HighScore;
                models[key] = JsonSerializer.Serialize(item);
            }
            else
            {
                models.Add(key, JsonSerializer.Serialize(model));
            }
            
            result = JsonSerializer.Serialize(models);
        }
        
        File.WriteAllText(path, result);
    }
}