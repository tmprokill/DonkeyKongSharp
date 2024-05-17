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
            NameLabel = new Label();
            LoginBox = new TextBox();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(168, 293);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(387, 56);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Log Into Your Account:";
            // 
            // LoginBox
            // 
            LoginBox.BackColor = Color.Maroon;
            LoginBox.BorderStyle = BorderStyle.None;
            LoginBox.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBox.Location = new Point(629, 292);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(378, 57);
            LoginBox.TabIndex = 1;
            LoginBox.KeyDown += LoginBox_KeyDown;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1182, 753);
            Controls.Add(LoginBox);
            Controls.Add(NameLabel);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            FormClosed += LoginForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        //Dont touch!
        private TextBox LoginBox;
    }
}