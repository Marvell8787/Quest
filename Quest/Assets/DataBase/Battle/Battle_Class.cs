using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Battle_Class{

    private string Title = "";
    private string QuestionType = "";
    private string Range = "";
    private string Reward = "";
    private string Punishment = "";
    private string Time = "";
    private string LP = "";
    private string Deck = "";

    public Battle_Class(string _Title = "", string _QuestionType = "", string _Range = "", string _Reward = "", string _Punishment = "", string _Time = "", string _LP = "", string _Deck = "")
    {
        Title = _Title;
        QuestionType = _QuestionType;
        Range = _Range;
        Reward = _Reward;
        Punishment = _Punishment;
        Time = _Time;
        LP = _LP;
        Deck = _Deck;
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
    public string GetTime()
    {
        return Time;
    }
    public string GetLP()
    {
        return LP;
    }
    public string GetDeck()
    {
        return Deck;
    }
}
