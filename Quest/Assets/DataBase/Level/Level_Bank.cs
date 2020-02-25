using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Level_Bank
{
    public static string[] C_Level_Title = new string[5] { "Level-1", "Level-2", "Level-3", "Level-4", "Level-5" };
    public static string[] C_Level_QuestionType = new string[5] { "聽力單選題", "聽力單選題", "字彙單選題", "字彙單選題", "字彙拼字題" };
    public static string[] C_Level_Range = new string[5] { "1-10", "1-10", "1-10", "1-10", "1-10" };
    //獎
    public static string[] C_Level_Reward_0 = new string[5] { "金幣 +10", "金幣 +50", "金幣 +10", "金幣 +50", "金幣 +100" };
    public static string[] C_Level_Reward_1 = new string[5] { "無", "無", "無", "無", "無" };
    //懲
    public static string[] C_Level_Punishment_0 = new string[5] { "金幣 -10", "金幣 -50", "金幣 -10", "金幣 -50", "金幣 -100" };
    public static string[] C_Level_Punishment_1 = new string[5] { "無", "無", "無", "無", "無" };

    //獎懲數字
    public static int[] Level_Reward = new int[5] { 10, 50, 10, 50, 100 };
    public static int[] Level_Punishment = new int[5] { -10, -50, -10, -50, - 100 };
}
