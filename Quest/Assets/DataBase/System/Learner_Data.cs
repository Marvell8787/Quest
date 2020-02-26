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


    public static void Learner_Add(string s,int p, int n=0) // s=想要加的東西 p=索引  n=數字(可+ -)   
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

    public static int Learner_GetData(string s, int p=0) // s=想要讀取的東西    
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
        string s = Learner_Behaviors;
        return s;
    }

    public static int Learner_GetCardsGet_Status(int n)
    {
        return Cards_GetStatus[n];
    }
    public static void Learner_ChangeCardsGet_Status(int n) //Cards
    {
        Cards_GetStatus[n] += 1;
    }

    public static int Learner_GetCard_Status(int n)
    {
        return Card_Status[n];
    }
    public static void Learner_ChangeCard_Status(int n) //Cards
    {
        Card_Status[n] = 1;
    }

    //Badges
    public static int Learner_GetBadges_Status(int n)
    {
        return Badges_Status[n];
    }
    public static void Learner_ChangeBadges_Status(int n) //Badges
    {
        Badges_Status[n] = 1;
    }

    public static int Learner_GetBadges_GetStatus(int n)
    {
        return Badges_GetStatus[n];
    }
    public static void Learner_ChangeBadges_GetStatus(int n) //Badges
    {
        Badges_GetStatus[n] += 1;
    }

    private static void CheckBadges(string s)
    {
        int _Task_Succes=0, _Learn_Succes=0, _Battle_Success = 0;
        for (int i = 0; i < 7; i++)
            _Task_Succes += Task_Success[i];
        for (int i = 0; i < 5; i++)
            _Learn_Succes += Learn_Success[i];
        for (int i = 0; i < 2; i++)
            _Battle_Success += Battle_Success[i];
        switch (s)
        {
            //Task
            case "Task_Succes":
                if (_Task_Succes > 2 && _Task_Succes < 5)
                    Badges_Status[0] = 1;
                else if (_Task_Succes > 4 && _Task_Succes < 8)
                    Badges_Status[1] = 1;
                else if (_Task_Succes > 7)
                    Badges_Status[2] = 1;
                break;
            //Learn
            case "Learn_Succes":
                if (_Learn_Succes > 4 && _Learn_Succes < 10)
                    Badges_Status[3] = 1;
                else if (_Learn_Succes > 9 && _Learn_Succes < 20)
                    Badges_Status[4] = 1;
                else if (_Learn_Succes > 19)
                    Badges_Status[5] = 1;
                break;
            //Battle
            case "Battle_Win":
                if (_Battle_Success > 2 && _Battle_Success < 5)
                    Badges_Status[6] = 1;
                else if (_Battle_Success > 4 && _Battle_Success < 10)
                    Badges_Status[7] = 1;
                else if (_Battle_Success > 9)
                    Badges_Status[8] = 1;
                break;
            //Score_Highest Crystal_Highest 是指定
            case "Score_Highest":
                if (Score_Accumulation > 149 && Score_Accumulation < 200)
                    Badges_Status[9] = 1;
                else if (Score_Accumulation > 199 && Score_Accumulation < 250)
                    Badges_Status[10] = 1;
                else if (Score_Accumulation > 249)
                    Badges_Status[11] = 1;
                break;
            case "Coin_Highest":
                if (Coin_Accumulation > 199 && Coin_Accumulation < 400)
                    Badges_Status[12] = 1;
                else if (Coin_Accumulation > 399 && Coin_Accumulation < 600)
                    Badges_Status[13] = 1;
                else if (Coin_Accumulation > 599)
                    Badges_Status[14] = 1;
                break;
            case "Crystal_Highest":
                if (Crystal_Accumulation > 149 && Crystal_Accumulation < 250)
                    Badges_Status[15] = 1;
                else if (Crystal_Accumulation > 249 && Crystal_Accumulation < 400)
                    Badges_Status[16] = 1;
                else if (Crystal_Accumulation > 399)
                    Badges_Status[17] = 1;
                break;
            default:
                break;
        }
    }

    public static int Learner_GetPoints_Status(int n)
    {
        return Points_Status[n];
    }
    public static void Learner_ChangePoints_Status(int n) //Points
    {
        Points_Status[n] -= 1;
        Points_Num--;
        CheckPoints("Points_Num");
    }
    private static void CheckPoints(string s)
    {
        switch (s)
        {
            case "Points_Num":
                if (Points_Status[0] == 0)
                {
                    Score = 0;
                }
                else if (Points_Status[1] == 0)
                {
                    Coin = 0;
                }
                else if (Points_Status[2] == 0)
                {
                    Crystal = 0;
                }
                break;
            default:
                break;
        }
    }
    //Mistakes
    public static int Learner_GetMistakes_Status(int n)
    {
        return Mistakes_Status[n];
    }
    public static void Learner_ChangeMistakes_Status(int n) //Mistakes
    {
        Mistakes_Status[n] += 1;
        Mistakes_Num++;
        CheckMistakes("Mistakes_Num");
    }
    private static void CheckMistakes(string s)
    {
        switch (s)
        {
            case "Mistakes_Num":
                if ((Mistakes_Status[0] % 3) == 0 && Mistakes_Status[0] > 0)
                {
                    Mistakes_Status[1] += 1;
                }
                if ((Mistakes_Status[1] % 3) == 0 && Mistakes_Status[1] > 0)
                {
                    Mistakes_Status[2] += 1;
                }
                if (Mistakes_Status[2] > 0)
                {
                    //懲罰+倍
                }
                break;
            default:
                break;
        }
    }
}
