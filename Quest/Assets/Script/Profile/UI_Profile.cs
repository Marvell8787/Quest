using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Profile : MonoBehaviour {

    #region Variable
    private int Status_Page = 1; //1 2 3
    private int Item_Page = 1; //1 2 3
    #endregion

    public GameObject ui_RW, ui_R, ui_W;
 
    public Button Back_btn;
    public AudioSource PageTurnning, ok;

    #region Status
    public Button Button_Status_Left, Button_Status_Right;
    public Image Image_Status;
    public Text Text_Status,Text_Status_PageUp;
    public Text Text_NumContent,Text_SuccesContent, Text_FailContent;
    #endregion

    public Text Text_Item_PageUp, Text_Item_PageDown;
    public Button Button_Item_Left, Button_Item_Right;
    #region RW
    public Text Text_ScoreContent, Text_CoinContent, Text_CrystalContent;
    #endregion
    #region R
    public Text Text_VContent, Text_CContent, Text_SContent;
    public Text Text_RTaskContent, Text_RLearnContent, Text_RBattleContent;
    #endregion
    #region W
    public Text Text_WTaskContent, Text_WLearnContent, Text_WBattleContent;
    public Text Text_WarningContent, Text_YCContent, Text_RCContent;
    #endregion

    // Use this for initialization
    void Start () {
        Button_Status_Left.onClick.AddListener(Status_PageDown);
        Button_Status_Right.onClick.AddListener(Status_PageUp);
        Button_Item_Left.onClick.AddListener(Item_PageDown);
        Button_Item_Right.onClick.AddListener(Item_PageUp);
        Back_btn.onClick.AddListener(Back);

        StatusShowContent(1);
        ItemShowContent(1);

        #region RW R W
        //RW
        Text_ScoreContent.text = Learner_Data.Learner_GetData("Score").ToString();
        Text_CoinContent.text = Learner_Data.Learner_GetData("Coin").ToString();
        Text_CrystalContent.text = Learner_Data.Learner_GetData("Crystal").ToString();
        //R
        Text_VContent.text = Learner_Data.Learner_GetCardsGet_Status(0).ToString();
        Text_CContent.text = Learner_Data.Learner_GetCardsGet_Status(1).ToString();
        Text_SContent.text = Learner_Data.Learner_GetCardsGet_Status(2).ToString();
        Text_RTaskContent.text = Learner_Data.Learner_GetBadges_GetStatus(0).ToString();
        Text_RLearnContent.text = Learner_Data.Learner_GetBadges_GetStatus(1).ToString();
        Text_RBattleContent.text = Learner_Data.Learner_GetBadges_GetStatus(2).ToString();
        //W
        Text_WTaskContent.text = Learner_Data.Learner_GetPoints_Status(0).ToString();
        Text_WLearnContent.text = Learner_Data.Learner_GetPoints_Status(1).ToString();
        Text_WBattleContent.text = Learner_Data.Learner_GetPoints_Status(2).ToString();
        Text_WarningContent.text = Learner_Data.Learner_GetMistakes_Status(0).ToString();
        Text_YCContent.text = Learner_Data.Learner_GetMistakes_Status(1).ToString();
        Text_RCContent.text = Learner_Data.Learner_GetMistakes_Status(2).ToString();
        #endregion
    }
    #region Status Function
    void Status_PageUp()
    {
        PageTurnning.Play();
        Status_Page++;
        if (Status_Page == 4)
            Status_Page = 1;
        StatusShowContent(Status_Page);
    }
    void Status_PageDown()
    {
        PageTurnning.Play();
        Status_Page--;
        if (Status_Page == 0)
            Status_Page = 3;
        StatusShowContent(Status_Page);
    }
    void StatusShowContent(int n)
    {
        int _Task_Num = 0, _Learn_Num = 0, _Battle_Num = 0;
        int _Task_Success = 0, _Learn_Success = 0, _Battle_Success = 0;
        int _Task_Fail = 0, _Learn_Fail = 0, _Battle_Fail = 0;
        for (int i = 0; i < 7; i++)
        {
            _Task_Num += Learner_Data.Learner_GetData("Task_Num", i);
            _Task_Success += Learner_Data.Learner_GetData("Task_Success", i);
            _Task_Fail += Learner_Data.Learner_GetData("Task_Fail", i);
        }
            
        for (int i = 0; i < 5; i++)
        {
            _Learn_Num += Learner_Data.Learner_GetData("Learn_Num", i);
            _Learn_Success += Learner_Data.Learner_GetData("Learn_Success", i);
            _Learn_Fail += Learner_Data.Learner_GetData("Learn_Fail", i);
        }
        for (int i = 0; i < 2; i++)
        {
            _Battle_Num += Learner_Data.Learner_GetData("Battle_Num", i);
            _Battle_Success += Learner_Data.Learner_GetData("Battle_Success", i);
            _Battle_Fail += Learner_Data.Learner_GetData("Battle_Fail", i);
        }
        Text_Status_PageUp.text = Status_Page.ToString();

        switch (n)
        {
            case 1:
                Image_Status.sprite = Resources.Load("Image/Home/Task_Item", typeof(Sprite)) as Sprite;
                Text_Status.text = "任務";
                Text_SuccesContent.text = _Task_Success.ToString();
                Text_FailContent.text = _Task_Fail.ToString();
                Text_NumContent.text = _Task_Num.ToString();
                break;
            case 2:
                Image_Status.sprite = Resources.Load("Image/Home/Learn_Item", typeof(Sprite)) as Sprite;
                Text_Status.text = "學習";
                Text_SuccesContent.text = _Learn_Success.ToString();
                Text_FailContent.text = _Learn_Fail.ToString();
                Text_NumContent.text = _Learn_Num.ToString();
                break;
            case 3:
                Image_Status.sprite = Resources.Load("Image/Home/Battle_Item", typeof(Sprite)) as Sprite;
                Text_Status.text = "戰鬥";
                Text_SuccesContent.text = _Battle_Success.ToString();
                Text_FailContent.text = _Battle_Fail.ToString();
                Text_NumContent.text = _Battle_Num.ToString();
                break;
            default:
                break;
        }
    }
    #endregion
    #region Item Function
    void Item_PageUp()
    {
        PageTurnning.Play();
        Item_Page++;
        if (Item_Page == 4)
            Item_Page = 1;
        ItemShowContent(Item_Page);
    }
    void Item_PageDown()
    {
        PageTurnning.Play();
        Item_Page--;
        if (Item_Page == 0)
            Item_Page = 3;
        ItemShowContent(Item_Page);
    }
    void ItemShowContent(int n)
    {
        Text_Item_PageUp.text = Item_Page.ToString();
        switch (n)
        {
            case 1:
                ui_RW.SetActive(true);
                ui_R.SetActive(false);
                ui_W.SetActive(false);
                break;
            case 2:
                ui_RW.SetActive(false);
                ui_R.SetActive(true);
                ui_W.SetActive(false);
                break;
            case 3:
                ui_RW.SetActive(false);
                ui_R.SetActive(false);
                ui_W.SetActive(true);
                break;
            default:
                break;
        }
    }
    #endregion
    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
