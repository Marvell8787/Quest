using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_log{

    private string serverlink = System_Data.serverlink;
    private string[] items;
    public int state;

    public IEnumerator SetData(string fileName, string s, int n)
    {
        WWWForm LearnerForm = new WWWForm();
        LearnerForm.AddField("Username", System_Data.Username);
        LearnerForm.AddField("Item", s);
        LearnerForm.AddField("Num", n);
        WWW reg = new WWW(serverlink + fileName, LearnerForm);
        yield return reg;
        //s_state = reg.ToString();

        if (reg.error == null)
        {
            
        }
        else
        {
            Debug.Log("error msg" + reg.error);
        }
    }
    public IEnumerator SetBehaviour(string fileName, string Bclass, string B1, string B2, string B3)
    {
        WWWForm LearnerForm = new WWWForm();
        LearnerForm.AddField("Username", "behaviour" + System_Data.Username);
        LearnerForm.AddField("behaviour_Class", Bclass);
        LearnerForm.AddField("behaviour_1", B1);
        LearnerForm.AddField("behaviour_2", B2);
        LearnerForm.AddField("behaviour_3", B3);
        WWW reg = new WWW(serverlink + fileName, LearnerForm);
        yield return reg;
        //s_state = reg.ToString();

        if (reg.error == null)
        {

        }
        else
        {
            Debug.Log("error msg" + reg.error);
        }
    }

}
