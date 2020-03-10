using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Level_Bank
{
    public static string[] Level_Title = new string[5] { "Level-1", "Level-2", "Level-3", "Level-4", "Level-5" };
    public static string[] Level_QuestionType = new string[5] { "字彙聽力題", "聽力單選題", "字彙單選題", "句型單選題", "字彙拼字題" };
    public static string[] Level_Range = new string[5] { "字彙1-8", "字彙1-8、句型", "字彙1-8", "字彙1-8、句型", "字彙1-8" };
    //獎
    public static string[] Level_Reward_0 = new string[5] { "金幣 +10", "金幣 +50", "金幣 +10", "金幣 +50", "金幣 +100" };
    public static string[] Level_Reward_1 = new string[5] { "無", "無", "無", "無", "無" };
    //懲
    public static string[] Level_Punishment_0 = new string[5] { "金幣 -10、學習點數 -1、失誤 +1", "金幣 -50、學習點數 -1、失誤 +1", "金幣 -10、學習點數 -1、失誤 +1", "金幣 -50、學習點數 -1、失誤 +1", "金幣 -100、學習點數 -1、失誤 +1" };
    public static string[] Level_Punishment_1 = new string[5] { "無", "無", "無", "無", "無" };

    //獎懲數字
    public static int[] Level_Reward = new int[5] { 10, 50, 10, 50, 100 };
    public static int[] Level_Punishment = new int[5] { -10, -50, -10, -50, - 100 };
}
