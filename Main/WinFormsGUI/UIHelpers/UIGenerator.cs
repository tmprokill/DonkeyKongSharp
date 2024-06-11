using ClassLib;

namespace WinFormsGUI.UIHelpers
{
    public class UIGenerator
    {
        private TableLayoutPanel tableLayoutPanel;
        
        private Dictionary<string, Bitmap> _spriteDictionary;
        
        public UIGenerator()
        {
            _spriteDictionary = LoadSprites();
        }

        public void GenerateFieldUI(GameField game, GameForm form)
        {
            const int cellSize = 41; // Размер каждого спрайта

            // Создаем TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = game.Field.Length + 1,
                ColumnCount = game.Field[0].Length + 1,
            };

            // Устанавливаем размеры строк и столбцов
            for (int i = 0; i < game.Field.Length; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize + 8));
            }

            // Добавляем PictureBox в каждую ячейку
            for (int row = 0; row < game.Field.Length; row++)
            {
                for (int col = 0; col < game.Field[row].Length; col++)
                {
                    var currentObject = game.Field[row][col].Current ?? game.Field[row][col].Init;
                    var pictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackgroundImage = Properties.Resources.BackGround,
                        Image = _spriteDictionary[currentObject.Image],
                        Dock = DockStyle.Fill
                    };
                    tableLayoutPanel.Controls.Add(pictureBox, col, row);
                }
            }

            form.Controls.Add(tableLayoutPanel);
        }
        
        public void UpdateFieldUI(GameField game, Label scoreLabel, Label liveLabel)
        {
            for (int row = 0; row < game.Field.Length; row++)
            {
                for (int col = 0; col < game.Field[row].Length; col++)
                {
                    // Найдем текущий PictureBox по позиции в TableLayoutPanel
                    var pictureBox = (PictureBox) tableLayoutPanel.GetControlFromPosition(col, row);
                    if (pictureBox != null)
                    {
                        var currentObject = game.Field[row][col].Current ?? game.Field[row][col].Init;
                        pictureBox.Image = _spriteDictionary[currentObject.Image];
                    }
                }
            }
            
            scoreLabel.Text = game.Objects.Player.Name + "'s Score: " + game.Objects.Player.Score;
            liveLabel.Text = game.Objects.Player.Name + "'s Lives: " + game.Objects.Player.Lives;
        }

        private Dictionary<string, Bitmap> LoadSprites()
        {
            return new Dictionary<string, Bitmap>
            {
                { "Wall", Properties.Resources.Wall },
                { "Door_Closed", Properties.Resources.Door_Closed },
                { "Flame", Properties.Resources.Flame },
                { "BoneFire", Properties.Resources.BoneFire },
                { "Cannon_Left", Properties.Resources.Cannon_Left },
                { "Cannon_Right", Properties.Resources.Cannon_Right },
                { "CannonBall", Properties.Resources.Cannonball },
                { "Key", Properties.Resources.Key },
                { "HealthBooster", Properties.Resources.HealthBooster },
                { "Star", Properties.Resources.Star },
                { "CupCake", Properties.Resources.CupCake },
                { "Player_Left", Properties.Resources.Player_Left },
                { "Player_Right", Properties.Resources.Player_Right },
                { "BackGround", Properties.Resources.BackGround },
                { "Door_Opened", Properties.Resources.Door_Opened },
                { "AngryDogRight", Properties.Resources.AngryDogRight},
                { "AngryDogLeft", Properties.Resources.AngryDogLeft},
                { "CalmDogRight", Properties.Resources.CalmDogRight},
                { "CalmDogLeft", Properties.Resources.CalmDogLeft}
            };
        }
    }
}
