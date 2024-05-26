using ClassLib;
using ClassLib.Enums;

namespace WinFormsGUI.UIHelpers;

public class FormControlInitializeHelper
{
    public Label GenerateWinningLabel()
    {
        return new Label
        {
            AutoSize = true,
            Text = "CONGRATULATIONS, YOU'VE SET A NEW RECORD!!!",
            Font = new Font("Microsoft Sans Serif", 20),
            Location = new Point(200, 100)
        };
    }

    public Label GenerateResultLabel(GameField game)
    {
        return new Label
        {
            Text = GameFinishHelper.UpdateAndReturnStats(game),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 14),
            Location = new Point(800, 400)
        };
    }

    public Button GenerateResultButtonWithEvent(GameField game, MainForm mainForm, GameForm gameForm)
    {
        var button = new Button
        {
            Size = new Size(100, 150),
            Location = new Point(1050, 400),
            BackColor = Color.Maroon,
            Font = FontInitializer.GetFont(gameForm._fontColletion, 14),
            Text = "Finish the Game"
        };

        button.Click += (sender, e) => 
        {
            game.Status = GameStatus.Stopped;
            mainForm.Show();
            gameForm.Close();
        };

        return button;
    }
}