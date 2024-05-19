using ClassLib.Enums;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGUI.UIHelpers
{
    internal class FormKeyPressHelper
    {
        internal static void HandleKeyPress(KeyEventArgs key, GameField gameField)
        {
            switch (key.KeyCode)
            {
                case Keys.W:
                    Player.MovePlayer(new Coordinates() { X = -1, Y = 0 }, gameField.Objects.Player, gameField);
                    break;
                case Keys.S:
                    Player.MovePlayer(new Coordinates() { X = 1, Y = 0 }, gameField.Objects.Player, gameField);
                    break;
                case Keys.D:
                    Player.MovePlayer(new Coordinates() { X = 0, Y = 1 }, gameField.Objects.Player, gameField);
                    break;
                case Keys.A:
                    Player.MovePlayer(new Coordinates() { X = 0, Y = -1 }, gameField.Objects.Player, gameField);
                    break;
                case Keys.Escape:
                    gameField.Status = GameStatus.Stopped;
                    break;
            }

            //To CollectStatistics
            gameField.Objects.Player.StepsAmount += 1;
        }
    }
}
