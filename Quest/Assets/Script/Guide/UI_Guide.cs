using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Guide : MonoBehaviour {

    private int Page = 1; //1 2 3
    private Manager_log ml = new Manager_log();
    public GameObject Image_obj,R_obj,W_obj;
    public Text Info_text, Info2_text, Info3_text, PageUp_text, PageDown_text;
    public Button[] G_btn = new Button[5];
    public Button Back_btn,Left_btn,Right_btn;
    public AudioSource ok, PageTurnning;

    // Use this for initialization
    void Start () {
        Image_obj.SetActive(false);
        G_btn[0].onClick.AddListener(B_Task);
        G_btn[1].onClick.AddListener(B_Learn);
        G_btn[2].onClick.AddListener(B_Battle);
        G_btn[3].onClick.AddListener(B_Item);
        G_btn[4].onClick.AddListener(B_Image);
        Back_btn.onClick.AddListener(Back);
        Left_btn.onClick.AddListener(Left);
        Right_btn.onClick.AddListener(Right);

        Item();

    }
    void B_Item()
    {
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[1], Behaviour_Bank.SupportingBehaviour_Guide[1] + "1"));
        Item();
    }
    void B_Task()
    {
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[1], Behaviour_Bank.SupportingBehaviour_Guide[1] + "2"));
        Task();
    }
    void B_Learn()
    {
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[1], Behaviour_Bank.SupportingBehaviour_Guide[1] + "3"));
        Learn();
    }
    void B_Battle()
    {
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[1], Behaviour_Bank.SupportingBehaviour_Guide[1] + "4"));
        Battle();
    }
    void B_Image()
    {
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[1], Behaviour_Bank.SupportingBehaviour_Guide[1] + "5"));
        Image();
    }
    void Item()
    {
        Image_obj.SetActive(false);
        PageTurnning.Play();
        switch (System_Data.Version)
        {
            case 0:
                Info_text.text = "1.遊戲中的道具共七個，分別為分數、金幣、水晶、卡牌、獎章、點數及失誤。\n\n"
    + "2.可至\"狀態\"查看自己持有的道具狀態。\n\n"
    + "3.分數可至任務中記載的獎勵獲得，若未記載則代表不會獲得，會因為任務失敗而減少。";
                break;
            case 1:
                Info_text.text = "1.遊戲中的道具共五個，分別為分數、金幣、水晶、卡牌及獎章。\n\n"
    + "2.可至\"狀態\"查看自己持有的道具狀態。\n\n"
    + "3.分數可至任務中記載的獎勵獲得，若未記載則代表不會獲得，會因為任務失敗而減少。";
                break;
            case 2:
                Info_text.text = "1.遊戲中的道具共五個，分別為分數、金幣、水晶、點數及失誤。\n\n"
+ "2.可至\"狀態\"查看自己持有的道具狀態。\n\n"
+ "3.分數可至任務中記載的獎勵獲得，若未記載則代表不會獲得，會因為任務失敗而減少。";
                break;
            case 3:
                Info_text.text = "1.遊戲中的道具共三個，分別為分數、金幣、水晶。\n\n"
+ "2.可至\"狀態\"查看自己持有的道具狀態。\n\n"
+ "3.分數可至任務中記載的獎勵獲得，若未記載則代表不會獲得，會因為任務失敗而減少。";
                break;
            default:
                break;
        }
        Info2_text.text = "4.金幣可至學習中記載的獎勵獲得，若未記載則代表不會獲得，會因為學習失敗而減少。";
        Info3_text.text = "\n5.水晶可至戰鬥中記載的獎勵獲得，若未記載則代表不會獲得，會因為戰鬥失敗而減少。";
        PageUp_text.text = "1";
        PageDown_text.text = "2";
        Page = 1;
    }
    void Item2()
    {
        Image_obj.SetActive(false);
        PageTurnning.Play();
        switch (System_Data.Version)
        {
            case 0:
                Info_text.text = "1.卡牌共22張，可至商店獲得，分成三類，分別是\"前衛、中鋒及支援\"，前衛卡為攻擊力高但沒有效果的卡；中鋒卡為攻擊力低，但有能與前鋒卡的攻擊力做相加的效果；支援卡為沒有攻擊力，但有能恢復玩家在戰鬥中的生命值的效果。\n\n"
                    + "2.獎章共18枚，分成三類，分別是任務獎章6枚、學習獎章6枚及戰鬥獎章6枚，這三類獎章獲得的方式為完成該獎章所要求之事項。\n";
                Info2_text.text = "1.點數分三類，分為任務、學習及戰鬥，每當有任務、學習或失敗發生時，則會扣除任務、學習或戰鬥點數，當點數扣至0，則會使分數、學習或水晶減半(先懲罰再減半)。\n\n";
                Info3_text.text = "2.失誤分三類，分為警告、黃牌及紅牌，每當有失敗發生時，就會增加一支警告，每三支警告換成一張黃牌，每三張黃牌換成一張紅牌，每拿到一張紅牌時，失敗的懲罰會加倍。";
                break;
            case 1:
                Info_text.text = "1.卡牌共22張，可至商店獲得，分成三類，分別是\"前衛、中鋒及支援\"，前衛卡為攻擊力高但沒有效果的卡；中鋒卡為攻擊力低，但有能與前鋒卡的攻擊力做相加的效果；支援卡為沒有攻擊力，但有能恢復玩家在戰鬥中的生命值的效果。\n\n"
                    + "2.獎章共18枚，分成三類，分別是任務獎章6枚、學習獎章6枚及戰鬥獎章6枚，這三類獎章獲得的方式為完成該獎章所要求之事項。\n";
                Info2_text.text = "";
                Info3_text.text = "";
                break;
            case 2:
                Info_text.text = "1.卡牌分成三類，分別是\"前衛、中鋒及支援\"，前衛卡為攻擊力高但沒有效果的卡；中鋒卡為攻擊力低，但有能與前鋒卡的攻擊力做相加的效果；支援卡為沒有攻擊力，但有能恢復玩家在戰鬥中的生命值的效果。\n\n";
                Info2_text.text = "1.點數分三類，分為任務、學習及戰鬥，每當有任務、學習或失敗發生時，則會扣除任務、學習或戰鬥點數，當點數扣至0，則會使分數、學習或水晶減半(先懲罰再減半)。\n\n";
                Info3_text.text = "2.失誤分三類，分為警告、黃牌及紅牌，每當有失敗發生時，就會增加一支警告，每三支警告換成一張黃牌，每三張黃牌換成一張紅牌，每拿到一張紅牌時，失敗的懲罰會加倍。";

                break;
            case 3:
                Info_text.text = "1.卡牌分成三類，分別是\"前衛、中鋒及支援\"，前衛卡為攻擊力高但沒有效果的卡；中鋒卡為攻擊力低，但有能與前鋒卡的攻擊力做相加的效果；支援卡為沒有攻擊力，但有能恢復玩家在戰鬥中的生命值的效果。\n\n";
                Info2_text.text = "";
                Info3_text.text = "";
                break;
            default:
                break;
        }
       
        PageUp_text.text = "3";
        PageDown_text.text = "4";
        Page = 3;
    }
    void Task()
    {
        Image_obj.SetActive(false);
        PageTurnning.Play();
        Info_text.text = "1.任務一共有\"七項\"，分別為五項學習任務及兩項戰鬥任務，每項任務僅能進行一次。\n\n"
            + "2.英語學習的任務內容為在任務指定的某學習關卡中需取得任務要求的分數才算成功，否則算失敗，題型與對應學習關卡的設定相同。\n\n"
            + "3.卡牌戰鬥的任務內容為在任務指定的某卡牌戰鬥關卡中取得勝利，否則算失敗，敵人設定及題型與對應的卡牌戰鬥相同。\n";
        Info2_text.text = "4.當某一項英語學習任務或卡牌戰鬥任務成功時，則會根據任務記載的獎勵給予玩家。\n\n"
            + "5.當某一項英語學習任務或卡牌戰鬥任務失敗時，則會根據任務記載的懲罰給予玩家。";
        Info3_text.text = "";
        PageUp_text.text = "5";
        PageDown_text.text = "6";
        Page = 5;
    }
    void Learn()
    {
        Image_obj.SetActive(false);
        PageTurnning.Play();
        Info_text.text = "1.分為\"教材和關卡\"。教材為遊戲中的學習內容，包含單字、字母拼讀、句型及日常用語，可透過上方的按鈕及下方的箭頭圖示來切換。\n\n"
            + "2.關卡為測驗，共五關，需在關卡中取得60以上的分數才算成功，否則算失敗。\n";

        Info2_text.text = "3.當關卡成功時，則會根據該關卡記載的獎勵給予玩家。\n\n"
            + "4.當關卡失敗時，則會根據該關卡記載的懲罰給予玩家。";
        Info3_text.text = "";
        PageUp_text.text = "7";
        PageDown_text.text = "8";
        Page = 7;
    }
    void Battle()
    {
        Image_obj.SetActive(false);
        PageTurnning.Play();
        Info_text.text = "1.卡牌戰鬥為以持有的卡牌數量(可至\"牌組\"查看擁有的卡牌)與電腦進行對戰，玩家一開始擁有20點生命值及五張手牌。\n\n"
            + "2.生命值為卡牌戰鬥中，雙方需保護的項目，當某方生命值被扣除至零點以下時，則判定該方輸。\n\n"
            + "3.手牌則是從玩家的持有卡牌中隨機選擇五張牌到手上。";
        Info2_text.text = "4.戰鬥區共有兩關可以選擇\n\n"
            + "5.每回合的戰鬥分為答題階段、出牌階段及戰鬥階段。\n"
            + "6.答題階段，玩家須回答問題，若是答錯則扣除 \"三\" 點生命值。";
        Info3_text.text = "7.出牌階段，玩家必須出一張以上的牌，每種類最多一張，最多出三張。\n\n"
            + "8.戰鬥階段，與電腦比較攻擊力來分出勝負，之後便進入下一回合。所有回合結束後比較雙方生命值，玩家的生命值 >= 電腦的生命值即獲勝。";
        PageUp_text.text = "9";
        PageDown_text.text = "10";
        Page = 9;
    }
    void Image()
    {
        Image_obj.SetActive(true);
        switch (System_Data.Version)
        {
            case 0:
                break;
            case 1:
                W_obj.SetActive(false);
                break;
            case 2:
                R_obj.SetActive(false);
                break;
            case 3:
                R_obj.SetActive(false);
                W_obj.SetActive(false);
                break;
        }
        PageTurnning.Play();
        Info_text.text = "";
        Info2_text.text = "";
        Info3_text.text = "";
        PageUp_text.text = "11";
        PageDown_text.text = "12";
        Page = 11;
    }
    #region Item Function
    void Right()
    {
        Page+=2;
        if (Page == 13)
            Page = 1;
        ShowContent(Page);
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[2], Behaviour_Bank.SupportingBehaviour_Guide[2] + "1"));
    }
    void Left()
    {
        Page-=2;
        if (Page == -1)
            Page = 11;
        ShowContent(Page);
        StartCoroutine(SavingBehaviours(Behaviour_Bank.SupportingBehaviour, Behaviour_Bank.SupportingBehaviour_Guide[0], Behaviour_Bank.SupportingBehaviour_Guide[2], Behaviour_Bank.SupportingBehaviour_Guide[2] + "2"));
    }
    void ShowContent(int n)
    {
        PageUp_text.text = Page.ToString();
        PageDown_text.text = (Page+1).ToString();
        switch (n)
        {
            case 1:
                Item();
                break;
            case 3:
                Item2();
                break;
            case 5:
                Task();
                break;
            case 7:
                Learn();
                break;
            case 9:
                Battle();
                break;
            case 11:
                Image();
                break;
            default:
                break;
        }
    }
    #endregion

    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
    IEnumerator SavingBehaviours(string Bclass, string B1, string B2, string B3)
    {
        StartCoroutine(ml.SetBehaviour("LearnerLog_Behaviour.php", Bclass, B1, B2, B3));
        yield return new WaitForSeconds(0.1f);
    }
}
