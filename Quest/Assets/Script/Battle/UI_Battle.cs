using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Battle : MonoBehaviour
{

    private int choose_n = 0;
    private static Manager_log ml = new Manager_log();

    #region Variable Events
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

    public Button Back_btn;
    public Text ItemContent_text, Point_text, Mistake_text;
    public Image Point_img, Mistake_img;
    public Text Battle_Info;

    #region SelectBattle_obj
    public GameObject SelectFight_obj;
    public Text[] Fight = new Text[2];
    #endregion

    #region Content_obj
    public GameObject Content_obj, ContentInfo_obj;
    public Button ContentCancel_btn;
    public Text QuestionTypeContent_text, RangeContent_text, TimeContent_text, LPContent_text, DeckContent_text, RewardContent_text, PunishmentContent_text;
    public Button Start_btn,Info_btn;
    #endregion

    #region Learner_obj
    public GameObject Learner_obj;
    public Text LeanerLPContent_text, LearnerDeckContent_text;
    #endregion

    public AudioSource choose, ok, cancel;

    // Use this for initialization
    void Start()
    {
        switch (System_Data.Version)
        {
            case 0:
            case 2:
                Point_text.text = Learner_Data.Learner_GetPoints_Status(2).ToString();
                Mistake_text.text = Learner_Data.Learner_GetData("Mistakes_Num").ToString();
                break;
            default:
                Point_img.gameObject.SetActive(false);
                Mistake_img.gameObject.SetActive(false);
                Point_text.gameObject.SetActive(false);
                Mistake_text.gameObject.SetActive(false);
                break;
        }
        ItemContent_text.text = Learner_Data.Learner_GetData("Crystal").ToString();
        Back_btn.onClick.AddListener(Back);
        LearnerDeckContent_text.text = Learner_Data.Learner_GetData("Cards_Num").ToString();
        Battle_Class[] battle_temp = new Battle_Class[2];
        for (int i = 0; i < 2; i++)
        {
            battle_temp[i] = Battle_Data.Battle_Get(i);
            Fight[i].text = "";
        }

        #region SelectBattle_obj
        AddEvents.AddTriggersListener(Fight[0].gameObject, EPClick, Fight1);
        AddEvents.AddTriggersListener(Fight[1].gameObject, EPClick, Fight2);
        #endregion

        #region Content_obj
        ContentCancel_btn.onClick.AddListener(CancelContent);
        Start_btn.onClick.AddListener(Practice);
        Info_btn.onClick.AddListener(Info);
        #endregion

        for (int i = 0; i < 2; i++)
        {
            battle_temp[i] = Battle_Data.Battle_Get(i);
            Fight[i].text = battle_temp[i].GetTitle();
        }
    }

    #region SelectBattle
    void Fight1(BaseEventData data)
    {
        ok.Play();
        choose_n = 0;
        ShowContent(0);
        Content_obj.SetActive(true);
        StartCoroutine(SavingBehaviours(Behaviour_Bank.GamingBehaviour, Behaviour_Bank.GamingBehaviour_Battle[0], Behaviour_Bank.GamingBehaviour_Battle[1], Behaviour_Bank.GamingBehaviour_Battle[1] + "1" ));
    }
    void Fight2(BaseEventData data)
    {
        ok.Play();
        choose_n = 1;
        ShowContent(1);
        Content_obj.SetActive(true);
        StartCoroutine(SavingBehaviours(Behaviour_Bank.GamingBehaviour, Behaviour_Bank.GamingBehaviour_Battle[0], Behaviour_Bank.GamingBehaviour_Battle[1], Behaviour_Bank.GamingBehaviour_Battle[1] + "2"));

    }
    #endregion

    #region Content_Obj
    void CancelContent()
    {
        cancel.Play();
        Content_obj.SetActive(false);
        ContentInfo_obj.SetActive(false);
    }
    void Practice()
    {
        Battle_Class battle_temp = new Battle_Class();
        battle_temp = Battle_Data.Battle_Get(choose_n);
        int n3 = int.Parse(battle_temp.GetTime());
        ok.Play();
        Question_Data.Question_Init(5 + choose_n, 1, 8, n3, 0);
        Player_Data.Player_Init(choose_n);
        Player_Data.Shuffle(0);
        Player_Data.Shuffle(1);
        Player_Data.Deal();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.GamingBehaviour, Behaviour_Bank.GamingBehaviour_Battle[0], Behaviour_Bank.GamingBehaviour_Battle[3], Behaviour_Bank.GamingBehaviour_Battle[3] + (choose_n+1).ToString()));
        SceneManager.LoadScene("Fight");
    }
    void Info()
    {
        ok.Play();
        ContentInfo_obj.SetActive(true);
        StartCoroutine(SavingBehaviours(Behaviour_Bank.GamingBehaviour, Behaviour_Bank.GamingBehaviour_Battle[0], Behaviour_Bank.GamingBehaviour_Battle[2], Behaviour_Bank.GamingBehaviour_Battle[2] + (choose_n + 1).ToString()));
    }
    #endregion

    void ShowContent(int n)
    {
        ContentInfo_obj.SetActive(false);
        Battle_Class battle_temp = new Battle_Class();
        battle_temp = Battle_Data.Battle_Get(n);
        Content_obj.SetActive(true);
        Battle_Info.text = "點選查看內容可查看更詳細的資訊，點選開始會開始戰鬥";
        QuestionTypeContent_text.text = battle_temp.GetQuestionType();
        RangeContent_text.text = battle_temp.GetRange();
        RewardContent_text.text = battle_temp.GetReward();
        PunishmentContent_text.text = battle_temp.GetPunishment();
        TimeContent_text.text = battle_temp.GetTime();
        LPContent_text.text = battle_temp.GetLP();
        DeckContent_text.text = battle_temp.GetDeck();
    }
    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }

    IEnumerator SavingBehaviours(string Bclass,string B1,string B2,string B3)
    {
        StartCoroutine(ml.SetBehaviour("LearnerLog_Behaviour.php", Bclass, B1, B2, B3));
        yield return new WaitForSeconds(0.1f);
    }
}
