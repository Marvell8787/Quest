using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Main : MonoBehaviour {

    #region Variable
    private string user, pwd;
    Manager_Login ml = new Manager_Login();
    #endregion

    #region UI
    public GameObject Main_obj, Setting_obj; //介面
    public Button Login_btn, Setting_btn, Cancel_btn; //登入跟設定
    public InputField Usename_input, Password_input; //帳密輸入
    public Dropdown Version_dpn; //選擇語言跟版本
    public AudioSource ok, cancel;
    public Text Message;//登入訊息
    #endregion

    // Use this for initialization
    void Start () {
        Login_btn.onClick.AddListener(confirmlogin);
        Setting_btn.onClick.AddListener(Setting);
        Cancel_btn.onClick.AddListener(Cancel);
        Version_dpn.onValueChanged.AddListener(VersionSelect);
    }
	void confirmlogin(){
        ok.Play();
        user = Usename_input.text;
        pwd = Password_input.text;
        if (user != "")
        {
            if (pwd != "")
            {
                Message.text = "資料載入中";
                Battle_Data.Battle_Init();
                Card_Data.Card_Init();
                Task_Data.Task_Init();
                Level_Data.Level_Init();
                Vocabulary_Data.Vocabulary_Init();
                StartCoroutine(Login());
            }
            else
            {
                Message.text = "密碼不可為空";
            }
        }
        else
        {
            Message.text = "學號不可為空";
        }
    }
    IEnumerator Login()
    {
        StartCoroutine(ml.CheckLogin("Login.php", user, pwd));
        yield return new WaitForSeconds(1f);
        if (ml.state == 1)
        {
            System_Data.Username = user;
            Vocabulary_Data.Vocabulary_Init();
            SceneManager.LoadScene("Home");
        }
        else if (ml.state == 2)
        {
            Message.text = "帳號或密碼不正確，連線失敗";
        }
        else if (ml.state == 3)
        {
            Message.text = "發生錯誤";
        }
    }
        void Setting()
    {
        ok.Play();
        Main_obj.SetActive(false);
        Setting_obj.SetActive(true);
        Message.text = "";
    }
    void Cancel()
    {
        cancel.Play();
        Main_obj.SetActive(true);
        Setting_obj.SetActive(false);
    }
    void VersionSelect(int index)
    {
        switch (index)
        {
            case 0:
                System_Data.Version = 0;
                break;
            case 1:
                System_Data.Version = 1;
                break;
            case 2:
                System_Data.Version = 2;
                break;
            case 3:
                System_Data.Version = 3;
                break;
            default:
                break;
        }
    }

}
