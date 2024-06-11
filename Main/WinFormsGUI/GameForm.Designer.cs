namespace WinFormsGUI
{
    partial class GameForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            LivesLabel = new Label();
            ScoreLabel = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // LivesLabel
            // 
            LivesLabel.AutoSize = true;
            LivesLabel.Font = new Font("Sans Serif Collection", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LivesLabel.Location = new Point(1286, 106);
            LivesLabel.Name = "LivesLabel";
            LivesLabel.Size = new Size(300, 68);
            LivesLabel.TabIndex = 0;
            LivesLabel.Text = "Player Lives:";
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new Font("Sans Serif Collection", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScoreLabel.Location = new Point(1286, 233);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(312, 68);
            ScoreLabel.TabIndex = 1;
            ScoreLabel.Text = "Player Score:";
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 7;
            GameTimer.Tick += GameTimer_Tick;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1902, 1033);
            Controls.Add(ScoreLabel);
            Controls.Add(LivesLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            FormClosed += GameForm_FormClosed;
            Load += GameForm_Load;
            KeyDown += GameForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LivesLabel;
        private Label ScoreLabel;
        private System.Windows.Forms.Timer GameTimer;
    }
}