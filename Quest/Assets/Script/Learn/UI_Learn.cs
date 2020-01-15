using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Learn : MonoBehaviour {

    #region Variable Events
    EventTriggerType EPEnter = EventTriggerType.PointerEnter;
    EventTriggerType EPExit = EventTriggerType.PointerExit;
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

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
        #region MaterialOrLevel_obj
        Material_btn.onClick.AddListener(GoMaterial);
        Level_btn.onClick.AddListener(OpenLevel);
        #endregion

        #region SelectLevel_obj
        SelectLevelCancel_btn.onClick.AddListener(CancelSelectLevel);
        Level_btn.onClick.AddListener(OpenLevel);
        AddEvents.AddTriggersListener(Level[0].gameObject, EPClick, Level1);
        AddEvents.AddTriggersListener(Level[1].gameObject, EPClick, Level1);
        AddEvents.AddTriggersListener(Level[2].gameObject, EPClick, Level1);
        AddEvents.AddTriggersListener(Level[3].gameObject, EPClick, Level1);
        AddEvents.AddTriggersListener(Level[4].gameObject, EPClick, Level1);
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
        Content_obj.SetActive(true);
    }
    void Level2(BaseEventData data)
    {
        ok.Play();
        Content_obj.SetActive(true);
    }
    void Level3(BaseEventData data)
    {
        ok.Play();
        Content_obj.SetActive(true);
    }
    void Level4(BaseEventData data)
    {
        ok.Play();
        Content_obj.SetActive(true);
    }
    void Level5(BaseEventData data)
    {
        ok.Play();
        Content_obj.SetActive(true);
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
    }
    #endregion

    void Back() {
        ok.Play();
        SceneManager.LoadScene("Home");
    }

}
