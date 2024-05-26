using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGUI.UIHelpers;

namespace WinFormsGUI
{
    public partial class LoginForm : Form
    {
        private PrivateFontCollection _fontCollection;
        public LoginForm()
        {
            InitializeComponent();
            _fontCollection = FontInitializer.Initialize();
        }

        private void LoginBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Hide();
                MainForm mainForm = new MainForm(LoginBox.Text);
                mainForm.Show();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            FontInitializer.UpdateFont(Controls, _fontCollection);
        }     
    }
}
