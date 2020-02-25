using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Task_Class {

    private string Title = "";
    private string Request = "";
    private string Reward = "";
    private string Punishment = "";
    private int Status = 0;
    public Task_Class(string _Title= "", string _Request = "", string _Reward = "", string _Punishment = "", int _Status = 0)
    {
        Title = _Title;
        Request = _Request;
        Reward = _Reward;
        Punishment = _Punishment;
        Status = _Status;
    }
    public string GetTitle()
    {
        return Title;
    }
    public string GetRequest()
    {
        return Request;
    }
    public string GetReward()
    {
        return Reward;
    }
    public string GetPunishment()
    {
        return Punishment;
    }
    public int GetStatus()
    {
        return Status;
    }
    public void ChangeStatus(int n)
    {
        Status = n;
    }
}
