namespace FileWorkLib;

public class TemplateGetter
{
    private static string GetFormattedMessage(string content)
    {
        int spaces = 29 - content.Length;
        int padleft = spaces / 2;

        string paddedContent = content.PadLeft(padleft).PadRight(16);
        
        return "#############################" + Environment.NewLine +
               "#         Welcome to        #" + Environment.NewLine +
               "#     The DonkeyKong Game   #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               $"# *   {paddedContent}   *  #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#   ^__^                    #" + Environment.NewLine +
               @"#  (oo)\\_______            #" + Environment.NewLine +
               @"#  (__)\\       )\\/\\      #" + Environment.NewLine +
               "#      ||----w |            #" + Environment.NewLine +
               "#      ||     ||            #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    Loading...             #" + Environment.NewLine +
               "#############################";
    }
    public static string GetLoading()
    {
        return GetFormattedMessage("Loading");
    }

    public static string GetOptions()
    {
        return GetFormattedMessage("Options");
    }
    
    public static string GetExit()
    {
        return GetFormattedMessage("Exit in process");
    }

    public static string GetWin()
    {
        return GetFormattedMessage("NEW RECORD");
    }
    
    public static string GetLose()
    {
        return GetFormattedMessage("You've lost...");
    }
}