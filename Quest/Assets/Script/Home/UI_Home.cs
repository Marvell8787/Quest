using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Home : MonoBehaviour {

    #region Variable Events
    EventTriggerType EPEnter = EventTriggerType.PointerEnter;
    EventTriggerType EPExit = EventTriggerType.PointerExit;
    #endregion

    #region Home_obj
    public GameObject Home_obj;
    public Button[] HomeIcon = new Button[9];
    #endregion

    #region Info_obj
    public Text Info_text;
    #endregion
    private static Manager_log ml = new Manager_log();
    public Button Save;
    public GameObject Name_obj;
    public Text NameContent_text;
    public GameObject Badges_obj;
    public AudioSource ok, cancel, choose;

    // Use this for initialization
    void Start () {

        Save.onClick.AddListener(SaveData);
        NameContent_text.text = System_Data.Username;
        /*
        switch (System_Data.Version)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
            case 3:
                HomeIcon[5].gameObject.SetActive(false);
                HomeIcon[7].gameObject.SetActive(false);
                break;
            default:
                break;
        }*/

        #region Home PointerEnter
        AddEvents.AddTriggersListener(HomeIcon[0].gameObject, EPEnter, Enter_Task);
        AddEvents.AddTriggersListener(HomeIcon[1].gameObject, EPEnter, Enter_Learn);
        AddEvents.AddTriggersListener(HomeIcon[2].gameObject, EPEnter, Enter_Battle);
        AddEvents.AddTriggersListener(HomeIcon[3].gameObject, EPEnter, Enter_Guide);
        AddEvents.AddTriggersListener(HomeIcon[4].gameObject, EPEnter, Enter_Profile);
        AddEvents.AddTriggersListener(HomeIcon[5].gameObject, EPEnter, Enter_Shop);
        AddEvents.AddTriggersListener(HomeIcon[6].gameObject, EPEnter, Enter_Deck);
        AddEvents.AddTriggersListener(HomeIcon[7].gameObject, EPEnter, Enter_Badges);
        AddEvents.AddTriggersListener(HomeIcon[8].gameObject, EPEnter, Enter_Rank);
        #endregion

        #region Home PointerExit
        AddEvents.AddTriggersListener(HomeIcon[0].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[1].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[2].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[3].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[4].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[5].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[6].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[7].gameObject, EPExit, Exit);
        AddEvents.AddTriggersListener(HomeIcon[8].gameObject, EPExit, Exit);
        #endregion

        #region Home PointerClick
        HomeIcon[0].onClick.AddListener(Click_Task);
        HomeIcon[1].onClick.AddListener(Click_Learn);
        HomeIcon[2].onClick.AddListener(Click_Battle);
        HomeIcon[3].onClick.AddListener(Click_Guide);
        HomeIcon[4].onClick.AddListener(Click_Profile);
        HomeIcon[5].onClick.AddListener(Click_Shop);
        HomeIcon[6].onClick.AddListener(Click_Deck);
        HomeIcon[7].onClick.AddListener(Click_Badges);
        HomeIcon[8].onClick.AddListener(Click_Rank);
        #endregion  
    }

    #region Home PointerEnter Function
    void Enter_Task(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "任務區，請玩家完成所有任務!";
    }
    void Enter_Learn(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "學習區，在這邊可以練習任務中學習類型的關卡";
    }
    void Enter_Battle(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "戰鬥區，在這邊可以模擬任務中戰鬥類型的對手";
    }
    void Enter_Guide(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "導覽區，在這邊可以查看關於此遊戲的相關說明";
    }
    void Enter_Profile(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "狀態區，在這邊可以查看個人遊戲歷程及持有物的狀態";
    }
    void Enter_Shop(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "商店區，在這邊可以領取或購買遊戲相關的道具";
    }
    void Enter_Deck(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "牌組區，在這邊可以查看個人持有的卡牌";
    }
    void Enter_Badges(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "獎章區，在這邊可以查看個人能獲得的獎章及獎章獲得的條件";
    }
    void Enter_Rank(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "排行榜區，在這邊可以查看個人在團體中的排名";
    }
    void Enter_Task_Goal(BaseEventData data)
    {
        choose.Play();
        Info_text.text = "任務目標區，顯示個人目前完成的任務數量";
    }
    #endregion

    #region Home PointerExit Function
    void Exit(BaseEventData data)
    {
        Info_text.text = "請完成所有任務\n學習區可以練習題目\n戰鬥區可模擬跟電腦戰鬥的模式\n可至個人狀態查詢所持有的物品";
    }
    #endregion

    #region Home PointerClick Function
    public void Click_Task()
    {
        ok.Play();
        SceneManager.LoadScene("Task");
    }
    public void Click_Learn()
    {
        ok.Play();
        SceneManager.LoadScene("Learn");
    }
    public void Click_Battle()
    {
        ok.Play();
        SceneManager.LoadScene("Battle");
    }
    public void Click_Guide()
    {
        ok.Play();
        SceneManager.LoadScene("Guide");
    }
    public void Click_Profile()
    {
        ok.Play();
        SceneManager.LoadScene("Profile");
    }
    public void Click_Shop()
    {
        ok.Play();
        SceneManager.LoadScene("Shop");
    }
    public void Click_Deck()
    {
        ok.Play();
        SceneManager.LoadScene("Deck");
    }
    public void Click_Badges()
    {
        ok.Play();
        switch (System_Data.Version)
        {
            case 0:
            case 1:
                Info_text.text = "點選任一獎章可查看該獎章的獲得方式";
                break;
            case 2:
            case 3:
                Info_text.text = "不開放";
                break;
            default:
                break;
        }
        Name_obj.SetActive(false);
        Home_obj.SetActive(false);
        Badges_obj.SetActive(true);
    }
    public void Click_Rank()
    {
        ok.Play();
        SceneManager.LoadScene("Rank");
    }
    #endregion

    #region SaveLog
    public void SaveData()
    {
        ok.Play();
        Info_text.text = "存檔中，請不要點選任何物件";
        Home_obj.SetActive(false);
        Save.enabled = false;
        StartCoroutine(Saving());
    }
    IEnumerator Saving()
    {
        Debug.Log(Learner_Data.Learner_Behavior_Get());
        for(int i = 0; i < 7; i++)
        {
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Task"+ (i+1) +"_Num", Learner_Data.Learner_GetData("Task_Num", i)));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Task" + (i + 1) + "_Success", Learner_Data.Learner_GetData("Task_Success", i)));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Task" + (i + 1) + "_Fail", Learner_Data.Learner_GetData("Task_Fail", i)));
            yield return new WaitForSeconds(0.1f);
        }
        for(int i = 0; i<5; i++)
        {
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Learn" + (i + 1) + "_Num", Learner_Data.Learner_GetData("Learn_Num", i)));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Learn" + (i + 1) + "_Success", Learner_Data.Learner_GetData("Learn_Success", i)));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Learn" + (i + 1) + "_Fail", Learner_Data.Learner_GetData("Learn_Fail", i)));
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 2; i++)
        {
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Battle" + (i + 1) + "_Num", Learner_Data.Learner_GetData("Battle_Num", i)));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Battle" + (i + 1) + "_Success", Learner_Data.Learner_GetData("Battle_Success", i)));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Battle" + (i + 1) + "_Fail", Learner_Data.Learner_GetData("Battle_Fail", i)));
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Score	", Learner_Data.Learner_GetData("Score")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Score_Accumulation", Learner_Data.Learner_GetData("Score_Accumulation")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Coin", Learner_Data.Learner_GetData("Coin")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Coin_Accumulation", Learner_Data.Learner_GetData("Coin_Accumulation")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Crystal", Learner_Data.Learner_GetData("Crystal")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Crystal_Accumulation", Learner_Data.Learner_GetData("Crystal_Accumulation")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Badges_Num", Learner_Data.Learner_GetData("Badges_Num")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Cards_Num", Learner_Data.Learner_GetData("Cards_Num")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Points_Num", Learner_Data.Learner_GetData("Points_Num")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Mistakes_Num", Learner_Data.Learner_GetData("Mistakes_Num")));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ml.SetBehavior("LearnerLog_Behavior.php", "Learner_Behaviors", Learner_Data.Learner_Behavior_Get()));
        yield return new WaitForSeconds(1);
        for(int i = 0; i < 22; i++)
        { 
            StartCoroutine(ml.SetData("Learner_CardSave.php", "Cardstatus_" + i.ToString(), Learner_Data.Learner_GetCard_Status(i)));
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(ml.SetData("Learner_PointSave.php", "Pointstatus_Task", Learner_Data.Learner_GetPoints_Status(0)));
        yield return new WaitForSeconds(1);
        StartCoroutine(ml.SetData("Learner_PointSave.php", "Pointstatus_Learn", Learner_Data.Learner_GetPoints_Status(1)));
        yield return new WaitForSeconds(1);
        StartCoroutine(ml.SetData("Learner_PointSave.php", "Pointstatus_Battle", Learner_Data.Learner_GetPoints_Status(2)));
        yield return new WaitForSeconds(1);
        StartCoroutine(ml.SetData("Learner_MistakeSave.php", "Mistake_Warning", Learner_Data.Learner_GetMistakes_Status(0)));
        yield return new WaitForSeconds(1);
        StartCoroutine(ml.SetData("Learner_MistakeSave.php", "Mistake_YC", Learner_Data.Learner_GetMistakes_Status(1)));
        yield return new WaitForSeconds(1);
        StartCoroutine(ml.SetData("Learner_MistakeSave.php", "Mistake_RC", Learner_Data.Learner_GetMistakes_Status(2)));
        yield return new WaitForSeconds(1);


        Home_obj.SetActive(true);
        Save.enabled = true;
        Info_text.text = "存檔完成";
    }
    #endregion
}
