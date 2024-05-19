using ClassLib;
using ClassLib.Enums;
using FileWorkLib;
using Main;
using OutputLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGUI.UIHelpers;

namespace WinFormsGUI
{
    public partial class GameForm : Form
    {
        private TableLayoutPanel tableLayoutPanel;

        private Dictionary<string, Bitmap> spriteDictionary;

        private readonly string _login;

        private readonly MainForm _mainForm;

        private GameField _game;

        public GameForm(string login, MainForm form)
        {
            InitializeComponent();
            spriteDictionary = LoadSprites();
            _login = login;
            _mainForm = form;
            _game = UIGame.GenerateGame();
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
                { "Door_Opened", Properties.Resources.Door_Opened }
            };
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            _game.Objects.Player.Name = _login;
            CreateSpriteGrid();
            UIGame.InitThreads(_game);
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _game.Status = GameStatus.Stopped;
            _mainForm.Show();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            FormKeyPressHelper.HandleKeyPress(e, _game);
        }

        private void CreateSpriteGrid()
        {
            const int cellSize = 30; // Размер каждого спрайта

            // Создаем TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = _game.Field.Length + 1,
                ColumnCount = _game.Field[0].Length + 1,
            };

            // Устанавливаем размеры строк и столбцов
            for (int i = 0; i < _game.Field.Length; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize + 8));
            }

            // Добавляем PictureBox в каждую ячейку
            for (int row = 0; row < _game.Field.Length; row++)
            {
                for (int col = 0; col < _game.Field[row].Length; col++)
                {
                    var currentObject = _game.Field[row][col].Current ?? _game.Field[row][col].Init;
                    var pictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackgroundImage = Properties.Resources.BackGround,
                        Image = spriteDictionary[currentObject.Image],
                        Dock = DockStyle.Fill
                    };
                    tableLayoutPanel.Controls.Add(pictureBox, col, row);
                }
            }

            Controls.Add(tableLayoutPanel);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (_game.Status == GameStatus.Stopped)
            {
                Controls.Clear();
                if (_game.Objects.Player.Score > ResultKeeper.GetScore())
                {
                    var winLabel = new Label
                    {
                        AutoSize = true,
                        Text = "CONGRATULATIONS, YOU'VE SET A NEW RECORD!!!",
                        Font = new Font("Microsoft Sans Serif", 20),
                        Location = new Point(200, 100)
                    };
                    Controls.Add(winLabel);
                }
                var label = new Label
                {
                    Text = GameFinisher.UpdateAndReturnStats(_game),
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 14),
                    Location = new Point(350, 300)
                };

                var button = new Button
                {
                    Size = new Size(100, 100),
                    Location = new Point(650, 300),
                    BackColor = Color.Maroon,
                    Font = new Font("Microsoft Sans Serif", 14),
                    Text = "Finish the Game",
                };

                button.Click += (sender, e) => 
                {
                    _game.Status = GameStatus.Stopped;
                    _mainForm.Show();
                    Close();
                };
                
                    
                Controls.Add(label);
                Controls.Add(button);
                GameTimer.Enabled = false;
            }

            for (int row = 0; row < _game.Field.Length; row++)
            {
                for (int col = 0; col < _game.Field[row].Length; col++)
                {
                    // Найдем текущий PictureBox по позиции в TableLayoutPanel
                    var pictureBox = (PictureBox) tableLayoutPanel.GetControlFromPosition(col, row);
                    if (pictureBox != null)
                    {
                        var currentObject = _game.Field[row][col].Current ?? _game.Field[row][col].Init;
                        pictureBox.Image = spriteDictionary[currentObject.Image];
                    }
                }
            }

            ScoreLabel.Text = _game.Objects.Player.Name + " Score: " + _game.Objects.Player.Score;
            LivesLabel.Text = _game.Objects.Player.Name + " Lives: " + _game.Objects.Player.Lives.ToString();
        }
    }
}
