using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Login{

    private string serverlink= System_Data.serverlink;
    private string[] items;
    public int state;
    
    public IEnumerator CheckLogin(string fileName, string user , string pwd)
    {
        WWWForm LoginForm = new WWWForm();
        LoginForm.AddField("UsernamePost", user);
        LoginForm.AddField("PasswordPost", pwd);
        WWW reg = new WWW(serverlink + fileName, LoginForm);
        yield return reg;
        //s_state = reg.ToString();

        if (reg.error == null)
        {
            if (reg.text == "2")
            {
                state = 2;//帳密錯誤
            }
            else if (reg.text == "3")
            {
                state = 3;//連線失敗
            }
            else if (reg.text == "1")//帳密正確
            {
                state = 1;
            }
        }
        else
        {
            Debug.Log("error msg" + reg.error);
        }
    }
    public IEnumerator Loading(string fileName, string user)
    {
        #region Task Learn Battle
        WWWForm LoadForm = new WWWForm();
        LoadForm.AddField("Username", user);
        WWW reg = new WWW(serverlink + fileName, LoadForm);
        yield return reg;
        string itemDatastring = reg.text;
        items = itemDatastring.Split(';');
        foreach (string str in items)
        {
            string s;
            int n = 0;
            if (str != "")
            {
                for (int i = 0; i < 7; i++)
                {
                    n = int.Parse(GetDataValue(str, "Learner_Task" + (i + 1) + "_Num:"));
                    Learner_Data.Learner_Add("Task_Num", i,n);
                    n = int.Parse(GetDataValue(str, "Learner_Task" + (i + 1) + "_Success:"));
                    Learner_Data.Learner_Add("Task_Success", i, n);
                    n = int.Parse(GetDataValue(str, "Learner_Task" + (i + 1) + "_Success:"));
                    Learner_Data.Learner_Add("Task_Fail", i, n);
                }
                for (int i = 0; i < 5; i++)
                {
                    n = int.Parse(GetDataValue(str, "Learner_Learn" + (i + 1) + "_Num:"));
                    Learner_Data.Learner_Add("Learn_Num", i, n);
                    n = int.Parse(GetDataValue(str, "Learner_Learn" + (i + 1) + "_Success:"));
                    Learner_Data.Learner_Add("Learn_Success", i, n);
                    n = int.Parse(GetDataValue(str, "Learner_Learn" + (i + 1) + "_Fail:"));
                    Learner_Data.Learner_Add("Learn_Fail", i, n);
                }
                for (int i = 0; i < 2; i++)
                {
                    n = int.Parse(GetDataValue(str, "Learner_Battle" + (i + 1) + "_Num:"));
                    Learner_Data.Learner_Add("Battle_Num", i, n);
                    n = int.Parse(GetDataValue(str, "Learner_Battle" + (i + 1) + "_Success:"));
                    Learner_Data.Learner_Add("Battle_Success", i, n);
                    n = int.Parse(GetDataValue(str, "Learner_Battle" + (i + 1) + "_Fail:"));
                    Learner_Data.Learner_Add("Battle_Fail", i, n);
                }
                n = int.Parse(GetDataValue(str, "Learner_Score:"));
                Learner_Data.Learner_SetData("Score", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Score_Accumulation:"));
                Learner_Data.Learner_SetData("Score_Accumulation", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Coin:"));
                Learner_Data.Learner_SetData("Coin", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Coin_Accumulation:"));
                Learner_Data.Learner_SetData("Coin_Accumulation", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Crystal:"));
                Learner_Data.Learner_SetData("Crystal", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Crystal_Accumulation:"));
                Learner_Data.Learner_SetData("Crystal_Accumulation", 0, n);

                n = int.Parse(GetDataValue(str, "Learner_Cards:"));
                Learner_Data.Learner_SetData("Card_Num", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Badges:"));
                Learner_Data.Learner_SetData("Badges_Num", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Points:"));
                Learner_Data.Learner_SetData("Points_Num", 0, n);
                n = int.Parse(GetDataValue(str, "Learner_Mistakes:"));
                Learner_Data.Learner_SetData("Mistakes_Num", 0, n);

                s = GetDataValue(str, "Learner_Behaviors:");
                Learner_Data.Learner_Behavior_Add(s);
            }
        }
        #endregion
        #region Card
        WWWForm CardForm = new WWWForm();
        CardForm.AddField("Username", user);
        WWW cardreg = new WWW(serverlink + "Learner_CardLoad.php", CardForm);
        yield return cardreg;
        string cardDatastring = cardreg.text;
        items = cardDatastring.Split(';');
        foreach (string str in items)
        {
            int n = 0;
            if (str != "")
            {
                for(int i = 0; i < 22; i++)
                {
                    n = int.Parse(GetDataValue(str, "Cardstatus_" + (i) + ":"));
                    if(n>0)
                        Learner_Data.Learner_ChangeCard_Status(i);
                }
                n = int.Parse(GetDataValue(str, "Cardstatus_V:"));
                Learner_Data.Learner_SetCardsGet_Status(0,n);
                n = int.Parse(GetDataValue(str, "Cardstatus_C:"));
                Learner_Data.Learner_SetCardsGet_Status(1, n);
                n = int.Parse(GetDataValue(str, "Cardstatus_S:"));
                Learner_Data.Learner_SetCardsGet_Status(2, n);
            }
        }
        #endregion
       #region  Points
        WWWForm PointsForm = new WWWForm();
        PointsForm.AddField("Username", user);
        WWW pointreg = new WWW(serverlink + "Learner_PointLoad.php", PointsForm);
        yield return pointreg;
        string pointDatastring = pointreg.text;
        items = pointDatastring.Split(';');
        foreach (string str in items)
        {
            int n = 0;
            if (str != "")
            {
                n = int.Parse(GetDataValue(str, "Pointstatus_Task:"));
                Learner_Data.Learner_SetPoints_Status(0, n);
                n = int.Parse(GetDataValue(str, "Pointstatus_Learn:"));
                Learner_Data.Learner_SetPoints_Status(1, n);
                n = int.Parse(GetDataValue(str, "Pointstatus_Battle:"));
                Learner_Data.Learner_SetPoints_Status(2, n);
            }
        }
        #endregion
        #region  Mistakes
        WWWForm MistakesForm = new WWWForm();
        MistakesForm.AddField("Username", user);
        WWW mistakereg = new WWW(serverlink + "Learner_MistakesLoad.php", MistakesForm);
        yield return mistakereg;
        string mistakeDatastring = mistakereg.text;
        items = mistakeDatastring.Split(';');
        foreach (string str in items)
        {
            int n = 0;
            if (str != "")
            {
                n = int.Parse(GetDataValue(str, "Mistake_Warning:"));
                Learner_Data.Learner_SetMistakes_Status(0, n);
                n = int.Parse(GetDataValue(str, "Mistake_YC:"));
                Learner_Data.Learner_SetMistakes_Status(1, n);
                n = int.Parse(GetDataValue(str, "Mistake_RC:"));
                Learner_Data.Learner_SetMistakes_Status(2, n);
            }
        }
        #endregion
    }
    public string GetDataValue(string data,string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|"))value=value.Remove(value.IndexOf("|"));
        return value;
    }
}
