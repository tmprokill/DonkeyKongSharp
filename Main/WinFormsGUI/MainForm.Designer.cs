namespace WinFormsGUI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        GameLabel = new Label();
        StatisticsButton = new PictureBox();
        InstructionsButton = new PictureBox();
        ExitButton = new PictureBox();
        StartButton = new PictureBox();
        MenuPanel = new Panel();
        TextPanel = new Panel();
        TextLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)StatisticsButton).BeginInit();
        ((System.ComponentModel.ISupportInitialize)InstructionsButton).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ExitButton).BeginInit();
        ((System.ComponentModel.ISupportInitialize)StartButton).BeginInit();
        MenuPanel.SuspendLayout();
        TextPanel.SuspendLayout();
        SuspendLayout();
        // 
        // GameLabel
        // 
        GameLabel.AutoSize = true;
        GameLabel.Font = new Font("Segoe Print", 16F);
        GameLabel.Location = new Point(646, 18);
        GameLabel.Name = "GameLabel";
        GameLabel.Size = new Size(352, 47);
        GameLabel.TabIndex = 0;
        GameLabel.Text = "Welcome to GoldRunner";
        // 
        // StatisticsButton
        // 
        StatisticsButton.Image = Properties.Resources.statistics_normal;
        StatisticsButton.Location = new Point(128, 387);
        StatisticsButton.Name = "StatisticsButton";
        StatisticsButton.Size = new Size(144, 76);
        StatisticsButton.SizeMode = PictureBoxSizeMode.StretchImage;
        StatisticsButton.TabIndex = 2;
        StatisticsButton.TabStop = false;
        StatisticsButton.Click += StatisticsButton_Click;
        StatisticsButton.MouseLeave += StatisticsButton_MouseLeave;
        StatisticsButton.MouseHover += StatisticsButton_MouseHover;
        // 
        // InstructionsButton
        // 
        InstructionsButton.Image = Properties.Resources.instructions_normal;
        InstructionsButton.Location = new Point(128, 277);
        InstructionsButton.Name = "InstructionsButton";
        InstructionsButton.Size = new Size(144, 76);
        InstructionsButton.SizeMode = PictureBoxSizeMode.StretchImage;
        InstructionsButton.TabIndex = 1;
        InstructionsButton.TabStop = false;
        InstructionsButton.Click += InstructionsButton_Click;
        InstructionsButton.MouseLeave += InstructionsButton_MouseLeave;
        InstructionsButton.MouseHover += InstructionsButton_MouseHover;
        // 
        // ExitButton
        // 
        ExitButton.Image = Properties.Resources.exit_normal;
        ExitButton.Location = new Point(128, 495);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new Size(144, 76);
        ExitButton.SizeMode = PictureBoxSizeMode.StretchImage;
        ExitButton.TabIndex = 3;
        ExitButton.TabStop = false;
        ExitButton.Click += ExitButton_Click;
        ExitButton.MouseLeave += ExitButton_MouseLeave;
        ExitButton.MouseHover += ExitButton_MouseHover;
        // 
        // StartButton
        // 
        StartButton.Image = Properties.Resources.start_normal;
        StartButton.Location = new Point(128, 164);
        StartButton.Name = "StartButton";
        StartButton.Size = new Size(144, 76);
        StartButton.SizeMode = PictureBoxSizeMode.StretchImage;
        StartButton.TabIndex = 0;
        StartButton.TabStop = false;
        StartButton.MouseLeave += StartButton_MouseLeave;
        StartButton.MouseHover += StartButton_MouseHover;
        // 
        // MenuPanel
        // 
        MenuPanel.BackgroundImage = Properties.Resources.menu;
        MenuPanel.BackgroundImageLayout = ImageLayout.Stretch;
        MenuPanel.Controls.Add(ExitButton);
        MenuPanel.Controls.Add(StartButton);
        MenuPanel.Controls.Add(StatisticsButton);
        MenuPanel.Controls.Add(InstructionsButton);
        MenuPanel.Location = new Point(31, 37);
        MenuPanel.Name = "MenuPanel";
        MenuPanel.Size = new Size(405, 660);
        MenuPanel.TabIndex = 5;
        // 
        // TextPanel
        // 
        TextPanel.Controls.Add(TextLabel);
        TextPanel.Location = new Point(462, 68);
        TextPanel.Name = "TextPanel";
        TextPanel.Size = new Size(700, 650);
        TextPanel.TabIndex = 6;
        // 
        // TextLabel
        // 
        TextLabel.AutoSize = true;
        TextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        TextLabel.Location = new Point(15, 15);
        TextLabel.Name = "TextLabel";
        TextLabel.Size = new Size(0, 28);
        TextLabel.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Maroon;
        ClientSize = new Size(1182, 753);
        Controls.Add(TextPanel);
        Controls.Add(MenuPanel);
        Controls.Add(GameLabel);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Main";
        ((System.ComponentModel.ISupportInitialize)StatisticsButton).EndInit();
        ((System.ComponentModel.ISupportInitialize)InstructionsButton).EndInit();
        ((System.ComponentModel.ISupportInitialize)ExitButton).EndInit();
        ((System.ComponentModel.ISupportInitialize)StartButton).EndInit();
        MenuPanel.ResumeLayout(false);
        TextPanel.ResumeLayout(false);
        TextPanel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label GameLabel;
    private PictureBox StartButton;
    private PictureBox StatisticsButton;
    private PictureBox InstructionsButton;
    private PictureBox ExitButton;
    private Panel MenuPanel;
    private Panel TextPanel;
    private Label TextLabel;
}