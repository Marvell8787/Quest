using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Mechanism_Data{
    
    public static void Reward(string s, int n) //哪一個核心 第幾個
    {
        switch (System_Data.Version)
        {
            case 0:
            case 1:
                switch (s)
                {
                    case "Task":                        
                        Learner_Data.Learner_Add("Score",0,Task_Bank.Task_Reward[n]);
                        break;
                    case "Learn":
                        Learner_Data.Learner_Add("Coin", 0, Level_Bank.Level_Reward[n]);
                        break;
                   case "Battle":
                        Learner_Data.Learner_Add("Crystal",0, Battle_Bank.Battle_Reward[n]);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    public static void Punishment(string s,int n) //哪一個核心 第幾個 
    {
        switch (System_Data.Version)
        {
            case 0:
            case 2:
                switch (s)
                {
                    case "Task":
                        Learner_Data.Learner_ChangeMistakes_Status(0);
                        if(Learner_Data.Learner_GetData("Score")-Task_Bank.Task_Punishment[n] * Learner_Data.Mistakes_N2 <= 0)
                            Learner_Data.Learner_SetData("Score", 0, 0);
                        else
                            Learner_Data.Learner_Add("Score",0, Task_Bank.Task_Punishment[n]*Learner_Data.Mistakes_N2);
                        Learner_Data.Learner_ChangePoints_Status(0);
                        break;
                    case "Learn":
                        Learner_Data.Learner_ChangeMistakes_Status(0);
                        if (Learner_Data.Learner_GetData("Coin")- Level_Bank.Level_Punishment[n] * Learner_Data.Mistakes_N2 <= 0)
                            Learner_Data.Learner_SetData("Coin", 0, 0);
                        else
                            Learner_Data.Learner_Add("Coin", 0, Level_Bank.Level_Punishment[n] * Learner_Data.Mistakes_N2);
                        Learner_Data.Learner_ChangePoints_Status(1);
                        break;
                    case "Battle":
                        Learner_Data.Learner_ChangeMistakes_Status(0);
                        if (Learner_Data.Learner_GetData("Crystal")-Battle_Bank.Battle_Punishment[n] * Learner_Data.Mistakes_N2 <= 0)
                            Learner_Data.Learner_SetData("Crystal", 0, 0);
                        else
                            Learner_Data.Learner_Add("Crystal", 0, Battle_Bank.Battle_Punishment[n] * Learner_Data.Mistakes_N2);
                        Learner_Data.Learner_ChangePoints_Status(2);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}
