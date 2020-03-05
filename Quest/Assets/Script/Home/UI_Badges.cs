using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Badges : MonoBehaviour {

    #region Variable
    private int PageUp = 1;

    private int No = 0;
    private int Item = 0; //0 3
    private int Page = 0; //0 9
    #endregion

    #region Home
    public GameObject Home_obj, Name_obj;
    public AudioSource ok, cancel, PageTurning;
    public Text Info_text;
    #endregion

    #region Badges
    public GameObject Badges_obj;
    public Button[] Badges_btn = new Button[9]; //Image
    public Button BadgesCancel_btn, Right_btn, Left_btn;
    public Text[] Item_text = new Text[3];
    public Text PageUp_text;
    #endregion

    // Use this for initialization
    void Start () {
        Badges_btn[0].onClick.AddListener(Badges_0);
        Badges_btn[1].onClick.AddListener(Badges_1);
        Badges_btn[2].onClick.AddListener(Badges_2);
        Badges_btn[3].onClick.AddListener(Badges_3);
        Badges_btn[4].onClick.AddListener(Badges_4);
        Badges_btn[5].onClick.AddListener(Badges_5);
        Badges_btn[6].onClick.AddListener(Badges_6);
        Badges_btn[7].onClick.AddListener(Badges_7);
        Badges_btn[8].onClick.AddListener(Badges_8);
        Right_btn.onClick.AddListener(Next);
        Left_btn.onClick.AddListener(Previous);
        BadgesCancel_btn.onClick.AddListener(Badges_Cancel);
        for (int i = 0; i < 3; i++)
        {
            Item_text[i].text = Badges_Bank.Badges_Name[i + Item];
        }
        ShowPicture();
    }
    void Badges_Cancel()
    {
        cancel.Play();
        Name_obj.SetActive(true);
        Badges_obj.SetActive(false);
        Home_obj.SetActive(true);
        Info_text.text = "請完成所有任務\n學習區可以練習題目\n戰鬥區可進行模擬跟電腦戰鬥的模式\n可至個人狀態查詢所持有的物品";
    }

    void Previous()
    {
        PageTurning.Play();
        if (PageUp > 1)
        {
            PageUp--;
            Item = 0;
            Page = 0;
            PageChage();
        }

    }
    void Next()
    {
        PageTurning.Play();
        if (PageUp < 2)
        {
            PageUp++;
            Item = 3;
            Page = 9;
            PageChage();
        }

    }
    void PageChage()
    {
        PageUp_text.text = PageUp.ToString();
        for (int i = 0; i < 3; i++)
        {
            Item_text[i].text = Badges_Bank.Badges_Name[i + Item];
        }
        ShowPicture();
    }
    void ShowPicture()
    {
        int[] badges_temp = new int[9];

        for (int i = 0; i < 9; i++)
            badges_temp[i] = Learner_Data.Learner_GetBadges_Status(i + Page);

        for (int i = 0; i < 9; i++)
        {
            if (badges_temp[i] == 1)
                Badges_btn[i].image.color = new Color32(255, 255, 255, 255);
            else
                Badges_btn[i].image.color = new Color32(60, 60, 60, 255);
        }
    }

    #region Badges Image
    void Badges_Output(int n)
    {
        Info_text.text = Badges_Bank.Badges_Description[n];
    }
    void Badges_0()
    {
        No = 0 + Page;
        Badges_Output(No);
    }
    void Badges_1()
    {
        No = 1 + Page;
        Badges_Output(No);
    }
    void Badges_2()
    {
        No = 2 + Page;
        Badges_Output(No);
    }
    void Badges_3()
    {
        No = 3 + Page;
        Badges_Output(No);
    }
    void Badges_4()
    {
        No = 4 + Page;
        Badges_Output(No);
    }
    void Badges_5()
    {
        No = 5 + Page;
        Badges_Output(No);
    }
    void Badges_6()
    {
        No = 6 + Page;
        Badges_Output(No);
    }
    void Badges_7()
    {
        No = 7 + Page;
        Badges_Output(No);
    }
    void Badges_8()
    {
        No = 8 + Page;
        Badges_Output(No);
    }
    #endregion
}
