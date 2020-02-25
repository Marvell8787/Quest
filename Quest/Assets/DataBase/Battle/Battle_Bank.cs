using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Battle_Bank{

    public static string[] C_Battle_Title = new string[2] { "Battle-1", "Battle-2" };
    public static string[] C_Battle_QuestionType = new string[2] { "字彙單選題", "字彙單選題"};
    public static string[] C_Battle_Range = new string[2] { "1-5", "1-10"};

    public static string[] Battle_Time = new string[2] { "5", "10"};
    public static string[] Battle_LP = new string[2] { "15", "20" };
    public static string[] Battle_Deck = new string[2] { "14","20" };

    //獎
    public static string[] C_Battle_Reward_0 = new string[2] { "水晶 +50", "水晶 +200" };
    public static string[] C_Battle_Reward_1 = new string[2] { "無", "無" };
    //懲
    public static string[] C_Battle_Punishment_0 = new string[2] { "水晶 -50", "水晶 -200" };
    public static string[] C_Battle_Punishment_1 = new string[2] {"無", "無" };

    //獎懲 int
    public static int[] Battle_Reward = new int[2] { 50, 200 };
    public static int[] Battle_Punishment = new int[2] { -50, -200 };
}
