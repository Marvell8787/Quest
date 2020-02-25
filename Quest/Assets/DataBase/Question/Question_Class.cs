using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Question_Class{
    private int QuestionNum = 1;
    private string Question = "";
    private string Answer_r = ""; //正解
    private string Answer_r_Content = ""; //正解內容
    private string Answer_c = ""; //使用者的答案
    private string Answer_c_Content = ""; //使用者的答案內容
    private string FeedBack = ""; //給答案
    public Question_Class(int _QuestionNum = 1, string _Question = "", string _Answer_r = "", string _Answer_r_Content = "", string _Answer_c = "", string _Answer_c_Content = "", string _FeedBack = "")
    {
        QuestionNum = _QuestionNum;
        Question = _Question;
        Answer_r = _Answer_r;
        Answer_r_Content = _Answer_r_Content;
        Answer_c = _Answer_c;
        Answer_c_Content = _Answer_c_Content;
        FeedBack = _FeedBack;
    }
    public int GetQuestionNum()
    {
        return QuestionNum;
    }
    public string GetQuestion()
    {
        return Question;
    }
    public string GetAnswer_r()
    {
        return Answer_r;
    }
    public string GetAnswer_r_Content()
    {
        return Answer_r_Content;
    }
    public string GetAnswer_c()
    {
        return Answer_c;
    }
    public string GetAnswer_c_Content()
    {
        return Answer_c_Content;
    }
    public string GetFeedBack()
    {
        return FeedBack;
    }
    public void ChangeAnswer_r(string s)
    {
        Answer_r = s;
    }
    public void ChangeAnswer_c(string s) 
    {
        Answer_c = s;
    }
    public void ChangeAnswer_c_Content(string s)
    {
        Answer_c_Content = s;
    }
    public void ChangeFeedBack(string s)
    {
        FeedBack = s;
    }
}
