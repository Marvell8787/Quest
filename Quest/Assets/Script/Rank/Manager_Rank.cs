using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Rank{
    private string serverlink = System_Data.serverlink;
    private string[] items;

    public int state;
    //[0,0/1] 0:username 1:num 
    public string[,] AllClass = new string[27, 2]; //班級人數 
    public string[,] Rank5 = new string[27, 3]; //[x,0]:第幾名 [x,1]:名稱 [x,2]:數量
    public string[,] Learner = new string[1, 3];//00:第幾名 01:號碼 02:數量

    public IEnumerator GetRank(string fileName, string s, string code, int people = 0)
    {
        Learner[0, 1] = System_Data.Username;
        WWWForm RankForm = new WWWForm();
        RankForm.AddField("Code", code);
        RankForm.AddField("Item", s);
        WWW reg = new WWW(serverlink + fileName,RankForm);
        yield return reg;
        string itemDatastring = reg.text;
        items = itemDatastring.Split(';');
        int p=0;
        foreach (string str in items)
        {
            int n=0;
            if (str != "")
            {
                AllClass[p, 0] = GetDataValue(str, "Learner_Username:");
                switch (s)
                {
                    case "Task":
                        for (int j = 0; j < 7; j++)
                        {
                            n += int.Parse(GetDataValue(str, "Learner_Task"+(j+1)+"_Success:"));
                        }
                        break;
                    case "Learn":
                        for (int j = 0; j < 5; j++)
                        {
                            n += int.Parse(GetDataValue(str, "Learner_Learn" + (j + 1) + "_Success:"));
                        }
                        break;
                    case "Battle":
                        for (int j = 0; j < 2; j++)
                        {
                            n += int.Parse(GetDataValue(str, "Learner_Battle" + (j + 1) + "_Success:"));
                        }
                        break;
                    default:
                        break;
                }
                AllClass[p, 1] = n.ToString();
                p++;
            }
        }
        /*for(int i = 0; i < 26; i++)
        {
            Debug.Log(AllClass[i, 0] + ":" + AllClass[i, 1]);
        }*/
        if(p<27) //數字隨便給 大於30就好
        {
            for(int i = 25; i < 27; i++)
            {
                AllClass[i, 0] = p.ToString();
                AllClass[i, 1] = "0";
            }
        }
        sort(AllClass,p);
    }
    private string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    private void sort(string[,] item,int num)
    {
        string temp_name;
        string temp_num;
        for(int i = 0; i < num-1; i++)
        {
            for (int j = 0; j < num-1; j++)
            {
                if (int.Parse(item[j, 1]) < int.Parse(item[j + 1, 1]))
                {
                    temp_name = item[j + 1, 0];
                    temp_num = item[j + 1, 1];

                    item[j + 1, 0] = item[j,0];
                    item[j + 1, 1] = item[j,1];

                    item[j, 0] = temp_name;
                    item[j, 1] = temp_num;
                }
            }
        }
        int n = 1;
        for(int i = 0; i < num; i++)
        {
            Rank5[i, 1] = item[i, 0];//名稱
            Rank5[i, 2]= item[i, 1];//數量

            if (i > 0)
            {
                if(Rank5[i-1, 2] == Rank5[i, 2])
                {
                    Rank5[i, 0] = (n).ToString();//第幾名
                }
                else
                {
                    Rank5[i, 0] = (++n).ToString();//第幾名
                }
            }
            else
            {
                Rank5[i, 0] = n.ToString();//第幾名
            }
        }
        if (num < 27)
        {
            for (int i = 25; i < 27; i++)
            {
                Rank5[i, 0] = num.ToString();
                Rank5[i, 1] = "X";
                Rank5[i, 2] = "0";
            }
        }
        for (int i=0;i< num; i++)
        {
            if(Learner[0, 1] == Rank5[i, 1])
            {
                Learner[0, 0] = Rank5[i, 0];
                Learner[0, 2] = Rank5[i, 2];
                break;
            }
        }
    }
}
