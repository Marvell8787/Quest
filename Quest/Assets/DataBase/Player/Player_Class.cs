using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player_Class{
    private int LP = 0;
    private int[] Deck_Status = new int[22] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //卡片持有狀態 0:無(本來就沒有) 1:有(持有) 2:持有但已抽掉 
    //0~21 : 牌 22:沒有此牌 
    private int[] Deck_Fight = new int[22] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //對戰牌組
    private int Deck_Num = 0;
    private int Deck_Draw = 0; //已抽取牌數
    private int Hand = 5;
    //0~21 : 牌 22:空的 
    private int[] Hand_Status = new int[5] { 22, 22, 22, 22, 22 };

    public Player_Class(int _LP = 0, int _Deck_Num = 0,int _Deck_Draw = 0, int _Hand = 5)
    {
        LP = _LP;
        Deck_Num = _Deck_Num;
        Deck_Draw = _Deck_Draw;
        Hand = _Hand;
    }
    public int GetLP()
    {
        return LP;
    }
    public int GetDeck_Status(int n)
    {
        return Deck_Status[n];
    }
    public int GetDeck_Fight(int n)
    {
        return Deck_Fight[n];
    }
    public int GetDeck_Num()
    {
        return Deck_Num;
    }
    public int GetDeck_Draw()
    {
        return Deck_Draw;
    }
    public int GetHand()
    {
        return Hand;
    }
    public int GetHand_Status(int n)
    {
        return Hand_Status[n];
    }
    public void ChangeLP(int n)
    {
        LP = n;
    }
    public void ChangeDeck_Status(int s, int n) //s=索引值 n=值
    {
        Deck_Status[s] = n;
    }
    public void ChangeDeck_Fight(int s, int n) //s=索引值 n=值
    {
        Deck_Fight[s] = n;
    }
    public void ChangeDeck_Num(int n)
    {
        Deck_Num = n;
    }

    public void ChangeHand(int n)
    {
        Hand = n;
    }
    public void ChangeHand_Status(int s, int n) //s=索引值 n=值
    {
        Hand_Status[s] = n;
    }
    public void AddDeck_Draw(int n) //抽牌
    {
        Deck_Draw += n;
    }
    public void AddLP(int n)
    {
        LP += n;
    }
    public void DecLP(int n)
    {
        LP -= n;
    }
    public void DecDeck_Num(int n)
    {
        Deck_Num -= n;
    }
}
