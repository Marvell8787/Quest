using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Shop : MonoBehaviour {

    #region Variable
    private int choose_n = 10;
    private int[] check_n = new int[15];
    #endregion

    #region Shop
    public GameObject[] GameObject_Item = new GameObject[12];
    public Image[] Image_Item = new Image[12];
    public Text[] Text_Have = new Text[3];
    public Text Text_Shop_Info, Text_Buy;
    public Button Button_Buy, Button_Back;
    public Text Button_Buy_Text, Button_Back_Text;
    public AudioSource ok, choose;
    #endregion


    // Use this for initialization
    void Start () {
        for (int i = 0; i < 15; i++)
            check_n[i] = 0;
        //Check();

        Text_Have[0].text = Learner_Data.Learner_GetData("Score").ToString();
        Text_Have[1].text = Learner_Data.Learner_GetData("Coin").ToString();
        Text_Have[2].text = Learner_Data.Learner_GetData("Crystal").ToString();
    }

}
