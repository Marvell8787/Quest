using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Shop : MonoBehaviour {

    #region Variable
    private int choose_n = 10;
    private int[] check_n = new int[9];
    #endregion

    #region Shop
    public Button[] Item_btn = new Button[9];
    public Text[] Have_text = new Text[3];
    public Text ShopInfo_text;
    public Button Buy_btn, Back_btn;
    public AudioSource ok, choose;
    #endregion


    // Use this for initialization
    void Start () {
        ShopInfo_text.text = "點選圖案可查看商品資訊";
        for (int i = 0; i < 9; i++)
            check_n[i] = 0;
        Check();

        Have_text[0].text = Learner_Data.Learner_GetData("Score").ToString();
        Have_text[1].text = Learner_Data.Learner_GetData("Coin").ToString();
        Have_text[2].text = Learner_Data.Learner_GetData("Crystal").ToString();

        #region Item
        Item_btn[0].onClick.AddListener(Item1);
        Item_btn[1].onClick.AddListener(Item2);
        Item_btn[2].onClick.AddListener(Item3);
        Item_btn[3].onClick.AddListener(Item4);
        Item_btn[4].onClick.AddListener(Item5);
        Item_btn[5].onClick.AddListener(Item6);
        Item_btn[6].onClick.AddListener(Item7);
        Item_btn[7].onClick.AddListener(Item8);
        Item_btn[8].onClick.AddListener(Item9);
        #endregion

        Buy_btn.onClick.AddListener(Buy);
        Back_btn.onClick.AddListener(Back);

    }
    #region Shop Item
    void Item1()
    {
        choose.Play();
        choose_n = 0;
        Check();
        Item_btn[0].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 分數才可購買";
        if (check_n[0] == 1 || Learner_Data.Learner_GetData("Score") < 150)
            Buy_btn.interactable = false;
        else if (check_n[0] == 0 && Learner_Data.Learner_GetData("Score") >= 150)
            Buy_btn.interactable = true;
    }
    void Item2()
    {
        choose.Play();
        choose_n = 1;
        Check();
        Item_btn[1].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 分數才可購買";
        if (check_n[1] == 1 || Learner_Data.Learner_GetData("Score") < 150)
            Buy_btn.interactable = false;
        else if (check_n[1] == 0 && Learner_Data.Learner_GetData("Score") >= 150)
            Buy_btn.interactable = true;
    }
    void Item3()
    {
        choose.Play();
        choose_n = 2;
        Check();
        Item_btn[2].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 金幣才可購買";
        if (check_n[2] == 1 || Learner_Data.Learner_GetData("Coin") < 150)
            Buy_btn.interactable = false;
        else if (check_n[2] == 0 && Learner_Data.Learner_GetData("Coin") >= 150)
            Buy_btn.interactable = true;
    }
    void Item4()
    {
        choose.Play();
        choose_n = 3;
        Check();
        Item_btn[3].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 金幣才可購買";
        if (check_n[3] == 1 || Learner_Data.Learner_GetData("Coin") < 150)
            Buy_btn.interactable = false;
        else if (check_n[3] == 0 && Learner_Data.Learner_GetData("Coin") >= 150)
            Buy_btn.interactable = true;
    }
    void Item5()
    {
        choose.Play();
        choose_n = 4;
        Check();
        Item_btn[4].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 金幣才可購買";
        if (check_n[4] == 1 || Learner_Data.Learner_GetData("Coin") < 150)
            Buy_btn.interactable = false;
        else if (check_n[4] == 0 && Learner_Data.Learner_GetData("Coin") >= 150)
            Buy_btn.interactable = true;
    }
    void Item6()
    {
        choose.Play();
        choose_n = 5;
        Check();
        Item_btn[5].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 金幣才可購買";
        if (check_n[5] == 1 || Learner_Data.Learner_GetData("Coin") < 150)
            Buy_btn.interactable = false;
        else if (check_n[5] == 0 && Learner_Data.Learner_GetData("Coin") >= 150)
            Buy_btn.interactable = true;
    }
    void Item7()
    {
        choose.Play();
        choose_n = 6;
        Check();
        Item_btn[6].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 金幣才可購買";
        if (check_n[6] == 1 || Learner_Data.Learner_GetData("Coin") < 150)
            Buy_btn.interactable = false;
        else if (check_n[6] == 0 && Learner_Data.Learner_GetData("Coin") >= 150)
            Buy_btn.interactable = true;
    }
    void Item8()
    {
        choose.Play();
        choose_n = 7;
        Check();
        Item_btn[7].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 水晶才可購買";
        if (check_n[7] == 1 || Learner_Data.Learner_GetData("Crystal") < 150)
            Buy_btn.interactable = false;
        else if (check_n[7] == 0 && Learner_Data.Learner_GetData("Crystal") >= 150)
            Buy_btn.interactable = true;
    }
    void Item9()
    {
        choose.Play();
        choose_n = 8;
        Check();
        Item_btn[8].image.color = new Color32(255, 0, 0, 255);
        ShopInfo_text.text = "需要 150 水晶才可購買";
        if (check_n[8] == 1 || Learner_Data.Learner_GetData("Crystal") < 150)
            Buy_btn.interactable = false;
        else if (check_n[8] == 0 && Learner_Data.Learner_GetData("Crystal") >= 150)
            Buy_btn.interactable = true;
    }

    #endregion


    void Buy()
    {
        ok.Play();
        switch (choose_n)
        {
            case 0:
                Learner_Data.Learner_ChangeCard_Status(17);
                Learner_Data.Learner_ChangeCardsGet_Status(1);
                Learner_Data.Learner_Add("Score", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(1);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 1:
                Learner_Data.Learner_ChangeCard_Status(18);
                Learner_Data.Learner_ChangeCardsGet_Status(1);
                Learner_Data.Learner_Add("Score", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(1);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 2:
                Learner_Data.Learner_ChangeCard_Status(10);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Coin", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 3:
                Learner_Data.Learner_ChangeCard_Status(11);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Coin", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 4:
                Learner_Data.Learner_ChangeCard_Status(12);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Coin", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 5:
                Learner_Data.Learner_ChangeCard_Status(13);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Coin", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 6:
                Learner_Data.Learner_ChangeCard_Status(14);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Coin", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(0);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 7:
                Learner_Data.Learner_ChangeCard_Status(20);
                Learner_Data.Learner_ChangeCardsGet_Status(2);
                Learner_Data.Learner_Add("Crystal", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(2);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;
            case 8:
                Learner_Data.Learner_ChangeCard_Status(21);
                Learner_Data.Learner_ChangeCardsGet_Status(2);
                Learner_Data.Learner_Add("Crystal", 0, -150);
                Learner_Data.Learner_ChangeCardsGet_Status(2);
                Learner_Data.Learner_Add("Cards_Num", 0, 1);
                break;

            default:
                break;
        }
        ShopInfo_text.text = "購買成功!";
        Check();
        Have_text[0].text = Learner_Data.Learner_GetData("Score").ToString();
        Have_text[1].text = Learner_Data.Learner_GetData("Coin").ToString();
        Have_text[2].text = Learner_Data.Learner_GetData("Crystal").ToString();
        Buy_btn.interactable = false;
    }
    void Check()
    {
        for (int i = 17; i < 19; i++)
        {
            if (Learner_Data.Learner_GetCard_Status(i) == 1)
            {
                check_n[i - 17] = 1;
                Item_btn[i - 17].image.color = new Color32(66, 66, 66, 255); //6-11
            }
            else
                Item_btn[i - 17].image.color = new Color(255, 255, 255, 255);  //0-5
        }
        for (int i = 10; i < 15; i++)
        {
            if (Learner_Data.Learner_GetCard_Status(i) == 1)
            {
                check_n[i - 8] = 1;
                Item_btn[i - 8].image.color = new Color32(66, 66, 66, 255);  //0-5
            }
            else
                Item_btn[i - 8].image.color = new Color32(255, 255, 255, 255);  //0-5
        }
        for (int i = 20; i < 22; i++)
        {
            if (Learner_Data.Learner_GetCard_Status(i) == 1)
            {
                check_n[i - 13] = 1;
                Item_btn[i - 13].image.color = new Color32(66, 66, 66, 255);  //0-5
            }
            else
                Item_btn[i - 13].image.color = new Color32(255, 255, 255, 255);  //0-5
        }
    }
    // Update is called once per frame
    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }

}
