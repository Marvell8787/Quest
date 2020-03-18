using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Behaviour_Bank{
    public static string GamingBehaviour = "G";
    public static string[] GamingBehaviour_Task = new string[9]{"GA","GAA","GAB","GAC","GAD","GAE","GAF","GAG","GAH"};
    public static string[] GamingBehaviour_Battle = new string[5] { "GB", "GBA", "GBB", "GBC", "GBD"};

    public static string LearningBehaviour = "L";
    public static string LearningBehaviour_Learn = "LA"; 
    public static string[] LearningBehaviour_Material = new string[4] { "LB", "LBA", "LBB", "LBC" };
    public static string[] LearningBehaviour_Level = new string[5] { "LC", "LCA", "LCB", "LCC", "LCD" };

    public static string SupportingBehaviour = "S";
    public static string[] SupportingBehaviour_Guide = new string[3] { "SA", "SAA", "SAB"};
    public static string[] SupportingBehaviour_Profile = new string[3] { "SB", "SBA", "SBB"};
    public static string[] SupportingBehaviour_Deck = new string[3] { "SC", "SCA", "SCB" };
    public static string[] SupportingBehaviour_Rank = new string[2] { "SD", "SDA"};
    public static string[] SupportingBehaviour_Badge = new string[3] { "SE", "SEA","SEB"};
    public static string[] SupportingBehaviour_Shop = new string[3] { "SF", "SFA", "SFB" };
}
