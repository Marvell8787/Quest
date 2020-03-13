﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Task : MonoBehaviour {


    #region Variable
    private string choose_s = "";
    private int choose_n = 0;
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

    #region Task 
    public GameObject ui_Task, ui_Task_Content;
    public Button TaskLearn_btn, TaskBattle_btn; //Image
    public Button TaskContentCancel_btn;
    public Text[] Task_text = new Text[5];
    #endregion

    #region Task Content
    public Text Text_Request_Content, Text_Reward_Content, Text_Punishment_Content;
    public Button Take_btn;
    #endregion
    public Text Score_text, Point_text, Mistake_text;
    public Image Point_img, Mistake_img;
    public Button Back_btn;
    public AudioSource choose, ok, cancel;


    // Use this for initialization
    void Start () {
        
        Score_text.text = Learner_Data.Learner_GetData("Score").ToString();
        switch (System_Data.Version)
        {
            case 0:
            case 2:
                Point_text.text = Learner_Data.Learner_GetData("Points_Num").ToString();
                Mistake_text.text = Learner_Data.Learner_GetData("Mistakes_Num").ToString();
                break;
            default:
                Point_img.gameObject.SetActive(false);
                Mistake_img.gameObject.SetActive(false);
                Point_text.gameObject.SetActive(false);
                Mistake_text.gameObject.SetActive(false);
                break;
        }
        Back_btn.onClick.AddListener(Back);
        Take_btn.onClick.AddListener(Take);
        for (int i = 0; i < 5; i++)
        {
            Task_text[i].text = "";
        }
        TaskLearn_btn.onClick.AddListener(Task_Learn);
        TaskBattle_btn.onClick.AddListener(Task_Battle);
        AddEvents.AddTriggersListener(Task_text[0].gameObject, EPClick, Task_0);
        AddEvents.AddTriggersListener(Task_text[1].gameObject, EPClick, Task_1);
        AddEvents.AddTriggersListener(Task_text[2].gameObject, EPClick, Task_2);
        AddEvents.AddTriggersListener(Task_text[3].gameObject, EPClick, Task_3);
        AddEvents.AddTriggersListener(Task_text[4].gameObject, EPClick, Task_4);

    }
    void Task_Learn()
    {
        ui_Task_Content.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            Task_text[i].text = "";
        }
        choose_s = "learn";
        ok.Play();
        Task_Class[] learn_temp = new Task_Class[5];
        for (int i = 0; i < 5; i++)
        {
            learn_temp[i] = Task_Data.Learn_Get(i);
            Task_text[i].text = learn_temp[i].GetTitle();
            if (Learner_Data.Learner_GetData("Task_Success", i) > 0)
            {
                Task_text[i].color = Color.gray;
                Task_text[i].fontStyle = FontStyle.Italic;
            }
            else
            {
                Task_text[i].color = Color.black;
                Task_text[i].fontStyle = FontStyle.Bold;

            }/*
            switch (learn_temp[i].GetStatus())
            {
                case 1: //未接
                    Task_text[i].color = Color.black;
                    Task_text[i].fontStyle = FontStyle.Bold;
                    break;
                case 2: //完成
                    Task_text[i].color = Color.gray;
                    Task_text[i].fontStyle = FontStyle.Italic;
                    break;
                default:
                    break;
            }*/
        }
    }
    void Task_Battle()
    {
        ui_Task_Content.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            Task_text[i].text = "";
        }
        choose_s = "battle";
        ok.Play();
        Task_Class[] battle_temp = new Task_Class[3];
        for (int i = 0; i < 2; i++)
        {
            battle_temp[i] = Task_Data.Battle_Get(i);
            Task_text[i].text = battle_temp[i].GetTitle();
            if(Learner_Data.Learner_GetData("Task_Success", i + 5) > 0)
            {
                Task_text[i].color = Color.gray;
                Task_text[i].fontStyle = FontStyle.Italic;
            }
            else
            {
                Task_text[i].color = Color.black;
                Task_text[i].fontStyle = FontStyle.Bold;
            }
            /*
            switch (battle_temp[i].GetStatus())
            {
                case 0: //未接
                    Task_text[i].color = Color.black;
                    Task_text[i].fontStyle = FontStyle.Bold;
                    break;
                case 1: //完成
                    Task_text[i].color = Color.gray;
                    Task_text[i].fontStyle = FontStyle.Italic;
                    break;
                default:
                    break;
            }*/
        }
    }
    #region Task PointerClick Function
    void Task_0(BaseEventData data)
    {
        if (choose_s != "")
        {
            ok.Play();
            Button_Change(0);
            ShowContent(0);
            choose_n = 0;
            ui_Task_Content.SetActive(true);
        }

    }
    void Task_1(BaseEventData data)
    {
        if (choose_s != "")
        {
            ok.Play();
            Button_Change(1);
            ShowContent(1);
            choose_n = 1;
            ui_Task_Content.SetActive(true);
        }
    }
    void Task_2(BaseEventData data)
    {
        if (choose_s != "")
        {
            ok.Play();
            Button_Change(2);
            ShowContent(2);
            choose_n = 2;
            ui_Task_Content.SetActive(true);
        }
    }
    void Task_3(BaseEventData data)
    {
        if (choose_s != "")
        {
            ok.Play();
            Button_Change(3);
            ShowContent(3);
            choose_n = 3;
            ui_Task_Content.SetActive(true);
        }
    }
    void Task_4(BaseEventData data)
    {
        if (choose_s != "")
        {
            ok.Play();
            Button_Change(4);
            ShowContent(4);
            choose_n = 4;
            ui_Task_Content.SetActive(true);
        }
    }
    #endregion
    void Take()
    {
        ok.Play();
        //改變狀態
        Task_Data.ChangeStatus(choose_s, choose_n, 2);

        if (choose_s == "learn")
        {
            Question_Data.Question_Init(choose_n, 1, 8, 5,1);
            SceneManager.LoadScene("Level");
        }
        else if (choose_s == "battle")
        {
            ok.Play();
            Battle_Class battle_temp = new Battle_Class();
            battle_temp = Battle_Data.Battle_Get(choose_n);
            int n3 = int.Parse(battle_temp.GetTime());
            ok.Play();
            Question_Data.Question_Init(5, 1, 10, n3, 1);
            Player_Data.Player_Init(choose_n);
            Player_Data.Shuffle(0);
            Player_Data.Shuffle(1);
            Player_Data.Deal();
            SceneManager.LoadScene("Fight");
        }
    }
    void ShowContent(int n)
    {
        Task_Class task_temp = new Task_Class();
        if (choose_s == "learn")
            task_temp = Task_Data.Learn_Get(n);
        else if (choose_s == "battle")
            task_temp = Task_Data.Battle_Get(n);

        Text_Request_Content.text = task_temp.GetRequest();
        Text_Reward_Content.text = task_temp.GetReward();
        Text_Punishment_Content.text = task_temp.GetPunishment();
    }
    void Button_Change(int n)
    {
        /*
        Task_Class task_temp = new Task_Class();
        int status;
        task_temp = Task_Data.Learn_Get(n);
        if (choose_s == "learn")
            task_temp = Task_Data.Learn_Get(n);
        else if (choose_s == "battle")
            task_temp = Task_Data.Battle_Get(n);
        
        status = task_temp.GetStatus();
                switch (status)
        {
            case 1: //未接
                Take_btn.interactable = true;
                break;
            case 2: //完成
                Take_btn.interactable = false;
                break;
            default:
                break;
        }
        */
        if (choose_s == "learn")
        {
            switch (Learner_Data.Learner_GetData("Task_Success", n))
            {
                case 0: //未接
                    Take_btn.interactable = true;
                    break;
                case 1: //完成
                    Take_btn.interactable = false;
                    break;
                default:
                    break;
            }
        }
        else if (choose_s == "battle")
        {
            switch (Learner_Data.Learner_GetData("Task_Success", 5+n))
            {
                case 0: //未接
                    Take_btn.interactable = true;
                    break;
                case 1: //完成
                    Take_btn.interactable = false;
                    break;
                default:
                    break;
            }
        }

    }
    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
