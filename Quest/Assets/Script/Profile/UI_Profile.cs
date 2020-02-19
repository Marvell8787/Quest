using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Profile : MonoBehaviour {

    public Button Back_btn;

    public AudioSource PageTurnning, ok;

    // Use this for initialization
    void Start () {
		
	}

    void Back()
    {
        ok.Play();
        SceneManager.LoadScene("Home");
    }
}
