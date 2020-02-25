using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class Question_Data{
    // Level_Learn
    private static string[] Question = new string[10] { "", "", "", "", "", "", "", "", "", "" };
    private static string[] Answer_r_Content = new string[10] { "", "", "", "", "", "", "", "", "", "" };

    private static string[] Button_Ans = new string[3] { "", "", ""};
    private static string[] Button_Ans_Check = new string[3] { "A", "B", "C" };

    private static Question_Class[] question_temp = new Question_Class[10];
    private static Vocabulary_Class[] vocabulary_temp = new Vocabulary_Class[10];

    private static int Level;
    private static int Task;
    private static int Qtotal;

    public static void Question_Init(int _Level,int n1,int n2,int n3,int _Task=0) //題型 第n1題到第n2題 共n3題 是否有任務
    {
        Random.InitState(System.Guid.NewGuid().GetHashCode());
        Level = _Level;
        Task = _Task;
        for (int i = 0; i < Vocabulary_Bank.Vocabulary_Num; i++)
        {
            vocabulary_temp[i] = Vocabulary_Data.Vocabulary_Get(i);
        }
        Question_Set(_Level, n1, n2,n3);
    }
    public static Question_Class Question_Get(int n)
    {
        return question_temp[n];
    }
    public static void Button_Ans_Set(int _Level,int QNum) //設定選項答案
    {
        //選項設定START
        int r = 0;
        r = Random.Range(0, 3);
        //亂數陣列 START
        int[] rand = new int[10];
        int c = 0;
        rand = GetRandomSequence(10);
        //亂數陣列 END
        for (int i = 0; i < 3; i++)
        {
            if (r == i)
            {
                ChangeButton_Ans(question_temp[QNum].GetAnswer_r_Content(), i);
                ChangeAnswer_r(Button_Ans_Check[r], QNum); //設定正解ABC END
            }
            else
            {
                while (true)
                {
                    if (_Level <= 1)  //英文 Level 1 2
                    {
                        if (Vocabulary_Bank.Vocabulary_E_Name[rand[c]] == (question_temp[QNum].GetAnswer_r_Content()))
                        { c++; continue; }
                        else
                        {
                            ChangeButton_Ans(Vocabulary_Bank.Vocabulary_E_Name[rand[c]], i);
                            c++;
                            break;
                        }
                    }
                    else if(_Level > 2 && _Level <= 4)//題目 英文 答案 中文 Level 3 4
                    {
                        if (Vocabulary_Bank.Vocabulary_E_Name[rand[c]] == (question_temp[QNum].GetQuestion()))
                        { c++; continue; }
                        else
                        {
                            ChangeButton_Ans(Vocabulary_Bank.Vocabulary_C_Name[rand[c]], i);
                            c++;
                            break;
                        }
                    }
                    else if (_Level ==6)//題目 中文 答案 英文 卡牌戰鬥用
                    {
                        if (Vocabulary_Bank.Vocabulary_C_Name[rand[c]] == (question_temp[QNum].GetQuestion()))
                        { c++; continue; }
                        else
                        {
                            ChangeButton_Ans(Vocabulary_Bank.Vocabulary_E_Name[rand[c]], i);
                            c++;
                            break;
                        }
                    }
                }
            }
        }
        //選項設定 END
    }
    public static string GetButton_Ans(int c)
    {
        return Button_Ans[c];
    }
    public static int GetQtotal()
    {
        return Qtotal;
    }
    public static int GetLevel()
    {
        return Level;
    }
    public static int GetTask()
    {
        return Task;
    }
    public static void ChangeButton_Ans(string s, int c) //傳送到Level_Learn的三個選項
    {
        Button_Ans[c] = s;
    }
    public static void ChangeAnswer_r(string s, int c)
    {
        question_temp[c].ChangeAnswer_r(s);
    }
    public static void ChangeAnswer_c(string s, int c)
    {
        question_temp[c].ChangeAnswer_c(s);
    }
    public static void ChangeAnswer_c_Content(string s, int c)
    {
        question_temp[c].ChangeAnswer_c_Content(s);
    }
    public static void ChangeFeedBack(string s, int c)
    {
        question_temp[c].ChangeFeedBack(s);
    }
    private static void Question_Set(int _Level,int n1,int n2,int n3) //Level=題型 第n1題到第n2題 共n3題
    {
        for (int i = n1 - 1; i < n3; i++)
        {
            if (_Level < 3)//聽力
            {
                Question[i] = vocabulary_temp[i].GetE_Name();
                Answer_r_Content[i] = vocabulary_temp[i].GetE_Name();
            }
            else if (_Level < 6) //英翻中
            {
                Question[i] = vocabulary_temp[i].GetE_Name();
                Answer_r_Content[i] = vocabulary_temp[i].GetC_Name();
            }
            else if (_Level > 5)//中翻英 6 7 題目中文 7戰鬥用
            {
                Question[i] = vocabulary_temp[i].GetC_Name();
                Answer_r_Content[i] = vocabulary_temp[i].GetE_Name();
            }
        }
        QaARandomSequence(n3);

        for (int i = 0; i < n3; i++)
            question_temp[i] = new Question_Class(i + 1, Question[i], "", Answer_r_Content[i], "", "", "");

        Qtotal = n3;
    }

    private static int[] GetRandomSequence(int total)
    {
        int r;
        int[] output = new int[total];
        for (int i = 0; i < total; i++)
        {
            output[i] = i;
        }
        for (int i = 0; i < total; i++)
        {
            r = Random.Range(0, total);
            int temp = 0;
            temp = output[i];
            output[i] = output[r];
            output[r] = temp;
        }
        return output;
    }
    private static void QaARandomSequence(int total)
    {
        int r;
        for (int i = 0; i < total; i++)
        {
            r = Random.Range(0, total);
            string temp = "";
            temp = Question[i];
            Question[i] = Question[r];
            Question[r] = temp;

            temp = Answer_r_Content[i];
            Answer_r_Content[i] = Answer_r_Content[r];
            Answer_r_Content[r] = temp;
        }
    }

}
