using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Level_Class{
    private string Title = "";
    private string QuestionType = "";
    private string Range = "";
    private string Reward = "";
    private string Punishment = "";
    private string HighestScore = "";

    public Level_Class(string _Title = "", string _QuestionType = "", string _Range = "", string _Reward = "", string _Punishment = "", string _HighestScore = "0")
    {
        Title = _Title;
        QuestionType = _QuestionType;
        Range = _Range;
        Reward = _Reward;
        Punishment = _Punishment;
        HighestScore = _HighestScore;
    }
    public string GetTitle()
    {
        return Title;
    }
    public string GetQuestionType()
    {
        return QuestionType;
    }
    public string GetRange()
    {
        return Range;
    }
    public string GetReward()
    {
        return Reward;
    }
    public string GetPunishment()
    {
        return Punishment;
    }
    public string GetHighestScore()
    {
        return HighestScore;
    }
    public void ChangeHighestScore(string s)
    {
        HighestScore=s;
    }
}
