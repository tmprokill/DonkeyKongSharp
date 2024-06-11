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
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGUI.UIHelpers;

namespace WinFormsGUI
{
    public partial class GameForm : Form
    {
        private readonly string _login;

        private readonly MainForm _mainForm;

        private GameField _game;

        private UIGenerator _uiGenerator;

        public PrivateFontCollection _fontColletion;

        public GameForm(string login, MainForm form)
        {
            InitializeComponent();
            _login = login;
            _mainForm = form;
            _game = UIGame.GenerateGame();
            _uiGenerator = new UIGenerator();
            _fontColletion = FontInitializer.Initialize();
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            _game.Objects.Player.Name = _login;
            CreateSpriteGrid();
            UIGame.InitThreads(_game);
            FontInitializer.UpdateFont(Controls, _fontColletion);
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
            _uiGenerator.GenerateFieldUI(_game, this);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (_game.Status == GameStatus.Stopped)
            {
                GameStop();
            }
            
            _uiGenerator.UpdateFieldUI(_game, ScoreLabel, LivesLabel);
        }

        private void GameStop()
        {
            Controls.Clear();
                
            var fIh = new FormControlInitializeHelper();
            if (_game.Objects.Player.Score > ResultKeeper.GetScore())
            {
                Controls.Add(fIh.GenerateWinningLabel());
            }
                
            Controls.Add(fIh.GenerateResultLabel(_game));
            Controls.Add(fIh.GenerateResultButtonWithEvent(_game, _mainForm, this));
            GameTimer.Enabled = false;
        }
    }
}
