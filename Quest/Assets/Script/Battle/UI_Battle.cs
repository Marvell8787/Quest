using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Battle : MonoBehaviour {

    #region Variable Events
    EventTriggerType EPEnter = EventTriggerType.PointerEnter;
    EventTriggerType EPExit = EventTriggerType.PointerExit;
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

    public Button Back_btn;

    #region SelectFight_obj
    public GameObject SelectFight_obj;
    public Text[] Fight = new Text[2];
    #endregion

    #region Content_obj
    public GameObject Content_obj;
    public Button ContentCancel_btn;
    public Text QuestionTypeContent_text, RangeContent_text, TimeContent_text, LPContent_text, DeckContent_text, RewardContent_text, PunishmentContent_text;
    public Button Start_btn;
    #endregion

    #region Learner_obj
    public GameObject Learner_obj;
    public Text LeanerLPContent_text, LearnerDeckContent_text;
    #endregion

    public AudioSource choose, ok, cancel;

    // Use this for initialization
    void Start () {
        Back_btn.onClick.AddListener(Back);

        #region SelectLevel_obj
        AddEvents.AddTriggersListener(Fight[0].gameObject, EPClick, Fight1);
        AddEvents.AddTriggersListener(Fight[1].gameObject, EPClick, Fight2);
        #endregion

        #region Content_obj
        ContentCancel_btn.onClick.AddListener(CancelContent);
        Start_btn.onClick.AddListener(Practice);
        #endregion
    }

    #region SelectLevel
    void Fight1(BaseEventData data)
    {
        ok.Play();
        Content_obj.SetActive(true);
    }
    void Fight2(BaseEventData data)
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
    void Practice()
    {
        ok.Play();
    }
    #endregion

    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
