using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Deck : MonoBehaviour {

    #region Variable Events
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

    #region Deck
    public GameObject ui_Vanguard, ui_Center, ui_Support;
    public Image[] Image_Card = new Image[22];
    public Image Image_Show;
    //按鈕
    public Button[] Button_VCSA = new Button[4];
    //文字
    public Text Text_Info;
    public Text Text_No_Content, Text_Type_Content, Text_Name_Content, Text_Rarity_Content, Text_ATK_Content, Text_Effect_Content;
    #endregion
    public Button Back_btn;
    public AudioSource ok;

    // Use this for initialization
    void Start () {
        Back_btn.onClick.AddListener(Back);
        Button_VCSA[0].onClick.AddListener(VCSA_V);
        Button_VCSA[1].onClick.AddListener(VCSA_C);
        Button_VCSA[2].onClick.AddListener(VCSA_S);
        Button_VCSA[3].onClick.AddListener(VCSA_A);

        #region Deck PointerClick
        AddEvents.AddTriggersListener(Image_Card[0].gameObject, EPClick, Card_0);
        AddEvents.AddTriggersListener(Image_Card[1].gameObject, EPClick, Card_1);
        AddEvents.AddTriggersListener(Image_Card[2].gameObject, EPClick, Card_2);
        AddEvents.AddTriggersListener(Image_Card[3].gameObject, EPClick, Card_3);
        AddEvents.AddTriggersListener(Image_Card[4].gameObject, EPClick, Card_4);
        AddEvents.AddTriggersListener(Image_Card[5].gameObject, EPClick, Card_5);
        AddEvents.AddTriggersListener(Image_Card[6].gameObject, EPClick, Card_6);
        AddEvents.AddTriggersListener(Image_Card[7].gameObject, EPClick, Card_7);
        AddEvents.AddTriggersListener(Image_Card[8].gameObject, EPClick, Card_8);
        AddEvents.AddTriggersListener(Image_Card[9].gameObject, EPClick, Card_9);
        AddEvents.AddTriggersListener(Image_Card[10].gameObject, EPClick, Card_10);
        AddEvents.AddTriggersListener(Image_Card[11].gameObject, EPClick, Card_11);
        AddEvents.AddTriggersListener(Image_Card[12].gameObject, EPClick, Card_12);
        AddEvents.AddTriggersListener(Image_Card[13].gameObject, EPClick, Card_13);
        AddEvents.AddTriggersListener(Image_Card[14].gameObject, EPClick, Card_14);
        AddEvents.AddTriggersListener(Image_Card[15].gameObject, EPClick, Card_15);
        AddEvents.AddTriggersListener(Image_Card[16].gameObject, EPClick, Card_16);
        AddEvents.AddTriggersListener(Image_Card[17].gameObject, EPClick, Card_17);
        AddEvents.AddTriggersListener(Image_Card[18].gameObject, EPClick, Card_18);
        AddEvents.AddTriggersListener(Image_Card[19].gameObject, EPClick, Card_19);
        AddEvents.AddTriggersListener(Image_Card[20].gameObject, EPClick, Card_20);
        AddEvents.AddTriggersListener(Image_Card[21].gameObject, EPClick, Card_21);
        #endregion

        Card_Class[] card_temp = new Card_Class[22];
        int[] card_status = new int[22];

        for (int i = 0; i < 22; i++)
        {
            card_temp[i] = Card_Data.Card_Get(i);
            card_status[i] = Learner_Data.Learner_GetCard_Status(i);
        }

        for (int i = 0; i < 22; i++)
        {
            if (card_status[i] >= 1)
                Image_Card[i].sprite = Resources.Load("Image/Card/" + card_temp[i].GetPicture(), typeof(Sprite)) as Sprite;
        }
        Image_Show.sprite = Resources.Load("Image/Card/CardBack", typeof(Sprite)) as Sprite;
        Text_No_Content.text = "???";
        Text_Type_Content.text = "???";
        Text_Name_Content.text = "???";
        Text_Rarity_Content.text = "???";
        Text_ATK_Content.text = "???";
        Text_Effect_Content.text = "???";

    }

    void Card_Output(int n)
    {
        Card_Class card_temp = new Card_Class();
        for (int i = 0; i < 22; i++)
            Image_Card[i].color = new Color32(255, 255, 255, 255);

        Image_Card[n].color = new Color32(255, 0, 0, 255);

        int card_status = new int();
        card_status = Learner_Data.Learner_GetCard_Status(n);
        if (card_status == 0)
        {
            Image_Show.sprite = Resources.Load("Image/Card/CardBack", typeof(Sprite)) as Sprite;
            Text_No_Content.text = "???";
            Text_Type_Content.text = "???";
            Text_Name_Content.text = "???";
            Text_Rarity_Content.text = "???";
            Text_ATK_Content.text = "???";
            Text_Effect_Content.text = "???";
            return;
        }
        card_temp = Card_Data.Card_Get(n);
        Image_Show.sprite = Resources.Load("Image/Card/" + card_temp.GetPicture(), typeof(Sprite)) as Sprite;

        Text_No_Content.text = card_temp.GetNo();
        Text_Type_Content.text = card_temp.GetCType();
        Text_Name_Content.text = card_temp.GetName();
        Text_Rarity_Content.text = card_temp.GetRarity();
        Text_ATK_Content.text = card_temp.GetATK().ToString();
        Text_Effect_Content.text = card_temp.GetEffect();
    }

    #region VCSA
    void VCSA_V()
    {
        ok.Play();
        ui_Vanguard.SetActive(true);
        ui_Center.SetActive(false);
        ui_Support.SetActive(false);
    }
    void VCSA_C()
    {
        ok.Play();
        ui_Vanguard.SetActive(false);
        ui_Center.SetActive(true);
        ui_Support.SetActive(false);
    }
    void VCSA_S()
    {
        ok.Play();
        ui_Vanguard.SetActive(false);
        ui_Center.SetActive(false);
        ui_Support.SetActive(true);
    }
    void VCSA_A()
    {
        ok.Play();
        ui_Vanguard.SetActive(true);
        ui_Center.SetActive(true);
        ui_Support.SetActive(true);
    }
    #endregion

    #region Card
    void Card_0(BaseEventData data)
    {
        Card_Output(0);
    }
    void Card_1(BaseEventData data)
    {
        Card_Output(1);
    }
    void Card_2(BaseEventData data)
    {
        Card_Output(2);
    }
    void Card_3(BaseEventData data)
    {
        Card_Output(3);
    }
    void Card_4(BaseEventData data)
    {
        Card_Output(4);
    }
    void Card_5(BaseEventData data)
    {
        Card_Output(5);
    }
    void Card_6(BaseEventData data)
    {
        Card_Output(6);
    }
    void Card_7(BaseEventData data)
    {
        Card_Output(7);
    }
    void Card_8(BaseEventData data)
    {
        Card_Output(8);
    }
    void Card_9(BaseEventData data)
    {
        Card_Output(9);
    }
    void Card_10(BaseEventData data)
    {
        Card_Output(10);
    }
    void Card_11(BaseEventData data)
    {
        Card_Output(11);
    }
    void Card_12(BaseEventData data)
    {
        Card_Output(12);
    }
    void Card_13(BaseEventData data)
    {
        Card_Output(13);
    }
    void Card_14(BaseEventData data)
    {
        Card_Output(14);
    }
    void Card_15(BaseEventData data)
    {
        Card_Output(15);
    }
    void Card_16(BaseEventData data)
    {
        Card_Output(16);
    }
    void Card_17(BaseEventData data)
    {
        Card_Output(17);
    }
    void Card_18(BaseEventData data)
    {
        Card_Output(18);
    }
    void Card_19(BaseEventData data)
    {
        Card_Output(19);
    }
    void Card_20(BaseEventData data)
    {
        Card_Output(20);
    }
    void Card_21(BaseEventData data)
    {
        Card_Output(21);
    }

    #endregion

    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
