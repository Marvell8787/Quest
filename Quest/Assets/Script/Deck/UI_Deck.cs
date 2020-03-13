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
    public GameObject R_obj,W_obj,RVanguard_obj, RCenter_obj, RSupport_obj, WVanguard_obj, WCenter_obj, WSupport_obj;
    public Image[] Image_Card = new Image[22];
    public Image[] Image_Card_W = new Image[13];
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

        switch (System_Data.Version)
        {
            case 0:
            case 1:
                R_obj.SetActive(true);
                break;
            case 2:
            case 3:
                W_obj.SetActive(true);
                break;
        }

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

        AddEvents.AddTriggersListener(Image_Card_W[0].gameObject, EPClick, Card_0);
        AddEvents.AddTriggersListener(Image_Card_W[1].gameObject, EPClick, Card_1);
        AddEvents.AddTriggersListener(Image_Card_W[2].gameObject, EPClick, Card_2);
        AddEvents.AddTriggersListener(Image_Card_W[3].gameObject, EPClick, Card_3);
        AddEvents.AddTriggersListener(Image_Card_W[4].gameObject, EPClick, Card_4);
        AddEvents.AddTriggersListener(Image_Card_W[5].gameObject, EPClick, Card_5);
        AddEvents.AddTriggersListener(Image_Card_W[6].gameObject, EPClick, Card_6);
        AddEvents.AddTriggersListener(Image_Card_W[7].gameObject, EPClick, Card_7);
        AddEvents.AddTriggersListener(Image_Card_W[8].gameObject, EPClick, Card_8);
        AddEvents.AddTriggersListener(Image_Card_W[9].gameObject, EPClick, Card_9);
        AddEvents.AddTriggersListener(Image_Card_W[10].gameObject, EPClick, Card_15);
        AddEvents.AddTriggersListener(Image_Card_W[11].gameObject, EPClick, Card_16);
        AddEvents.AddTriggersListener(Image_Card_W[12].gameObject, EPClick, Card_19);


        Card_Class[] card_temp = new Card_Class[22];
        int[] card_status = new int[22];

        for (int i = 0; i < 22; i++)
        {
            card_temp[i] = Card_Data.Card_Get(i);
            card_status[i] = Learner_Data.Learner_GetCard_Status(i);
        }

        switch (System_Data.Version)
        {
            case 0:
            case 1:
                for (int i = 0; i < 22; i++)
                {
                    if (card_status[i] >= 1)
                        Image_Card[i].sprite = Resources.Load("Image/Card/" + card_temp[i].GetPicture(), typeof(Sprite)) as Sprite;
                }
                break;
            case 2:
            case 3:
                for (int i = 0; i < 13; i++)
                {
                    if (i < 10)
                    {
                        if (card_status[i] >= 1)
                            Image_Card_W[i].sprite = Resources.Load("Image/Card/" + card_temp[i].GetPicture(), typeof(Sprite)) as Sprite;
                    }
                    else if(i == 10)
                        Image_Card_W[i].sprite = Resources.Load("Image/Card/" + card_temp[15].GetPicture(), typeof(Sprite)) as Sprite;
                    else if (i == 11)
                        Image_Card_W[i].sprite = Resources.Load("Image/Card/" + card_temp[16].GetPicture(), typeof(Sprite)) as Sprite;
                    else if (i == 12)
                        Image_Card_W[i].sprite = Resources.Load("Image/Card/" + card_temp[19].GetPicture(), typeof(Sprite)) as Sprite;
                }
                break;
            default:
                break;
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
        for (int i = 0; i < 13; i++)
            Image_Card_W[i].color = new Color32(255, 255, 255, 255);


        switch (System_Data.Version)
        {
            case 0:
            case 1:
                Image_Card[n].color = new Color32(255, 0, 0, 255);
                break;
            case 2:
            case 3:
                if(n==15)
                    Image_Card_W[10].color = new Color32(255, 0, 0, 255);
                else if (n == 16)
                    Image_Card_W[11].color = new Color32(255, 0, 0, 255);
                else if (n == 19)
                    Image_Card_W[12].color = new Color32(255, 0, 0, 255);
                else
                    Image_Card_W[n].color = new Color32(255, 0, 0, 255);
                break;
            default:
                break;
        }


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
        switch (System_Data.Version)
        {
            case 0:
            case 1:
                RVanguard_obj.SetActive(true);
                RCenter_obj.SetActive(false);
                RSupport_obj.SetActive(false);
                break;
            case 2:
            case 3:
                WVanguard_obj.SetActive(true);
                WCenter_obj.SetActive(false);
                WSupport_obj.SetActive(false);
                break;
        }
    }
    void VCSA_C()
    {
        ok.Play();
        switch (System_Data.Version)
        {
            case 0:
            case 1:
                RVanguard_obj.SetActive(false);
                RCenter_obj.SetActive(true);
                RSupport_obj.SetActive(false);
                break;
            case 2:
            case 3:
                WVanguard_obj.SetActive(false);
                WCenter_obj.SetActive(true);
                WSupport_obj.SetActive(false);
                break;
        }
    }
    void VCSA_S()
    {
        ok.Play();
        switch (System_Data.Version)
        {
            case 0:
            case 1:
                RVanguard_obj.SetActive(false);
                RCenter_obj.SetActive(false);
                RSupport_obj.SetActive(true);
                break;
            case 2:
            case 3:
                WVanguard_obj.SetActive(false);
                WCenter_obj.SetActive(false);
                WSupport_obj.SetActive(true);
                break;
        }
    }
    void VCSA_A()
    {
        ok.Play();
        switch (System_Data.Version)
        {
            case 0:
            case 1:
                RVanguard_obj.SetActive(true);
                RCenter_obj.SetActive(true);
                RSupport_obj.SetActive(true);
                break;
            case 2:
            case 3:
                WVanguard_obj.SetActive(true);
                WCenter_obj.SetActive(true);
                WSupport_obj.SetActive(true);
                break;
        }
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
