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
    public GameObject Name_obj;
    public Text NameContent_text;
    public GameObject Badges_obj;
    public AudioSource ok, cancel, choose;

    // Use this for initialization
    void Start () {

        NameContent_text.text = System_Data.Username;

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
        Info_text.text = "";
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

}
