﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Rank : MonoBehaviour {
    Manager_Rank mr = new Manager_Rank();
    Manager_log ml = new Manager_log();
    string choose_s;
    public GameObject btn_obj;
    public Button Back_btn,Task_btn,Learn_btn,Battle_btn;
    public Text Info_text;
    public Text[] Rank_text = new Text[6];
    public Text[] ID_text = new Text[6];
    public Text[] Num_text = new Text[6];
    public AudioSource choose, ok;

    // Use this for initialization
    void Start () {
        Back_btn.onClick.AddListener(Back);
        Task_btn.onClick.AddListener(Task);
        Learn_btn.onClick.AddListener(Learn);
        Battle_btn.onClick.AddListener(Battle);
        Info_text.text = "點擊圖案可查看該項目的前五名及玩家本身的排名";
    }
    void Task()
    {
        ok.Play();
        btn_obj.SetActive(false);
        choose_s = "Task";
        Info_text.text = "資料載入中";
        StartCoroutine(Loading());
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Rank[0], Behaviour_Bank.SupportingBehaviour_Rank[1], Behaviour_Bank.SupportingBehaviour_Rank[1] + "1"));
    }
    void Learn()
    {
        ok.Play();
        btn_obj.SetActive(false);
        choose_s = "Learn";
        Info_text.text = "資料載入中";
        StartCoroutine(Loading());
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Rank[0], Behaviour_Bank.SupportingBehaviour_Rank[1], Behaviour_Bank.SupportingBehaviour_Rank[1] + "2"));
    }
    void Battle()
    {
        ok.Play();
        btn_obj.SetActive(false);
        choose_s = "Battle";
        Info_text.text = "資料載入中";
        StartCoroutine(Loading());
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Rank[0], Behaviour_Bank.SupportingBehaviour_Rank[1], Behaviour_Bank.SupportingBehaviour_Rank[1] + "3"));
    }
    IEnumerator Loading()
    {
        switch (System_Data.Version)
        {
            case 0:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"A503",30));//5年3班26人
                break;
            case 1:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"B506",30));
                break;
            case 2:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"C507",30));
                break;
            case 3:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"D505",30));
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            Rank_text[i].text = mr.Rank5[i, 0];
            ID_text[i].text = mr.Rank5[i, 1];
            Num_text[i].text = mr.Rank5[i, 2];
        }
        Rank_text[5].text = mr.Learner[0, 0];
        ID_text[5].text = mr.Learner[0, 1];
        Num_text[5].text = mr.Learner[0, 2];
        Info_text.text = "已顯示排名";
        btn_obj.SetActive(true);
    }
    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
    IEnumerator SavingBehaviours(string Bclass, string B1, string B2, string B3)
    {
        StartCoroutine(ml.SetBehaviour("LearnerLog_Behaviour.php", Bclass, B1, B2, B3));
        yield return new WaitForSeconds(0.1f);
    }
}
