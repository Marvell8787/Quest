using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class UI_Deck : MonoBehaviour {

    #region Variable Events
    EventTriggerType EPClick = EventTriggerType.PointerClick;
    #endregion

    public Button Back_btn;

    public AudioSource ok;

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
