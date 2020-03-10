using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Learn : MonoBehaviour {

    private int choose_n = 0;
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    public Button Back_btn;
    public Text Coin_text, Point_text, Mistake_text;
    public Image Point_img, Mistake_img;

    #region MaterialOrLevel_obj
    public GameObject MaterialOrLevel_obj;
    public Button Material_btn, Level_btn;
    #endregion

    #region SelectLevel_obj
    public GameObject SelectLevel_obj;
    public Button SelectLevelCancel_btn;
    public Text[] Level = new Text[5];
    #endregion

    #region Info_obj
    public Text Info_text;
    #endregion

    #region Content_obj
    public GameObject Content_obj;
    public Button ContentCancel_btn;
    public Text QuestionTypeContent_text, RangeContent_text, RewardContent_text, PunishmentContent_text, HighestScoreContent_text;
    public Button Start_btn;
    #endregion

    public AudioSource choose, ok, cancel;

    // Use this for initialization
    void Start () {
        Back_btn.onClick.AddListener(Back);
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
        Coin_text.text = Learner_Data.Learner_GetData("Coin").ToString();

        #region MaterialOrLevel_obj
        Material_btn.onClick.AddListener(GoMaterial);
        Level_btn.onClick.AddListener(OpenLevel);
        #endregion

        #region SelectLevel_obj
        SelectLevelCancel_btn.onClick.AddListener(CancelSelectLevel);
        Level_btn.onClick.AddListener(OpenLevel);
        AddEvents.AddTriggersListener(Level[0].gameObject, EPClick, Level1);
        AddEvents.AddTriggersListener(Level[1].gameObject, EPClick, Level2);
        AddEvents.AddTriggersListener(Level[2].gameObject, EPClick, Level3);
        AddEvents.AddTriggersListener(Level[3].gameObject, EPClick, Level4);
        AddEvents.AddTriggersListener(Level[4].gameObject, EPClick, Level5);
        #endregion
        
        #region Content_obj
        ContentCancel_btn.onClick.AddListener(CancelContent);
        Start_btn.onClick.AddListener(Practice);
        #endregion
    }
    void GoMaterial(){
        ok.Play();
        SceneManager.LoadScene("Material");
    }
    void OpenLevel(){
        ok.Play();
        MaterialOrLevel_obj.gameObject.SetActive(false);
        SelectLevel_obj.SetActive(true);
        Level_Class[] level_temp = new Level_Class[5];
        for (int i = 0; i < 5; i++)
        {
            level_temp[i] = Level_Data.Level_Get(i);
            Level[i].text = level_temp[i].GetTitle();
        }
    }

    #region SelectLevel
    void CancelSelectLevel() {
        cancel.Play();
        MaterialOrLevel_obj.gameObject.SetActive(true);
        SelectLevel_obj.SetActive(false);
        Content_obj.SetActive(false);
    }
    void Level1(BaseEventData data){
        ok.Play();
        choose_n = 0;
        ShowContent(0);
    }
    void Level2(BaseEventData data)
    {
        ok.Play();
        choose_n = 1;
        ShowContent(1);
    }
    void Level3(BaseEventData data)
    {
        ok.Play();
        choose_n = 2;
        ShowContent(2);
    }
    void Level4(BaseEventData data)
    {
        ok.Play();
        choose_n = 3;
        ShowContent(3);
    }
    void Level5(BaseEventData data)
    {
        ok.Play();
        choose_n = 4;
        ShowContent(4);
    }
    #endregion

    #region Content_Obj
    void CancelContent()
    {
        cancel.Play();
        Content_obj.SetActive(false);
    }
    void Practice(){
        ok.Play();
        switch (choose_n)
        {
            case 3:
                Question_Data.Question_Init(choose_n, 1, 10, 5);
                break;
            case 4:
                Question_Data.Question_Init(choose_n, 1, 2, 5);
                break;
            default:
                Question_Data.Question_Init(choose_n, 1, 8, 5);
                break;
        }
        SceneManager.LoadScene("Level");
    }
    #endregion

    void ShowContent(int n)
    {
        Level_Class level_temp = new Level_Class();
        level_temp = Level_Data.Level_Get(n);
        Content_obj.SetActive(true);
        QuestionTypeContent_text.text = level_temp.GetQuestionType();
        RangeContent_text.text = level_temp.GetRange();
        RewardContent_text.text = level_temp.GetReward();
        PunishmentContent_text.text = level_temp.GetPunishment();
        HighestScoreContent_text.text = level_temp.GetHighestScore();
    }

    void Back() {
        ok.Play();
        SceneManager.LoadScene("Home");
    }

}
