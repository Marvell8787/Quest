using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Guide : MonoBehaviour {

    public Button Back_btn;

    public AudioSource choose, ok, cancel;


    // Use this for initialization
    void Start () {
        Back_btn.onClick.AddListener(Back);

    }

    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
