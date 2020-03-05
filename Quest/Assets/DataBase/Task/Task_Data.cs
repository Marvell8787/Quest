using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Task_Data{
    public static int[] Learn_Request_Score = new int[5] { 0, 0, 0, 0, 0 };
    public static int[] Task_Reward = new int[5] { 0, 0, 0, 0, 0 };
    public static int[] Task_Punishment = new int[5] { 0, 0, 0, 0, 0 };

    private static string[] Learn_Title = new string[5] { "", "", "", "", "" };
    private static string[] Learn_Request = new string[5] { "", "", "", "", "" };
    private static string[] Learn_Reward = new string[5] { "", "", "", "", "" };
    private static string[] Learn_Punishment = new string[5] { "", "", "", "", "" };

    private static int[] Learn_Status = new int[5] { 1, 1, 1, 1, 1};

    private static string[] Battle_Title = new string[2] { "", ""};
    private static string[] Battle_Request = new string[2] { "", ""};
    private static string[] Battle_Reward = new string[2] { "", ""};
    private static string[] Battle_Punishment = new string[2] { "", ""};

    private static int[] Battle_Status = new int[2] { 1, 1};


    private static Task_Class[] learn_temp = new Task_Class[5];
    private static Task_Class[] battle_temp = new Task_Class[2];

    public static void Task_Init()
    {
        for (int i = 0; i < 5; i++)
        {
            Learn_Title[i] = Task_Bank.Learn_Title[i];
            Learn_Request[i] = Task_Bank.Learn_Request[i];
            Learn_Status[i] = Task_Bank.Learn_Status[i];
        }
        switch (System_Data.Version)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    Learn_Reward[i] = Task_Bank.Learn_Reward_O[i];
                    Learn_Punishment[i] = Task_Bank.Learn_Punishment_O[i];
                }
                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    Learn_Reward[i] = Task_Bank.Learn_Reward_O[i];
                    Learn_Punishment[i] = Task_Bank.Learn_Punishment_X[i];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    Learn_Reward[i] = Task_Bank.Learn_Reward_X[i];
                    Learn_Punishment[i] = Task_Bank.Learn_Punishment_O[i];
                }
                break;
            case 3:
                for (int i = 0; i < 5; i++)
                {
                    Learn_Reward[i] = Task_Bank.Learn_Reward_X[i];
                    Learn_Punishment[i] = Task_Bank.Learn_Punishment_X[i];
                }
                break;
            default:
                break;
        }
        for (int i = 0; i < 2; i++)
        {
            Battle_Title[i] = Task_Bank.Battle_Title[i];
            Battle_Request[i] = Task_Bank.Battle_Request[i];
            Battle_Status[i] = Task_Bank.Battle_Status[i];
        }
        switch (System_Data.Version)
        {
            case 0:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Task_Bank.Battle_Reward_O[i];
                    Battle_Punishment[i] = Task_Bank.Battle_Punishment_O[i];
                }
                break;
            case 1:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Task_Bank.Battle_Reward_O[i];
                    Battle_Punishment[i] = Task_Bank.Battle_Punishment_X[i];
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Task_Bank.Battle_Reward_X[i];
                    Battle_Punishment[i] = Task_Bank.Battle_Punishment_O[i];
                }
                break;
            case 3:
                for (int i = 0; i < 2; i++)
                {
                    Battle_Reward[i] = Task_Bank.Battle_Reward_X[i];
                    Battle_Punishment[i] = Task_Bank.Battle_Punishment_X[i];
                }
                break;
            default:
                break;
        }


        //宣告 learn_temp 陣列並加入資料 Start
        for (int i = 0; i < 5; i++)
        {
            learn_temp[i] = new Task_Class(Learn_Title[i], Learn_Request[i], Learn_Reward[i], Learn_Punishment[i], Learn_Status[i]);
        }
        //宣告 learn_temp 陣列並加入資料 End
        //宣告 battle_temp 陣列並加入資料 Start

        for (int i = 0; i < 2; i++)
        {
            battle_temp[i] = new Task_Class(Battle_Title[i], Battle_Request[i], Battle_Reward[i], Battle_Punishment[i], Battle_Status[i]);
        }
        //宣告 battle_temp 陣列並加入資料 End
    }
    public static Task_Class Learn_Get(int n)
    {
        return learn_temp[n];
    }
    public static Task_Class Battle_Get(int n)
    {
        return battle_temp[n];
    }
    public static int GetStatus(string s, int c) //learn battle 陣列元素 參數
    {
        if (s == "learn")
        {
            return Learn_Status[c];
        }
        else
        {
            return Battle_Status[c];
        }

    }
    public static void ChangeStatus(string s, int c,int n) //learn battle 陣列元素 參數
    {
        if (s == "learn")
        {
            learn_temp[c].ChangeStatus(n);
        }
        else if (s == "battle")
        {
            battle_temp[c].ChangeStatus(n);
        }
    }
}
