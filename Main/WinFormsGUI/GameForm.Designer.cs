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
            LoginLabel = new Label();
            ScoreBox = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // LoginLabel
            // 
            LoginLabel.AutoSize = true;
            LoginLabel.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginLabel.Location = new Point(943, 9);
            LoginLabel.Name = "LoginLabel";
            LoginLabel.Size = new Size(0, 37);
            LoginLabel.TabIndex = 0;
            // 
            // ScoreBox
            // 
            ScoreBox.AutoSize = true;
            ScoreBox.Font = new Font("Sans Serif Collection", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ScoreBox.Location = new Point(943, 46);
            ScoreBox.Name = "ScoreBox";
            ScoreBox.Size = new Size(0, 37);
            ScoreBox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(700, 700);
            dataGridView1.TabIndex = 2;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(1182, 753);
            Controls.Add(dataGridView1);
            Controls.Add(ScoreBox);
            Controls.Add(LoginLabel);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameForm";
            FormClosed += GameForm_FormClosed;
            Load += GameForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LoginLabel;
        private Label ScoreBox;
        private DataGridView dataGridView1;
    }
}