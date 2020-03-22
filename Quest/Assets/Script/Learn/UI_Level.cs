﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Level : MonoBehaviour {

    #region Variable
    private Manager_log ml = new Manager_log();
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
    public GameObject ui_Title, ui_Level, ui_Overall, ui_Settlement,ui_reading,ui_paper;
    public Text QuestionNum_text,Description_text, Input_text;
    public Text QuestionTypeContent_text, LevelContent_text, AnswerContent_text, ScoreContent_text, FeedBack_text, Question_text, Next_text, ENDContent_text;
    public Text paper_text;
    public Text[] Ans_text = new Text[3];
    public Button Submit_btn, Next_btn,Read_btn,ReadCancel_btn;
    public Button[] Button_Ans = new Button[3];
    public Button Question_btn;
    public AudioSource[] Voice= new AudioSource[8]; //breakfast
    public AudioSource[] QuestionVoice = new AudioSource[6]; //breakfast
    public AudioSource ans,wro,end,ok,cancel; //breakfast

    #endregion

    #region Settlement
    public Image Item_img, Point_img, Mistake_img;
    public Text S_PageUp, S_PageDown, ItemContent_text, Point_Num, Mistake_Num, Flag;
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

        Read_btn.onClick.AddListener(Readapaper);
        ReadCancel_btn.onClick.AddListener(ReadCancel);

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
        if (Level < 5)
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
                ui_reading.SetActive(false);
                ui_Level.SetActive(true);
                break;
            case 2: //Level-3 中文
            case 3: //Level-4 中文
                Question_text.text = question_temp.GetQuestion();
                Question_btn.gameObject.SetActive(false);
                Question_Data.Button_Ans_Set(Level, Question_Num);
                for (int i = 0; i < 3; i++)
                    Ans_text[i].text = Question_Data.GetButton_Ans(i);
                ui_reading.SetActive(false);
                ui_Level.SetActive(true);
                break;
            case 4:
                /*
                Question_btn.gameObject.SetActive(false);
                Description_text.text = "請填寫正確的單字";
                Question_text.text = question_temp.GetQuestion();
                ui_Overall.SetActive(true);*/
                Question_btn.gameObject.SetActive(false);
                Question_text.text = "閱讀短文並根據題號回答該題號所指向的正確答案";
                paper_text.text = Question_Data.Getpaper();
                Question_Data.Button_Ans_Set(Level, Question_Num);
                for (int i = 0; i < 3; i++)
                    Ans_text[i].text = Question_Data.GetButton_Ans(i);
                ui_reading.SetActive(true);
                ui_Level.SetActive(true);
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
    void Readapaper()
    {
        ok.Play();
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Level[0], Behaviour_Bank.LearningBehaviour_Level[5], Behaviour_Bank.LearningBehaviour_Level[5]));
        ui_paper.SetActive(true);
    }
    void ReadCancel()
    {
        cancel.Play();
        ui_paper.SetActive(false);
    }
    #endregion

    void CheckAns(string s = "")
    {
        Question_Class question_temp = new Question_Class();
        Question_Data.ChangeAnswer_c(choose_Ans, Question_Num);
        Question_Data.ChangeAnswer_c_Content(choose_Ans_Content, Question_Num);

        question_temp = Question_Data.Question_Get(Question_Num);

        if (Level < 5)
            s = question_temp.GetAnswer_c_Content();


        if (question_temp.GetAnswer_r_Content() == s)
        {
            ans.Play();
            Question_Data.ChangeFeedBack("O", Question_Num);
            FeedBack_text.text = "O";
            Score += (100 / Question_total);
            StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Level[0], Behaviour_Bank.LearningBehaviour_Level[6], Behaviour_Bank.LearningBehaviour_Level[6] + (Question_Num + 1).ToString()));
        }
        else
        {
            wro.Play();
            Question_Data.ChangeFeedBack("X", Question_Num);
            FeedBack_text.text = "X";
            StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Level[0], Behaviour_Bank.LearningBehaviour_Level[7], Behaviour_Bank.LearningBehaviour_Level[7] + (Question_Num + 1).ToString()));
        }
        ScoreContent_text.text = Score.ToString();

        if (Level < 5)
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
            end.Play();
            ENDContent_text.text = "END";
            Next_text.text = "結算";
        }
    }

    public void Next()
    {
        Question_Class question_temp = new Question_Class();

        Next_btn.interactable = false;

        if (Level < 5)
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
            ui_reading.SetActive(false);
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
                    Task_Data.ChangeStatus("learn", Level, 2);
                    switch (System_Data.Version)
                    {
                        case 0:
                        case 2:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Score").ToString() + " -> ";
                            Point_Num.text = Learner_Data.Learner_GetPoints_Status(0).ToString() + " -> ";
                            Mistake_Num.text = Learner_Data.Learner_GetData("Mistakes_Num").ToString() + " ->";
                            Mechanism_Data.Reward("Task", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Score").ToString();
                            Point_Num.text += Learner_Data.Learner_GetPoints_Status(0).ToString();
                            Mistake_Num.text += Learner_Data.Learner_GetData("Mistakes_Num").ToString();
                            Point_img.gameObject.SetActive(true);
                            Mistake_img.gameObject.SetActive(true);
                            Point_Num.gameObject.SetActive(true);
                            Mistake_Num.gameObject.SetActive(true);
                            break;
                        default:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Score").ToString() + " -> ";
                            Mechanism_Data.Reward("Task", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Score").ToString();
                            Point_img.gameObject.SetActive(false);
                            Mistake_img.gameObject.SetActive(false);
                            Point_Num.gameObject.SetActive(false);
                            Mistake_Num.gameObject.SetActive(false);
                            break;
                    }
                    Item_img.sprite = Resources.Load("Image/Home/Item_Icon/Score", typeof(Sprite)) as Sprite;
                    task_temp.ChangeStatus(2);
                    Learner_Data.Learner_Add("Task_Success", Level, 1);
                    Learner_Data.Learner_Add("Task_Num", Level, 1);
                    Flag.text = "任務成功";
                    StartCoroutine(SavingLog("Learner_Score", Learner_Data.Learner_GetData("Score")));
                    StartCoroutine(SavingLog("Learner_Score_Accumulation", Learner_Data.Learner_GetData("Score_Accumulation")));
                    for (int i = 0; i < 3; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    for (int i = 9; i < 12; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_Task", Learner_Data.Learner_GetBadges_GetStatus(0)));
                    StartCoroutine(SavingLog("Learner_Task" + (Level + 1) + "_Success", Learner_Data.Learner_GetData("Task_Success", Level)));
                    StartCoroutine(SavingLog("Learner_Task" + (Level + 1) + "_Num", Learner_Data.Learner_GetData("Task_Num", Level)));
                    StartCoroutine(SavingBehaviours(Behaviour_Bank.GamingBehaviour, Behaviour_Bank.GamingBehaviour_Task[0], Behaviour_Bank.GamingBehaviour_Task[7], Behaviour_Bank.GamingBehaviour_Task[7] + (Level + 1).ToString()));
                }
                else if (Score < Task_Bank.Learn_Request_Score[Level]) //失敗
                {
                    Task_Data.ChangeStatus("learn", Level, 1);
                    switch (System_Data.Version)
                    {
                        case 0:
                        case 2:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Score").ToString() + " -> ";
                            Point_Num.text = Learner_Data.Learner_GetPoints_Status(0).ToString() + " -> ";
                            Mistake_Num.text = Learner_Data.Learner_GetData("Mistakes_Num").ToString() + " ->";
                            Mechanism_Data.Punishment("Task", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Score").ToString();
                            Point_Num.text += Learner_Data.Learner_GetPoints_Status(0).ToString();
                            Mistake_Num.text += Learner_Data.Learner_GetData("Mistakes_Num").ToString();
                            Point_img.gameObject.SetActive(true);
                            Mistake_img.gameObject.SetActive(true);
                            Point_Num.gameObject.SetActive(true);
                            Mistake_Num.gameObject.SetActive(true);
                            StartCoroutine(SavingLog("Learner_Points", Learner_Data.Learner_GetData("Points_Num")));
                            StartCoroutine(SavingLog("Learner_Mistakes", Learner_Data.Learner_GetData("Mistakes_Num")));
                            StartCoroutine(Saving("Learner_PointSave.php", "Pointstatus_Task", Learner_Data.Learner_GetPoints_Status(0)));
                            StartCoroutine(Saving("Learner_MistakeSave.php", "Mistake_Warning", Learner_Data.Learner_GetMistakes_Status(0)));
                            StartCoroutine(Saving("Learner_MistakeSave.php", "Mistake_YC", Learner_Data.Learner_GetMistakes_Status(1)));
                            StartCoroutine(Saving("Learner_MistakeSave.php", "Mistake_RC", Learner_Data.Learner_GetMistakes_Status(2)));
                            break;
                        default:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Score").ToString() + " -> ";
                            Mechanism_Data.Punishment("Task", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Score").ToString();
                            Point_img.gameObject.SetActive(false);
                            Mistake_img.gameObject.SetActive(false);
                            Point_Num.gameObject.SetActive(false);
                            Mistake_Num.gameObject.SetActive(false);
                            break;
                    }
                    StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Score", Learner_Data.Learner_GetData("Score")));
                    Item_img.sprite = Resources.Load("Image/Home/Item_Icon/Score", typeof(Sprite)) as Sprite;
                    task_temp.ChangeStatus(1);
                    Flag.text = "任務失敗";
                    Learner_Data.Learner_Add("Task_Fail", Level, 1);
                    Learner_Data.Learner_Add("Task_Num", Level,1);
                    for (int i = 0; i < 3; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    for (int i = 9; i < 12; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_Task", Learner_Data.Learner_GetBadges_GetStatus(0)));
                    StartCoroutine(SavingLog("Learner_Task" + (Level + 1) + "_Fail", Learner_Data.Learner_GetData("Task_Fail", Level)));
                    StartCoroutine(SavingLog("Learner_Task" + (Level + 1) + "_Num", Learner_Data.Learner_GetData("Task_Num", Level)));
                    StartCoroutine(SavingBehaviours(Behaviour_Bank.GamingBehaviour, Behaviour_Bank.GamingBehaviour_Task[0], Behaviour_Bank.GamingBehaviour_Task[8], Behaviour_Bank.GamingBehaviour_Task[8] + (Level + 1).ToString()));
                }

            }
            else if (Task == 0)
            {
                if (Score > 59)//成功
                {
                    switch (System_Data.Version)
                    {
                        case 0:
                        case 2:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Coin").ToString() + " -> ";
                            Point_Num.text = Learner_Data.Learner_GetPoints_Status(1).ToString() + " -> ";
                            Mistake_Num.text = Learner_Data.Learner_GetData("Mistakes_Num").ToString() + " ->";
                            Mechanism_Data.Reward("Learn", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Coin").ToString();
                            Point_Num.text += Learner_Data.Learner_GetPoints_Status(1).ToString();
                            Mistake_Num.text += Learner_Data.Learner_GetData("Mistakes_Num").ToString();
                            Point_img.gameObject.SetActive(true);
                            Mistake_img.gameObject.SetActive(true);
                            Point_Num.gameObject.SetActive(true);
                            Mistake_Num.gameObject.SetActive(true);
                            break;
                        default:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Coin").ToString() + " -> ";
                            Mechanism_Data.Reward("Learn", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Coin").ToString();
                            Point_img.gameObject.SetActive(false);
                            Mistake_img.gameObject.SetActive(false);
                            Point_Num.gameObject.SetActive(false);
                            Mistake_Num.gameObject.SetActive(false);
                            break;
                    }
                    StartCoroutine(SavingLog("Learner_Coin", Learner_Data.Learner_GetData("Coin")));
                    StartCoroutine(SavingLog("Learner_Coin_Accumulation", Learner_Data.Learner_GetData("Coin_Accumulation")));
                    Flag.text = "練習成功";
                    Learner_Data.Learner_Add("Learn_Num", Level, 1);
                    Learner_Data.Learner_Add("Learn_Success", Level, 1);
                    for (int i = 3; i < 6; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    for (int i = 12; i < 15; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_Learn", Learner_Data.Learner_GetBadges_GetStatus(1)));
                    StartCoroutine(SavingLog("Learner_Learn" + (Level + 1) + "_Num", Learner_Data.Learner_GetData("Learn_Num", Level)));
                    StartCoroutine(SavingLog("Learner_Learn" + (Level + 1) + "_Success", Learner_Data.Learner_GetData("Learn_Success", Level)));
                    StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Level[0], Behaviour_Bank.LearningBehaviour_Level[8], Behaviour_Bank.LearningBehaviour_Level[8] + (Level + 1).ToString()));
                }
                else if (Score < 60) //失敗
                {
                    switch (System_Data.Version)
                    {
                        case 0:
                        case 2:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Coin").ToString() + " -> ";
                            Point_Num.text = Learner_Data.Learner_GetPoints_Status(1).ToString() + " -> ";
                            Mistake_Num.text = Learner_Data.Learner_GetData("Mistakes_Num").ToString() + " ->";
                            Mechanism_Data.Punishment("Learn", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Coin").ToString();
                            Point_Num.text += Learner_Data.Learner_GetPoints_Status(1).ToString();
                            Mistake_Num.text += Learner_Data.Learner_GetData("Mistakes_Num").ToString();
                            Point_img.gameObject.SetActive(true);
                            Mistake_img.gameObject.SetActive(true);
                            Point_Num.gameObject.SetActive(true);
                            Mistake_Num.gameObject.SetActive(true);

                            StartCoroutine(SavingLog("Learner_Points", Learner_Data.Learner_GetData("Points_Num")));
                            StartCoroutine(SavingLog("Learner_Mistakes", Learner_Data.Learner_GetData("Mistakes_Num")));
                            StartCoroutine(Saving("Learner_PointSave.php", "Pointstatus_Learn", Learner_Data.Learner_GetPoints_Status(1)));
                            StartCoroutine(Saving("Learner_MistakeSave.php", "Mistake_Warning", Learner_Data.Learner_GetMistakes_Status(0)));
                            StartCoroutine(Saving("Learner_MistakeSave.php", "Mistake_YC", Learner_Data.Learner_GetMistakes_Status(1)));
                            StartCoroutine(Saving("Learner_MistakeSave.php", "Mistake_RC", Learner_Data.Learner_GetMistakes_Status(2)));
                            break;
                        default:
                            ItemContent_text.text = Learner_Data.Learner_GetData("Coin").ToString() + " -> ";
                            Mechanism_Data.Punishment("Learn", Level);
                            ItemContent_text.text += Learner_Data.Learner_GetData("Coin").ToString();
                            Point_img.gameObject.SetActive(false);
                            Mistake_img.gameObject.SetActive(false);
                            Point_Num.gameObject.SetActive(false);
                            Mistake_Num.gameObject.SetActive(false);
                            break;
                    }
                    StartCoroutine(ml.SetData("LearnerLog.php", "Learner_Coin", Learner_Data.Learner_GetData("Coin")));
                    Flag.text = "練習失敗";
                    Learner_Data.Learner_Add("Learn_Num", Level, 1);
                    Learner_Data.Learner_Add("Learn_Fail", Level, 1);
                    for (int i = 3; i < 6; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    for (int i = 12; i < 15; i++)
                        StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_" + i.ToString(), Learner_Data.Learner_GetBadges_Status(i)));
                    StartCoroutine(Saving("Learner_BadgesSave.php", "Badges_Learn", Learner_Data.Learner_GetBadges_GetStatus(1)));
                    StartCoroutine(SavingLog("Learner_Learn" + (Level + 1) + "_Num", Learner_Data.Learner_GetData("Learn_Num", Level)));
                    StartCoroutine(SavingLog("Learner_Learn" + (Level + 1) + "_Fail", Learner_Data.Learner_GetData("Learn_Fail", Level)));
                    StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Level[0], Behaviour_Bank.LearningBehaviour_Level[9], Behaviour_Bank.LearningBehaviour_Level[9] + (Level + 1).ToString()));

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
            if (Level < 5)
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
                    Question_text.text = question_temp.GetQuestion();
                    break;
                case 4: //Overall
                    Question_text.text = "閱讀短文並根據題號回答該題號所指向的正確答案";
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
        StartCoroutine(SavingBehaviours(Behaviour_Bank.LearningBehaviour, Behaviour_Bank.LearningBehaviour_Level[0], Behaviour_Bank.LearningBehaviour_Level[4], Behaviour_Bank.LearningBehaviour_Level[4]));
        if (Level == 0)
            Play();
        else if(Level == 4)
            Spell_Play();
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
    void Spell_Play()
    {
        Question_Class[] question_temp = new Question_Class[Question_total];
        for (int i = 0; i < Question_total; i++)
        {
            question_temp[i] = Question_Data.Question_Get(i);
        }
        question_temp[Question_Num].GetQuestion();

        switch (question_temp[Question_Num].GetAnswer_r_Content())
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
        ok.Play();
        SceneManager.LoadScene("Home");
    }
    IEnumerator Saving(string filename, string item, int n)
    {
        StartCoroutine(ml.SetData(filename, item, n));
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator SavingLog(string item,int n)
    {
        StartCoroutine(ml.SetData("LearnerLog.php", item, n));
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator SavingBehaviours(string Bclass, string B1, string B2, string B3)
    {
        StartCoroutine(ml.SetBehaviour("LearnerLog_Behaviour.php", Bclass, B1, B2, B3));
        yield return new WaitForSeconds(0.1f);
    }
}
