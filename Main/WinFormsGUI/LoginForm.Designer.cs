namespace WinFormsGUI
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            NameLabel = new Label();
            LoginBox = new TextBox();
            WelcomeLabel = new Label();
            HelpLabel = new Label();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Sans Serif Collection", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(429, 368);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(777, 82);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "LOG INTO YOUR ACCOUNT";
            // 
            // LoginBox
            // 
            LoginBox.BackColor = Color.Maroon;
            LoginBox.BorderStyle = BorderStyle.None;
            LoginBox.Font = new Font("Sans Serif Collection", 19.7999973F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBox.Location = new Point(961, 368);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(378, 82);
            LoginBox.TabIndex = 1;
            LoginBox.KeyDown += LoginBox_KeyDown;
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.Font = new Font("Sans Serif Collection", 23.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            WelcomeLabel.Location = new Point(675, 240);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(1188, 99);
            WelcomeLabel.TabIndex = 2;
            WelcomeLabel.Text = "WELCOME TO THE GOLD RUNNER";
            // 
            // HelpLabel
            // 
            HelpLabel.AutoSize = true;
            HelpLabel.Font = new Font("Segoe UI", 12F);
            HelpLabel.Location = new Point(779, 528);
            HelpLabel.Name = "HelpLabel";
            HelpLabel.Size = new Size(366, 28);
            HelpLabel.TabIndex = 3;
            HelpLabel.Text = "TYPE IN YOUR NAME AND PLACE ENTER";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1902, 1033);
            Controls.Add(HelpLabel);
            Controls.Add(WelcomeLabel);
            Controls.Add(LoginBox);
            Controls.Add(NameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            FormClosed += LoginForm_FormClosed;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        //Dont touch!
        private TextBox LoginBox;
        private Label WelcomeLabel;
        private Label HelpLabel;
    }
}