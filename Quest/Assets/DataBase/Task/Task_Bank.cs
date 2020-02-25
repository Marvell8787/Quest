using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Task_Bank
{
    public static int[] Learn_Request_Score = new int[5] {80, 60, 80, 60, 50 };

    public static string[] Learn_Title = new string[5] { "Level-1", "Level-2", "Level-3", "Level-4", "Level-5"};
    public static string[] Learn_Request = new string[5] { "Level-1 80分以上！", "Level-2 60分以上！", "Level-3 80分以上！", "Level-4 60分以上！", "Level-5 50分以上！" };
    public static string[] Learn_Reward = new string[5] { "分數 +10", "分數 +30", "分數 +10", "分數 +30", "分數 +50" };
    public static string[] Learn_Punishment = new string[5] { "分數 -10", "分數 -30", "分數 -10","分數 -30", "分數 -50" };

    public static string[] Battle_Title = new string[2] { "Battle 1", "Battle 2"};
    public static string[] Battle_Request = new string[2] { "在Battle 1取得勝利", "在Battle 2取得勝利"};
    public static string[] Battle_Reward = new string[2] { "分數 +10", "分數 +50" };
    public static string[] Battle_Punishment = new string[2] { "分數 -10", "分數 -50" };

    //獎懲數字
    public static int[] Task_Reward = new int[7] {  10, 30, 10, 30, 50, 10, 50 };
    public static int[] Task_Punishment = new int[7] {  -10, -30, -10, -30, -50, -10, -50 };
    //狀態
    public static int[] Learn_Status = new int[5] { 1, 1, 1, 1, 1 };
    public static int[] Battle_Status = new int[2] { 1, 1};
}
