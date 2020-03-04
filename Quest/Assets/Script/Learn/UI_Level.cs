using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Level : MonoBehaviour {

    #region Variable
    private int Level = 10;
    private int Task = 10; 
    private int Score = 0;
    private int Question_Num = 0;
    private int Question_total = 10;

    private string choose_Ans = "";
    private string choose_Ans_Content = "";

    private int PageUP = 1;
    private int PageDown = 2;
    private int Page = 0; //0 5
    #endregion

    #region Level
    public GameObject ui_Title, ui_Level, ui_Overall, ui_Settlement;
    public Text QuestionNum_text,Description_text, Input_text;
    public Text QuestionTypeContent_text, LevelContent_text, AnswerContent_text, ScoreContent_text, FeedBack_text, Question_text, Next_text, ENDContent_text;
    public Text[] Ans_text = new Text[3];
    public Button Submit_btn, Next_btn;
    public Button[] Button_Ans = new Button[3];
    public Button Question_btn;
    public AudioSource[] Voice= new AudioSource[8]; //breakfast
    public AudioSource[] QuestionVoice = new AudioSource[6]; //breakfast
    #endregion

    #region Settlement
    public Image Item_img;
    public Text S_PageUp, S_PageDown, ItemContent_text, Flag;
    public Text[] A_S_QNum = new Text[5];
    public Text[] A_S_Question = new Text[5];
    public Text[] A_S_Answer = new Text[5];
    public Text[] A_S_Choose = new Text[5];
    public Text[] A_S_Feedback = new Text[5];
    public Button Back_btn, Right_btn, Left_btn;
    #endregion

    // Use this for initialization
    void Start () {
        Question_btn.onClick.AddListener(VoicePlay);
        Right_btn.onClick.AddListener(F_Right);
        Left_btn.onClick.AddListener(F_Left);
        Back_btn.onClick.AddListener(Back);
        Next_btn.onClick.AddListener(Next);
        Next_btn.interactable = false;

        ui_Title.SetActive(true);
        ENDContent_text.text = "";
        FeedBack_text.text = "";
        AnswerContent_text.text = "";

        Level_Class level_temp = new Level_Class();
        Question_Class question_temp = new Question_Class();
        question_temp = Question_Data.Question_Get(0);
        Level = Question_Data.GetLevel();
        Task = Question_Data.GetTask();
        level_temp = Level_Data.Level_Get(Level);
        Question_total = Question_Data.GetQtotal();
        QuestionTypeContent_text.text = level_temp.GetQuestionType();
        LevelContent_text.text = level_temp.GetTitle();
        if (Level < 4)
        {
            Button_Ans[0].onClick.AddListener(Choose_A);
            Button_Ans[1].onClick.AddListener(Choose_B);
            Button_Ans[2].onClick.AddListener(Choose_C);
        }
        else
        {
            Submit_btn.onClick.AddListener(Submit);
        }
        switch (Level)
        {
            case 0: //Level-1 聽力
            case 1: //Level-2 聽力
                Question_text.text = "請點選左邊的圖示，並選出聽到的答案";
                Question_btn.gameObject.SetActive(true);
                Question_Data.Button_Ans_Set(Level, Question_Num);
                for (int i = 0; i < 3; i++)
                    Ans_text[i].text = Question_Data.GetButton_Ans(i);
                ui_Level.SetActive(true);
                break;
            case 2: //Level-3 中文
            case 3: //Level-4 中文
                Question_text.text = question_temp.GetQuestion();
                Question_btn.gameObject.SetActive(false);
                Question_Data.Button_Ans_Set(Level, Question_Num);
                for (int i = 0; i < 3; i++)
                    Ans_text[i].text = Question_Data.GetButton_Ans(i);
                ui_Level.SetActive(true);
                break;
            case 4:
                Description_text.text = "請聽音並拼出正確的單字";
                Question_text.text = question_temp.GetQuestion();
                Question_btn.gameObject.SetActive(true);
                ui_Overall.SetActive(true);
                break;
            default:
                break;
        }
        QuestionNum_text.text = "1.";
    }
    #region Button_Ans
    void Choose_A()
    {
        choose_Ans = "A";
        choose_Ans_Content = Question_Data.GetButton_Ans(0);
        CheckAns();
    }
    void Choose_B()
    {
        choose_Ans = "B";
        choose_Ans_Content = Question_Data.GetButton_Ans(1);
        CheckAns();
    }
    public void Choose_C()
    {
        choose_Ans = "C";
        choose_Ans_Content = Question_Data.GetButton_Ans(2);
        CheckAns();
    }
    #endregion

    void CheckAns(string s = "")
    {
        Question_Class question_temp = new Question_Class();
        Question_Data.ChangeAnswer_c(choose_Ans, Question_Num);
        Question_Data.ChangeAnswer_c_Content(choose_Ans_Content, Question_Num);

        question_temp = Question_Data.Question_Get(Question_Num);

        if (Level < 4)
            s = question_temp.GetAnswer_c_Content();


        if (question_temp.GetAnswer_r_Content() == s)
        {
            Question_Data.ChangeFeedBack("O", Question_Num);
            FeedBack_text.text = "O";
            Score += (100 / Question_total);
        }
        else
        {
            Question_Data.ChangeFeedBack("X", Question_Num);
            FeedBack_text.text = "X";
        }
        ScoreContent_text.text = Score.ToString();

        if (Level < 4)
        {
            AnswerContent_text.text = question_temp.GetAnswer_r();
            Button_Ans[0].interactable = false;
            Button_Ans[1].interactable = false;
            Button_Ans[2].interactable = false;
        }
        else
        {
            AnswerContent_text.text = question_temp.GetAnswer_r_Content();
            Submit_btn.interactable = false;
        }

        Next_btn.interactable = true;


        if (Question_Num == Question_total - 1)
        {
            ENDContent_text.text = "END";
            Next_text.text = "結算";
        }
    }

    public void Next()
    {
        Question_Class question_temp = new Question_Class();

        Next_btn.interactable = false;

        if (Level < 4)
        {
            Button_Ans[0].interactable = true;
            Button_Ans[1].interactable = true;
            Button_Ans[2].interactable = true;
        }
        else
            Submit_btn.interactable = true;

        if (Question_Num == Question_total - 1)
        {
            ui_Title.SetActive(false);
            ui_Level.SetActive(false);
            ui_Overall.SetActive(false);
            ui_Settlement.SetActive(true);

            if (Score > Level_Data.GetHighestScore(Level))
                Level_Data.ChangeHighestScore(Score.ToString(), Level);

            if (Task == 1)
            {
                Task_Class task_temp = new Task_Class();
                task_temp = Task_Data.Learn_Get(Level);
                if (Score >= Task_Bank.Learn_Request_Score[Level])//成功
                {
                    Item_img.sprite = Resources.Load("Image/Home/Item_Icon/Score", typeof(Sprite)) as Sprite;
                    task_temp.ChangeStatus(2);
                    ItemContent_text.text = Learner_Data.Learner_GetData("Score").ToString() + " -> ";
                    Flag.text = "任務成功";
                    Mechanism_Data.Reward("Task", Level);
                    ItemContent_text.text += Learner_Data.Learner_GetData("Score").ToString();
                    Learner_Data.Learner_Add("Task_Succes", Level, 1);
                    Learner_Data.Learner_Add("Task_Num", Level, 1);
                }
                else if (Score < Task_Bank.Learn_Request_Score[Level]) //失敗
                {
                    Item_img.sprite = Resources.Load("Image/Home/Item_Icon/Score", typeof(Sprite)) as Sprite;
                    task_temp.ChangeStatus(2);
                    ItemContent_text.text = Learner_Data.Learner_GetData("Score").ToString() + " -> ";
                    Flag.text = "任務失敗";
                    Mechanism_Data.Punishment("Task", Level);
                    ItemContent_text.text += Learner_Data.Learner_GetData("Score").ToString();
                    Learner_Data.Learner_Add("Task_Fail", Level, 1);
                    Learner_Data.Learner_Add("Task_Num", Level,1);
                }

            }
            else if (Task == 0)
            {
                if (Score > 59)//成功
                {
                    ItemContent_text.text = Learner_Data.Learner_GetData("Coin").ToString() + " -> ";
                    Flag.text = "練習成功";
                    Mechanism_Data.Reward("Learn", Level);
                    ItemContent_text.text += Learner_Data.Learner_GetData("Coin").ToString();

                    Learner_Data.Learner_Add("Learn_Num", Level, 1);
                    Learner_Data.Learner_Add("Learn_Succes", Level, 1);
                }
                else if (Score < 60) //失敗
                {
                    ItemContent_text.text = Learner_Data.Learner_GetData("Coin").ToString() + " -> ";
                    Flag.text = "練習失敗";
                    Mechanism_Data.Punishment("Learn", Level);
                    ItemContent_text.text += Learner_Data.Learner_GetData("Coin").ToString();
                    Learner_Data.Learner_Add("Learn_Fail", 1);
                }
            }
            //開始結算
            //頁面初始化
            if (Question_Num < 6)
                PageDown = 1;
            else if (Question_Num < 11)
                PageDown = 2;
            else if (Question_Num < 16)
                PageDown = 3;
            else
                PageDown = 4;
            Page = 0;
            PageUP = 1;
            S_PageUp.text = PageUP.ToString();
            S_PageDown.text = PageDown.ToString();
            for (int i = 0; i < 5; i++)
            {
                A_S_QNum[i].text = "";
                A_S_Question[i].text = "";
                A_S_Answer[i].text = "";
                A_S_Choose[i].text = "";
                A_S_Feedback[i].text = "";
            }
            ShowContent();
        }
        else //繼續作答
        {
            Question_Num++;
            question_temp = Question_Data.Question_Get(Question_Num);
            if (Level < 4)
            {
                Question_Data.Button_Ans_Set(Level, Question_Num);
                for (int i = 0; i < 3; i++)
                    Ans_text[i].text = Question_Data.GetButton_Ans(i);
            }
            QuestionNum_text.text = (Question_Num + 1).ToString() + ".";
            AnswerContent_text.text = "";
            FeedBack_text.text = "";

            switch (Level)
            {
                case 0: //Level-1 聽力
                case 1: //Level-2 聽力
                    break;
                case 2: //Level-4 中文
                case 3: //Level-5 中文
                case 4: //Overall
                    Question_text.text = question_temp.GetQuestion();
                    break;
                default:
                    break;
            }
        }
    }
    void Submit()
    {
        string s;
        s = Input_text.text;
        CheckAns(s);
    }

    #region Settlement
    void F_Left()
    {
        if (PageUP > 1)
        {
            PageUP--;
            PageChage();
        }
    }
    void F_Right()
    {
        if (PageUP < PageDown)
        {
            PageUP++;
            PageChage();
        }

    }
    void PageChage()
    {
        S_PageUp.text = PageUP.ToString();
        S_PageDown.text = PageDown.ToString();

        switch (PageUP)
        {
            case 1:
                Page = 0;
                break;
            case 2:
                Page = 5;
                break;
            default:
                break;
        }
        ShowContent();
    }
    void ShowContent()
    {
        Question_Class[] question_temp = new Question_Class[10];
        int n = Page;
        for (int i = 0; i < 10; i++)
            question_temp[i] = new Question_Class(0, "", "", "", "", "", "");

        for (int i = 0; i < Question_total; i++)
            question_temp[i] = Question_Data.Question_Get(i);

        for (int i = 0; i < 5; i++)
        {
            A_S_QNum[i].text = question_temp[i + n].GetQuestionNum().ToString();
            A_S_Question[i].text = question_temp[i + n].GetQuestion();
            A_S_Answer[i].text = question_temp[i + n].GetAnswer_r() + " " + question_temp[i + n].GetAnswer_r_Content();
            A_S_Choose[i].text = question_temp[i + n].GetAnswer_c() + " " + question_temp[i + n].GetAnswer_c_Content();
            A_S_Feedback[i].text = question_temp[i + n].GetFeedBack();
        }
    }
    #endregion

    void VoicePlay()
    {
        if (Level == 0)
            Play();
        else if (Level == 1)
            Q_Play();
    }
    void Play()
    {
        Question_Class[] question_temp = new Question_Class[Question_total];
        for (int i = 0; i < Question_total; i++)
        {
            question_temp[i] = Question_Data.Question_Get(i);
        }
        question_temp[Question_Num].GetQuestion();

        switch (question_temp[Question_Num].GetQuestion())
        {
            case "breakfast":
                Voice[0].Play();
                break;
            case "lunch":
                Voice[1].Play();
                break;
            case "dinner":
                Voice[2].Play();
                break;
            case "a hamburger":
                Voice[3].Play();
                break;
            case "noodles":
                Voice[4].Play();
                break;
            case "rice":
                Voice[5].Play();
                break;
            case "salad":
                Voice[6].Play();
                break;
            case "soup":
                Voice[7].Play();
                break;
            default:
                break;
        }
    }
    void Q_Play()
    {
        Question_Class[] question_temp = new Question_Class[Question_total];
        for (int i = 0; i < Question_total; i++)
        {
            question_temp[i] = Question_Data.Question_Get(i);
        }
        question_temp[Question_Num].GetQuestion();

        switch (question_temp[Question_Num].GetQuestion())
        {
            case "I eat some noodles.":
                QuestionVoice[0].Play();
                break;
            case "She wants some noodles.":
                QuestionVoice[1].Play();
                break;
            case "The girl wants a hamburger and some pizza for lunch.":
                QuestionVoice[2].Play();
                break;
            case "Tom wants some rice for dinner.":
                QuestionVoice[3].Play();
                break;
            case "What do you want for breakfast?":
                QuestionVoice[4].Play();
                break;
            case "What does he want for breakfast?":
                QuestionVoice[5].Play();
                break;
            default:
                break;
        }
    }
    void Back()
    {
        SceneManager.LoadScene("Home");
    }
}
