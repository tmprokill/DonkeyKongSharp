using System.Text.Json;
using System.Text.Json.Nodes;
using ClassLib;

namespace FileWorkLib;

public static class StatsSaver
{
    private static void EnsureExists(string path)
    {
        if (!File.Exists(path)) 
        {
            using (File.Create(path)) {}

            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(new JsonObject());
            }
        }
    }
    
    public static void GetResults(string playerName)
    {
        var temp = Path.GetTempPath();
        const string name = "Stats.json";
        var path = Path.Combine(temp, name);
        
        EnsureExists(path);
        
        var result = new StatsModel(){Name = playerName};
        
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine("No data yet, Play at least once");
                return;
            }
            
            var models = JsonSerializer.Deserialize<Dictionary<string, StatsModel>>(json);
            
            foreach (var pair in models)
            {
                if (pair.Key == playerName)
                {
                    result = pair.Value;
                }
            }
        }
        
        Console.WriteLine($"{result.Name}'s Results:");
        Console.WriteLine($"High score is: {result.HighScore}");
        Console.WriteLine($"{result.LevelsPassed} Levels Passed");
        Console.WriteLine($"{result.PrizesCollected} Prizes Collected");
        Console.WriteLine($"{result.MovesCount} Moves Done");
        Console.WriteLine($"{result.LosesCount} Losses");
    }

    public static void UpdateStats(StatsModel model)
    {
        var temp = Path.GetTempPath();
        const string name = "Stats.json";
        var path = Path.Combine(temp, name);

        EnsureExists(path);

        var result = "";
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();

            var models = new Dictionary<string, StatsModel>();
            
            try
            {
                models = JsonSerializer.Deserialize<Dictionary<string, StatsModel>>(json);
            }
            catch(JsonException)
            {
            }
            
            var key = model.Name;
            if (models is not null && !models.TryAdd(key, model))
            {
                var existingModel = models[key];
                existingModel.LevelsPassed += model.LevelsPassed;
                existingModel.LosesCount += model.LosesCount;
                existingModel.MovesCount += model.MovesCount;
                existingModel.PrizesCollected += model.PrizesCollected;
                existingModel.HighScore = Math.Max(existingModel.HighScore, model.HighScore);
            }

            result = JsonSerializer.Serialize(models);
        }
        
        File.WriteAllText(path, result);
    }
}