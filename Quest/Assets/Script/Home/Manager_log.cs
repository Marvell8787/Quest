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
    public IEnumerator SetBehavior(string fileName, string s, string behavior)
    {
        WWWForm LearnerForm = new WWWForm();
        LearnerForm.AddField("Username", System_Data.Username);
        LearnerForm.AddField("Item", s);
        LearnerForm.AddField("Num", behavior);
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
