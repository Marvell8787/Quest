using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Card_Data{

    private static string[] Card_CType = new string[22];
    private static string[] Card_Picture = new string[22] { "fool", "magician", "high-priestess", "empress", "emperor", "hierophant", "lovers", "chariot", "strength", "hermit", "fortune-wheel", "justice", "hanged-man", "death", "temperance", "devil", "tower", "stars", "moon", "sun", "judgement", "world" };
    private static string[] Card_Name = new string[22];
    private static string[] Card_Rarity = new string[22] { "N","N","N","N","N","N","N","R", "R", "R","R", "R", "SR", "SR" ,"SSR", "R", "R", "SR", "SSR", "SR", "SR", "SSR" };
    private static int[] Card_ATK = new int[22] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5,5,6,1,2,3,5,0,0,0 };
    private static string[] Card_Effect = new string[22];

    private static Card_Class[] card_temp = new Card_Class[22];

    public static void Card_Init()
    {
        for (int i = 0; i < 22; i++)
        {
            Card_CType[i] = Card_Bank.E_Card_CType[i];
            Card_Name[i] = Card_Bank.E_Card_Name[i];
            switch (i)
            {
                //Fight
                case 0: Card_Effect[i] = "ATK = 2"; break;
                case 1: Card_Effect[i] = "ATK = 2"; break;
                case 2: Card_Effect[i] = "ATK = 2"; break;
                case 3: Card_Effect[i] = "ATK = 2"; break;
                case 4: Card_Effect[i] = "ATK = 3"; break;
                case 5: Card_Effect[i] = "ATK = 3"; break;
                case 6: Card_Effect[i] = "ATK = 3"; break;
                case 7: Card_Effect[i] = "ATK = 3"; break;
                case 8: Card_Effect[i] = "ATK = 4"; break;
                case 9: Card_Effect[i] = "ATK = 4"; break;
                case 10:Card_Effect[i] = "ATK = 4"; break;
                case 11:Card_Effect[i] = "ATK = 4"; break;
                case 12:Card_Effect[i] = "ATK = 5"; break;
                case 13:Card_Effect[i] = "ATK = 5"; break;
                case 14: Card_Effect[i] = "ATK = 6"; break;
                //Magic
                case 15: Card_Effect[i] = "ATK + 1"; break;
                case 16: Card_Effect[i] = "ATK + 2"; break;
                case 17: Card_Effect[i] = "ATK + 3"; break;
                case 18: Card_Effect[i] = "ATK + 5"; break;
                    //Support
                case 19: Card_Effect[i] = "LP + 2"; break; //sun
                case 20: Card_Effect[i] = "LP + 3"; break; //judgement
                case 21: Card_Effect[i] = "LP + 5"; break; //world
                default: Card_Effect[i] = "#"; break;
            }

        }

        for (int i = 0; i < 22; i++)
        {
            card_temp[i] = new Card_Class(Card_CType[i],Card_Picture[i], Card_Name[i], Card_Rarity[i],"", Card_ATK[i], Card_Effect[i],("No." + i.ToString()));
        }

    }

    public static Card_Class Card_Get(int n)
    {
        return card_temp[n];
    }
}
