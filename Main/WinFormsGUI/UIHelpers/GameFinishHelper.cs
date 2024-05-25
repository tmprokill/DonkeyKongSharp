using ClassLib;
using FileWorkLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGUI.UIHelpers
{
    public class GameFinishHelper
    {
        public static string UpdateAndReturnStats(GameField _game)
        {
            var result = new StatsModel()
            {
                Name = _game.Objects.Player.Name,
                MovesCount = _game.Objects.Player.StepsAmount,
                PrizesCollected = _game.Objects.Player.ItemsCollected,
                LevelsPassed = _game.Objects.Player.LevelsPassed,
                LosesCount = 1,
                HighScore = _game.Objects.Player.Score
            };

            StatsSaver.UpdateStats(result);
            
            if(ResultKeeper.GetScore() < result.HighScore) 
            {
                ResultKeeper.WriteScore(result.HighScore, result.Name);
            }

            return $"{result.Name}'s Results:" + "\n" +
              $"Score is: {result.HighScore}" + "\n" +
              $"{result.LevelsPassed} Levels Passed" + "\n" +
              $"{result.PrizesCollected} Prizes Collected" + "\n" +
              $"{result.MovesCount} Moves Done" + "\n" +
              $"{result.LosesCount} Losses";
        }

    }
}
