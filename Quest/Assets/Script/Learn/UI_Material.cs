using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Material : MonoBehaviour {

    #region Variable 
    private Manager_log ml = new Manager_log();
    private int No = 0; //0 1 2 3 4 5 6 7 8 9 10...
    #endregion

    #region Material
    public GameObject Vocabulary_obj,Phonics_obj,Setence_obj,Daily_obj;
    public Button Back_btn,Voice_btn;
    public Button[] Voiceanother_btn = new Button[8];
    public Image Vocabulary_img;
    public Button[] Vocabular_Btn = new Button[11];
    public Text[] VocabularBtn_text = new Text[11];
    public Text Num_text, E_Name_text, C_Name_text, PartOfSpeech_text, Sentence_text, Info_text;
    public Button[] Direction = new Button[2]; //left right
    public AudioSource[] voice = new AudioSource[Vocabulary_Bank.Vocabulary_Num+8];
    public AudioSource Ok, PageTurning;
    #endregion


    // Use this for initialization
    void Start () {
        Info_text.text = "點擊上方按鈕或旁邊箭頭可切換單字及查看應用例句\n點擊喇叭圖示可聽該單字發音";

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
        Vocabular_Btn[10].onClick.AddListener(Button_11);

        Voiceanother_btn[0].onClick.AddListener(Voiceanother_btn1);
        Voiceanother_btn[1].onClick.AddListener(Voiceanother_btn2);
        Voiceanother_btn[2].onClick.AddListener(Voiceanother_btn3);
        Voiceanother_btn[3].onClick.AddListener(Voiceanother_btn4);
        Voiceanother_btn[4].onClick.AddListener(Voiceanother_btn5);
        Voiceanother_btn[5].onClick.AddListener(Voiceanother_btn6);
        Voiceanother_btn[6].onClick.AddListener(Voiceanother_btn7);
        Voiceanother_btn[7].onClick.AddListener(Voiceanother_btn8);

        for (int i = 0; i < 8; i++)
        {
            Vocabulary_Class vocabulary_temp = new Vocabulary_Class();
            vocabulary_temp = Vocabulary_Data.Vocabulary_Get(i);
            VocabularBtn_text[i].text = vocabulary_temp.GetE_Name();
        }
        VocabularBtn_text[8].text = "字母拼讀";
        VocabularBtn_text[9].text = "句型";
        VocabularBtn_text[10].text = "日常用語";
        ShowContent(No);
    }

    #region Material PointerClick
    void Right()
    {
        PageTurning.Play();
        if (No > 9)
        {
            No = 0;
        }
        else
        {
            No++;
        }
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[1], Behaviour_Bank.LearningBehaviour_Material[1]+"1"));
        ShowContent(No);
    }
    void Left()
    {
        PageTurning.Play();
        if (No < 1)
        {
            No = 10;
        }
        else
        {
            No--;
        }
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[1], Behaviour_Bank.LearningBehaviour_Material[1] + "2"));
        ShowContent(No);
    }
    void Play()
    {
        if(No<8)
            voice[No].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (No+1).ToString()));
    }
    #endregion

    #region Btn
    void Button_1()
    {
        No = 0;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "1"));
        ShowContent(No);
    }
    void Button_2()
    {
        No = 1;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "2"));
        ShowContent(No);
    }
    void Button_3()
    {
        No = 2;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "3"));
        ShowContent(No);
    }
    void Button_4()
    {
        No = 3;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "4"));
        ShowContent(No);
    }
    void Button_5()
    {
        No = 4;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "5"));
        ShowContent(No);
    }
    void Button_6()
    {
        No = 5;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "6"));
        ShowContent(No);
    }
    void Button_7()
    {
        No = 6;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "7"));
        ShowContent(No);
    }
    void Button_8()
    {
        No = 7;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "8"));

        ShowContent(No);
    }
    void Button_9()
    {
        No = 8;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "9"));

        ShowContent(No);
    }
    void Button_10()
    {
        No = 9;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "10"));

        ShowContent(No);
    }
    void Button_11()
    {
        No = 10;
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[3], Behaviour_Bank.LearningBehaviour_Material[3] + "11"));
        ShowContent(No);
    }
    void Voiceanother_btn1()
    {
        voice[8].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (9).ToString()));
    }
    void Voiceanother_btn2()
    {
        voice[9].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (10).ToString()));
    }
    void Voiceanother_btn3()
    {
        voice[10].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (11).ToString()));
    }
    void Voiceanother_btn4()
    {
        voice[11].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (12).ToString()));
    }
    void Voiceanother_btn5()
    {
        voice[12].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (13).ToString()));
    }
    void Voiceanother_btn6()
    {
        voice[13].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (14).ToString()));
    }
    void Voiceanother_btn7()
    {
        voice[14].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (15).ToString()));
    }
    void Voiceanother_btn8()
    {
        voice[15].Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Material[0], Behaviour_Bank.LearningBehaviour_Material[2], Behaviour_Bank.LearningBehaviour_Material[2] + (16).ToString()));
    }
    #endregion

    void ShowContent(int n)
    {
        if (n < 8)
        {
            Vocabulary_obj.SetActive(true);
            Phonics_obj.SetActive(false);
            Setence_obj.SetActive(false);
            Daily_obj.SetActive(false);
            Vocabulary_Class vocabulary_temp = new Vocabulary_Class();
            vocabulary_temp = Vocabulary_Data.Vocabulary_Get(n);
            Vocabulary_img.sprite = Resources.Load("Image/Vocabulary_Img/"+ vocabulary_temp.GetE_Name(), typeof(Sprite)) as Sprite;
            Num_text.text = (n + 1).ToString() + ".";
            E_Name_text.text = vocabulary_temp.GetE_Name();
            C_Name_text.text = vocabulary_temp.GetC_Name();
            PartOfSpeech_text.text = vocabulary_temp.GetPartOfSpeech();
            Sentence_text.text = vocabulary_temp.GetSentence();
        }
        else if (n == 8)
        {
            Vocabulary_obj.SetActive(false);
            Phonics_obj.SetActive(true);
            Setence_obj.SetActive(false);
            Daily_obj.SetActive(false);
        }
        else if (n == 9)
        {
            Vocabulary_obj.SetActive(false);
            Phonics_obj.SetActive(false);
            Setence_obj.SetActive(true);
            Daily_obj.SetActive(false);
        }
        else if (n == 10)
        {
            Vocabulary_obj.SetActive(false);
            Phonics_obj.SetActive(false);
            Setence_obj.SetActive(false);
            Daily_obj.SetActive(true);
        }
    }
    void Back()
    {
        Ok.Play();
        SceneManager.LoadScene("Home");
    }
    IEnumerator SavingBehaviours(string Bclass, string B1, string B2, string B3)
    {
        StartCoroutine(ml.SetBehaviour("LearnerLog_Behaviour.php", Bclass, B1, B2, B3));
        yield return new WaitForSeconds(0.1f);
    }
}
