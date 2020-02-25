using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Material : MonoBehaviour {

    #region Variable 
    private int No = 0; //0 1 2 3 4 5 6 7 8 9 10...
    #endregion

    #region Material
    public Button Back_btn,Voice_btn;
    public Button[] Vocabular_Btn = new Button[10];
    public Text[] VocabularBtn_text = new Text[10];
    public Text Num_text, E_Name_text, C_Name_text, PartOfSpeech_text, Sentence_text, Info_text;
    public Button[] Direction = new Button[2]; //left right
    public AudioSource[] voice = new AudioSource[Vocabulary_Bank.Vocabulary_Num];
    public AudioSource Ok, PageTurning;
    #endregion


    // Use this for initialization
    void Start () {
        Info_text.text = "點擊上方按鈕或旁邊箭頭可切換單字\n點擊喇叭圖示可聽該單字發音";

        Back_btn.onClick.AddListener(Back);
        Voice_btn.onClick.AddListener(Play);

        Direction[0].onClick.AddListener(Left);
        Direction[1].onClick.AddListener(Right);

        Vocabular_Btn[0].onClick.AddListener(Button_1);
        Vocabular_Btn[1].onClick.AddListener(Button_2);
        Vocabular_Btn[2].onClick.AddListener(Button_3);
        Vocabular_Btn[3].onClick.AddListener(Button_4);
        Vocabular_Btn[4].onClick.AddListener(Button_5);
        Vocabular_Btn[5].onClick.AddListener(Button_6);
        Vocabular_Btn[6].onClick.AddListener(Button_7);
        Vocabular_Btn[7].onClick.AddListener(Button_8);
        Vocabular_Btn[8].onClick.AddListener(Button_9);
        Vocabular_Btn[9].onClick.AddListener(Button_10);

        ShowContent(No);
    }

    #region Material PointerClick
    void Right()
    {
        PageTurning.Play();
        if (No > 8)
        {
            No = 0;

        }
        else
        {
            No++;
            if (No == 10)
            {
                No = 0;
            }
        }
        ShowContent(No);
    }
    void Left()
    {
        PageTurning.Play();
        if (No < 1)
        {
            No = 9;
        }
        else
        {
            No--;
            if (No == -1)
            {
                No = 9;
            }
        }
        ShowContent(No);
    }
    void Play()
    {
        voice[No].Play();
    }
    #endregion

    #region Btn
    void Button_1()
    {
        No = 0;
        ShowContent(No);
    }
    void Button_2()
    {
        No = 1;
        ShowContent(No);
    }
    void Button_3()
    {
        No = 2;
        ShowContent(No);
    }
    void Button_4()
    {
        No = 3;
        ShowContent(No);
    }
    void Button_5()
    {
        No = 4;
        ShowContent(No);
    }
    void Button_6()
    {
        No = 5;
        ShowContent(No);
    }
    void Button_7()
    {
        No = 6;
        ShowContent(No);
    }
    void Button_8()
    {
        No = 7;
        ShowContent(No);
    }
    void Button_9()
    {
        No = 8;
        ShowContent(No);
    }
    void Button_10()
    {
        No = 9;
        ShowContent(No);
    }
    #endregion

    void ShowContent(int n)
    {
        Vocabulary_Class vocabulary_temp = new Vocabulary_Class();
        vocabulary_temp = Vocabulary_Data.Vocabulary_Get(n);

        Num_text.text = (n + 1).ToString() + ".";
        E_Name_text.text = vocabulary_temp.GetE_Name();
        C_Name_text.text = vocabulary_temp.GetC_Name();
        PartOfSpeech_text.text = vocabulary_temp.GetPartOfSpeech();
        Sentence_text.text = vocabulary_temp.GetSentence();
    }
    void Back()
    {
        Ok.Play();
        SceneManager.LoadScene("Home");
    }
}
