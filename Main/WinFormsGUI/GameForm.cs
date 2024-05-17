using ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGUI
{
    public partial class GameForm : Form
    {
        private readonly string _login;

        private readonly MainForm _mainForm;

        private GameField _game;
        public GameForm(string login, MainForm form, GameField game)
        {
            InitializeComponent();
            _login = login;
            _mainForm = form;
            _game = game;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Show();
        }
    }
}
