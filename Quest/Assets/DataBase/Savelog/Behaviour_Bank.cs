using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Behaviour_Bank{
    public static string[] GameBehavior_Task = new string[9]{"GA","GAA","GAB","GAC","GAD","GAE","GAF","GAG","GAH"};
    public static string[] GameBehavior_Battle = new string[5] { "GB", "GBA", "GBB", "GBC", "GBD"};

    public static string LearnBehavior_Learn = "LA"; 
    public static string[] LearnBehavior_Material = new string[4] { "LB", "LBA", "LBB", "LBC" };
    public static string[] LearnBehavior_Level = new string[5] { "LC", "LCA", "LCB", "LCC", "LCD" };

    public static string[] SupportBehavior_Guide = new string[3] { "SA", "SAA", "SAB"};
    public static string[] SupportBehavior_Profile = new string[3] { "SB", "SBA", "SBB"};
    public static string[] SupportBehavior_Deck = new string[3] { "SC", "SCA", "SCB" };
    public static string[] SupportBehavior_Rank = new string[2] { "SD", "SDA"};
    public static string[] SupportBehavior_Badge = new string[2] { "SE", "SEA"};
    public static string[] SupportBehavior_Shop = new string[3] { "SF", "SFA", "SFB" };
}
