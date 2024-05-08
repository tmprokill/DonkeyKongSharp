namespace FileWorkLib;

public class TemplateGetter
{
    public static string GetGeneric(string first, string second, string third)
    {
        return "#############################" + Environment.NewLine +
               $"#         {first}           #" + Environment.NewLine +
               $"#        {second}           #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               $"#  *    {third}         *   #" + Environment.NewLine +
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
        return "#############################" + Environment.NewLine +
               "#         Welcome to        #" + Environment.NewLine +
               "#     The DonkeyKong Game   #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               "#  *    Play with Us     *  #" + Environment.NewLine +
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

    public static string GetOptions()
    {
        return "#############################" + Environment.NewLine +
               "#         Welcome to        #" + Environment.NewLine +
               "#     The DonkeyKong Game   #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               "#  *   Loading Options   *  #" + Environment.NewLine +
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
    
    public static string GetExit()
    {
        return "#############################" + Environment.NewLine +
               "#         Bye Bye!          #" + Environment.NewLine +
               "#     See You next time!    #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               "#  *   Exit in process   *  #" + Environment.NewLine +
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

    public static string GetWin()
    {
        return "#############################" + Environment.NewLine +
               "#         Bye Bye!          #" + Environment.NewLine +
               "#     See You next time!    #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *    You've set     *   #" + Environment.NewLine +
               "#  *     NEW RECORD      *  #" + Environment.NewLine +
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
    
    public static string GetLose()
    {
        return "#############################" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               "#  *   You've lost....   *  #" + Environment.NewLine +
               "#   *                   *   #" + Environment.NewLine +
               "#    *******************    #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#   ^__^                    #" + Environment.NewLine + 
              @"# (oo)\\_______             #" + Environment.NewLine +
              @"# (__)\\       )\\/\\       #" + Environment.NewLine +
               "#      ||----w |            #" + Environment.NewLine +
               "#      ||     ||            #" + Environment.NewLine +
               "#                           #" + Environment.NewLine +
               "#    Loading...             #" + Environment.NewLine +
               "#############################";
    }
}