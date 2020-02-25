using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Battle_Data {

    private static string[] Battle_Title = new string[2];
    private static string[] Battle_QuestionType = new string[2];
    private static string[] Battle_Range = new string[2];
    private static string[] Battle_Reward = new string[2];
    private static string[] Battle_Punishment = new string[2];
    private static string[] Battle_Time = new string[2];
    private static string[] Battle_LP = new string[2];
    private static string[] Battle_Deck = new string[2];

    private static Battle_Class[] battle_temp = new Battle_Class[3];

    public static void Battle_Init()
    {

        for (int i = 0; i < 2; i++)
        {
            Battle_Title[i] = Battle_Bank.C_Battle_Title[i];
            Battle_QuestionType[i] = Battle_Bank.C_Battle_QuestionType[i];
            Battle_Range[i] = Battle_Bank.C_Battle_Range[i];
        }

        switch (System_Data.Version)
        {
            case 0:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Battle_Bank.C_Battle_Reward_0[i];
                    Battle_Punishment[i] = Battle_Bank.C_Battle_Punishment_0[i];
                }
                break;
            case 1:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Battle_Bank.C_Battle_Reward_0[i];
                    Battle_Punishment[i] = Battle_Bank.C_Battle_Punishment_1[i];
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Battle_Bank.C_Battle_Reward_1[i];
                    Battle_Punishment[i] = Battle_Bank.C_Battle_Punishment_0[i];
                }
                break;
            case 3:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Battle_Bank.C_Battle_Reward_1[i];
                    Battle_Punishment[i] = Battle_Bank.C_Battle_Punishment_1[i];
                }
                break;
            default:
                break;
        }

        for (int i = 0; i<2; i++)
        {
            Battle_Time[i]= Battle_Bank.Battle_Time[i];
            Battle_LP[i] = Battle_Bank.Battle_LP[i];
            Battle_Deck[i] = Battle_Bank.Battle_Deck[i];
        }

        //宣告 Battle_temp 陣列並加入資料 Start
        for (int i = 0; i < 2; i++)
        {
            battle_temp[i] = new Battle_Class(Battle_Title[i], Battle_QuestionType[i], Battle_Range[i], Battle_Reward[i], Battle_Punishment[i], Battle_Time[i], Battle_LP[i], Battle_Deck[i]);
        }
        //宣告 Battle_temp 陣列並加入資料 End
        //Debug.Log(learn_temp[2].GetTitle());
    }
    public static Battle_Class Battle_Get(int n)
    {
        return battle_temp[n];
    }
}
