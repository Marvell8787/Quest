using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Rank : MonoBehaviour {
    Manager_Rank mr = new Manager_Rank();
    string choose_s;
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
        choose_s = "Task";
        Info_text.text = "資料載入中";
        StartCoroutine(Loading());
    }
    void Learn()
    {
        ok.Play();
        choose_s = "Learn";
        Info_text.text = "資料載入中";
        StartCoroutine(Loading());
    }
    void Battle()
    {
        ok.Play();
        choose_s = "Battle";
        Info_text.text = "資料載入中";
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        switch (System_Data.Version)
        {
            case 0:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"A503",26));//5年3班26人
                break;
            case 1:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"B506",26));
                break;
            case 2:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"C507",26));
                break;
            case 3:
                StartCoroutine(mr.GetRank("Rank.php",choose_s,"D505",24));
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
    }
    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
