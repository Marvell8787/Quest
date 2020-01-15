using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Main : MonoBehaviour {

    #region Variable
    private string user, pwd;
    #endregion

    #region UI
    public GameObject Main_obj, Setting_obj; //介面
    public Button Login_btn, Setting_btn, Cancel_btn; //登入跟設定
    public InputField Usename_input, Password_input; //帳密輸入
    public Dropdown Language_dpn, Version_dpn; //選擇語言跟版本
    public AudioSource ok, cancel;
    #endregion

    // Use this for initialization
    void Start () {
        Login_btn.onClick.AddListener(Login);
        Setting_btn.onClick.AddListener(Setting);
        Cancel_btn.onClick.AddListener(Cancel);
        Version_dpn.onValueChanged.AddListener(VersionSelect);
    }
	void Login(){
        ok.Play();
        user = Usename_input.text;
        pwd = Password_input.text;
        SceneManager.LoadScene("Home");
    }
    void Setting()
    {
        ok.Play();
        Main_obj.SetActive(false);
        Setting_obj.SetActive(true);
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
                //System_Setting.Version = 0;
                break;
            case 1:
                //System_Setting.Version = 1;
                break;
            case 2:
                //System_Setting.Version = 2;
                break;
            case 3:
                //System_Setting.Version = 3;
                break;
            default:
                break;
        }
    }

}
