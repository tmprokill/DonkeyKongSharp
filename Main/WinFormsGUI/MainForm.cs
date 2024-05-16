using FileWorkLib;

namespace WinFormsGUI;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void StartButton_MouseHover(object sender, EventArgs e)
    {
        StartButton.Image = Properties.Resources.start_hover;
    }

    private void StartButton_MouseLeave(object sender, EventArgs e)
    {
        StartButton.Image = Properties.Resources.start_normal;
    }

    private void StatisticsButton_MouseHover(object sender, EventArgs e)
    {
        StatisticsButton.Image = Properties.Resources.statistics_hover;
    }

    private void StatisticsButton_MouseLeave(object sender, EventArgs e)
    {
        StatisticsButton.Image = Properties.Resources.statistics_normal;
    }

    private void InstructionsButton_MouseHover(object sender, EventArgs e)
    {
        InstructionsButton.Image = Properties.Resources.instructions_hover;
    }

    private void InstructionsButton_MouseLeave(object sender, EventArgs e)
    {
        InstructionsButton.Image = Properties.Resources.instructions_normal;
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void ExitButton_MouseHover(object sender, EventArgs e)
    {
        ExitButton.Image = Properties.Resources.exit_hover;
    }

    private void ExitButton_MouseLeave(object sender, EventArgs e)
    {
        ExitButton.Image = Properties.Resources.exit_normal;
    }

    private void StatisticsButton_Click(object sender, EventArgs e)
    {
        TextPanel.AutoScroll = false;
        TextLabel.Location = new Point(200, 200);
        TextLabel.Text = StatsSaver.GetResults("Skibidi");
    }

    private void InstructionsButton_Click(object sender, EventArgs e)
    {
        TextPanel.AutoScroll = false;
        TextLabel.Location = new Point(0, 0);
        TextLabel.Text = InstructionsGetter.GetInstructions();
        TextLabel.MaximumSize = new Size(640, 0);
        TextPanel.AutoScroll = true;
    }
}