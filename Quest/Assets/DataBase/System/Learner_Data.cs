using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Learner_Data{

    //Task
    private static int[] Task_Num = new int[7] { 0,0,0,0,0,0,0 }; //進行次數
    private static int[] Task_Success = new int[7] { 0, 0, 0, 0, 0, 0, 0 }; //成功次數
    private static int[] Task_Fail = new int[7] { 0, 0, 0, 0, 0, 0, 0 }; //失敗次數
    //Learn
    private static int[] Learn_Num = new int[5] { 0, 0, 0, 0, 0 }; //進行次數
    private static int[] Learn_Success = new int[5] { 0, 0, 0, 0, 0 }; //成功次數
    private static int[] Learn_Fail = new int[5] { 0, 0, 0, 0, 0 }; //失敗次數
    //Battle
    private static int[] Battle_Num = new int[2] { 0, 0}; //進行次數
    private static int[] Battle_Success = new int[2] { 0, 0}; //成功次數
    private static int[] Battle_Fail = new int[2] { 0, 0}; //失敗次數
    //Reward and Punishment
    private static int Score = 100; //分數
    private static int Score_Accumulation = 100; //分數高點
    private static int Coin = 200; //金幣持有
    private static int Coin_Accumulation = 200; //金幣高點
    private static int Crystal = 10; //水晶
    private static int Crystal_Accumulation = 10; //水晶高數
    //Reward
    //Badges
    private static int[] Badges_Status = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //獎章持有狀態 0:無 1:有
    //test private static int[] Badges_Status = new int[18] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //獎章持有狀態 0:無 1:有
    private static int[] Badges_GetStatus = new int[3] { 0, 0, 0 }; //任務 學習 戰鬥
    private static int Badges_Num = 0; //獎章數量

    //Card
    private static int Cards_Num = 10; //卡片數量
    private static int[] Cards_GetStatus = new int[3] { 9, 1, 0 }; //卡牌種類持有狀態 前鋒 中鋒 支援
    private static int[] Card_Status = new int[22] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }; //卡片持有狀態 0:無 1~22:有
    //Punishment
    //Point
    private static int[] Points_Status = new int[3] { 3, 3, 3 }; //點數持有狀態 Task Learn Battle
    private static int Points_Num = 9; //點數
    //Mistakes
    private static int[] Mistakes_Status = new int[3] { 0, 0, 0 }; //失誤持有狀態 warning YC RC
    private static int Mistakes_Num = 0; //失誤

    private static string Learner_Behaviors = "";


    public static void Learner_Add(string s,int p, int n) // s=想要加的東西 p=索引  n=數字(可+ -)   
    {
        switch (s)
        {
            case "Task_Num": Task_Num[p] += n; break;
            case "Task_Success": Task_Success[p] += n; break;
            case "Task_Fail": Task_Fail[p] += n; break;
            case "Learn_Num": Learn_Num[p] += n; break;
            case "Learn_Success": Learn_Success[p] += n; break;
            case "Learn_Fail": Learn_Fail[p] += n; break;
            case "Battle_Num": Battle_Num[p] += n; break;
            case "Battle_Success": Battle_Success[p] += n; break;
            case "Battle_Fail": Battle_Fail[p] += n; break;
            //Reward and Punishment
            case "Score": Score += n; break;
            case "Score_Accumulation": Score_Accumulation += n; break;
            case "Coin": Coin += n; break;
            case "Coin_Accumulation": Coin_Accumulation += n; break;
            case "Crystal": Crystal += n; break;
            case "Crystal_Accumulation": Crystal_Accumulation += n; break;
            //Reward
            case "Badges_Num": Badges_Num += n; break;
            case "Card_Num": Cards_Num += n; break;
            //Punishment
            case "Points_Num": Points_Num += n; break;
            case "Mistakes_Num": Mistakes_Num += n; break;
            default: break;
        }

    }

    public static int Learner_GetData(string s, int p) // s=想要讀取的東西    
    {
        int n;
        switch (s)
        {
            //Task
            case "Task_Num": n = Task_Num[p]; break;
            case "Task_Success": n = Task_Success[p]; break;
            case "Task_Fail": n = Task_Fail[p]; break;
            //Learn
            case "Learn_Num": n = Learn_Num[p]; break;
            case "Learn_Success": n = Learn_Success[p]; break;
            case "Learn_Fail": n = Learn_Fail[p]; break;
            //Battle
            case "Battle_Num": n = Battle_Num[p]; break;
            case "Battle_Success": n = Battle_Success[p]; break;
            case "Battle_Fail": n = Battle_Fail[p]; break;
            //Reward and Punishment
            case "Score": n = Score; break;
            case "Coin": n = Coin; break;
            case "Crystal": n = Crystal; break;
            //Reward
            case "Badges_Num": n = Badges_Num; break;
            case "Cards_Num": n = Cards_Num; break;
            //Punishment
            case "Points_Num": n = Points_Num; break;
            case "Mistakes_Num": n = Mistakes_Num; break;
            default: n = -1; break;
        }
        return n;
    }
    public static void Learner_Behavior_Add(string s)
    {
        Learner_Behaviors += s;
    }
    public static string Learner_Behavior_Get()
    {
        string s =Learner_Behaviors;
        return s;
    }

}
