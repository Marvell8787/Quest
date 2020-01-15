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
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

    #region Home_obj
    public GameObject Home_obj;
    public Image[] HomeIcon = new Image[9];
    #endregion

    #region Info_obj
    public Text Info_text;
    #endregion

    #region TaskInfo_obj
    public GameObject TaskInfo_obj;
    public Text TaskContent_text;
    #endregion

    public AudioSource ok, cancel, choose;

    // Use this for initialization
    void Start () {

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
        AddEvents.AddTriggersListener(TaskInfo_obj, EPEnter, Enter_Task_Goal);
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
        AddEvents.AddTriggersListener(TaskInfo_obj, EPExit, Exit);
        #endregion

        #region Home PointerClick
        AddEvents.AddTriggersListener(HomeIcon[0].gameObject, EPClick, Click_Task);
        AddEvents.AddTriggersListener(HomeIcon[1].gameObject, EPClick, Click_Learn);
        AddEvents.AddTriggersListener(HomeIcon[2].gameObject, EPClick, Click_Battle);
        AddEvents.AddTriggersListener(HomeIcon[3].gameObject, EPClick, Click_Guide);
        AddEvents.AddTriggersListener(HomeIcon[4].gameObject, EPClick, Click_Profile);
        AddEvents.AddTriggersListener(HomeIcon[5].gameObject, EPClick, Click_Shop);
        AddEvents.AddTriggersListener(HomeIcon[6].gameObject, EPClick, Click_Deck);
        AddEvents.AddTriggersListener(HomeIcon[7].gameObject, EPClick, Click_Badges);
        AddEvents.AddTriggersListener(HomeIcon[8].gameObject, EPClick, Click_Rank);
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
        Info_text.text = "請完成所有任務\n學習區可進行練習\n戰鬥區可進行對戰\n可至個人狀態查詢所持有的物品";
    }
    #endregion

    #region Home PointerClick Function
    public void Click_Task(BaseEventData data)
    {
        ok.Play();
    }
    public void Click_Learn(BaseEventData data)
    {
        ok.Play();
        SceneManager.LoadScene("Learn");
    }
    public void Click_Battle(BaseEventData data)
    {
        ok.Play();
        SceneManager.LoadScene("Select_Battle");
    }
    public void Click_Guide(BaseEventData data)
    {
        ok.Play();
        SceneManager.LoadScene("Guide");
    }
    public void Click_Profile(BaseEventData data)
    {
        ok.Play();
        SceneManager.LoadScene("Profile");
    }
    public void Click_Shop(BaseEventData data)
    {
        ok.Play();
        SceneManager.LoadScene("Shop");
    }
    public void Click_Deck(BaseEventData data)
    {
        ok.Play();
        SceneManager.LoadScene("Deck");
    }
    public void Click_Badges(BaseEventData data)
    {
        ok.Play();
    }
    public void Click_Rank(BaseEventData data)
    {
        ok.Play();
    }
    #endregion

}
