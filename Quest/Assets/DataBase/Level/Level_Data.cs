using System.Collections;
using System.Collections.Generic;
using UnityEngine;


static class Level_Data{

    private static string[] Level_Title = new string[5];
    private static string[] Level_QuestionType = new string[5];
    private static string[] Level_Range = new string[5];
    private static string[] Level_Reward = new string[5];
    private static string[] Level_Punishment = new string[5];

    private static string[] Level_HighestScore = new string[5]{ "0", "0", "0", "0", "0"};

    private static Level_Class[] level_temp = new Level_Class[5];

    public static void Level_Init()
    {

        for (int i = 0; i < 5; i++)
        {
            Level_Title[i] = Level_Bank.Level_Title[i];
            Level_QuestionType[i] = Level_Bank.Level_QuestionType[i];
            Level_Range[i] = Level_Bank.Level_Range[i];
        }

        switch (System_Data.Version)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    Level_Reward[i] = Level_Bank.Level_Reward_0[i];
                    Level_Punishment[i] = Level_Bank.Level_Punishment_0[i];
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    Level_Reward[i] = Level_Bank.Level_Reward_0[i];
                    Level_Punishment[i] = Level_Bank.Level_Punishment_1[i];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    Level_Reward[i] = Level_Bank.Level_Reward_1[i];
                    Level_Punishment[i] = Level_Bank.Level_Punishment_0[i];
                }
                break;
            case 3:
                for (int i = 0; i < 5; i++)
                {
                    Level_Reward[i] = Level_Bank.Level_Reward_1[i];
                    Level_Punishment[i] = Level_Bank.Level_Punishment_1[i];
                }
                break;
            default:
                break;
        }

        //宣告 level_temp 陣列並加入資料 Start
        for (int i = 0; i < 5; i++)
        {
            level_temp[i] = new Level_Class(Level_Title[i], Level_QuestionType[i], Level_Range[i], Level_Reward[i], Level_Punishment[i], Level_HighestScore[i]);
        }
        //宣告 level_temp 陣列並加入資料 End
        //Debug.Log(learn_temp[2].GetTitle());
    }
    public static Level_Class Level_Get(int n)
    {
        return level_temp[n];
    }
    public static int GetHighestScore(int n)
    {
        return int.Parse(level_temp[n].GetHighestScore());
    }
    public static void ChangeHighestScore(string s,int n)
    {
        level_temp[n].ChangeHighestScore(s);
    }

}
