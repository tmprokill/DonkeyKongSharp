using ClassLib.Enums;
using ClassLib;
using FileWorkLib;
using OutputLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Main
{
    public class UIGame
    {
        public static void InitThreads(GameField _game)
        {
            var flameThread = new Thread(() => Flame.Move(_game));
            var flameSpawnerThread = new Thread(() => BoneFire.Spawn(_game));
            var barrelSpawnerThread = new Thread(() => Cannon.Spawn(_game));
            var barrelThread = new Thread(() => СannonBall.Move(_game));
            var nextLevelThread = new Thread(() => LevelInitializeHelper.LevelListener(_game));
            var musicPlayerThread = new Thread(() => MusicPlayer.Play(_game));

            var threadList = new List<Thread>()
            {
                flameThread,
                flameSpawnerThread, barrelSpawnerThread,
                barrelThread,
                nextLevelThread, musicPlayerThread,
            };

            foreach (var item in threadList)
            {
                item.Start();
            }
        }

        public static GameField GenerateGame()
        {
            var game = new GameField();

            GenerateObjects(game);

            return game;
        }

        private static void GenerateObjects(GameField gameField)
        {
            var result = new GameObjects();

            var player = new Player();

            var boost = new CupCake();

            var exp = new ExpBooster();

            var health = new HealthBooster();

            var key = new Key();

            var flameEnemies = new ConcurrentBag<Flame>();
            var barrelEnemies = new ConcurrentBag<СannonBall>();

            var flameSpawner = new BoneFire();
            var barrelSpawnerList = new List<Cannon>();

            result.Player = player;
            result.FlameSpawner = flameSpawner;
            result.FlameEnemies = flameEnemies;
            result.BarrelEnemies = barrelEnemies;
            result.BarrelSpawners = barrelSpawnerList;
            result.CupCake = boost;
            result.ExpBooster = exp;
            result.HealthBooster = health;
            result.Key = key;

            gameField.Objects = result;

            LevelInitializeHelper.Invoke(25, gameField);
        }

        public static void Clear(GameField gameField)
        {
            Console.Clear();
            gameField.Objects.Player.LevelsPassed = default;
            gameField.Objects.Player.StepsAmount = default;
            gameField.Objects.Player.ItemsCollected = default;
            gameField.Objects.Player.Score = default;
            gameField.Objects.Player.Lives = 3;
            gameField.Status = 0;
            gameField.Difficulty = 0;
            gameField.Objects.BarrelEnemies.Clear();

            LevelInitializeHelper.ClearAndGenerate(gameField);
        }
    }
}
