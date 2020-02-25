using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Vocabulary_Data{

    private static string[] Vocabulary_E_Name = new string[Vocabulary_Bank.Vocabulary_Num]; 
    private static string[] Vocabulary_C_Name = new string[Vocabulary_Bank.Vocabulary_Num];
    private static string[] Vocabulary_Voice = new string[Vocabulary_Bank.Vocabulary_Num];
    private static string[] Vocabulary_PartOfSpeech = new string[Vocabulary_Bank.Vocabulary_Num];
    private static string[] Vocabulary_Sentence = new string[Vocabulary_Bank.Vocabulary_Num];
    
    public static Vocabulary_Class[] vocabulary_temp = new Vocabulary_Class[Vocabulary_Bank.Vocabulary_Num];

    public static void Vocabulary_Init()
    {
        Vocabulary_BankGet();
        for (int i = 0; i < Vocabulary_Bank.Vocabulary_Num; i++)
        {
            vocabulary_temp[i] = new Vocabulary_Class(Vocabulary_E_Name[i], Vocabulary_C_Name[i], Vocabulary_Voice[i], Vocabulary_PartOfSpeech[i], Vocabulary_Sentence[i]);
        }
    }
    public static Vocabulary_Class Vocabulary_Get(int n)
    {
        return vocabulary_temp[n];
    }
    public static void Vocabulary_BankGet()
    {
        for (int i = 0; i < Vocabulary_Bank.Vocabulary_Num; i++)
        {
            Vocabulary_E_Name[i] = Vocabulary_Bank.Vocabulary_E_Name[i]; 
            Vocabulary_C_Name[i] = Vocabulary_Bank.Vocabulary_C_Name[i];
            Vocabulary_Voice[i] = Vocabulary_Bank.Vocabulary_Voice[i];
            Vocabulary_PartOfSpeech[i] = Vocabulary_Bank.Vocabulary_PartOfSpeech[i];
            Vocabulary_Sentence[i] = Vocabulary_Bank.Vocabulary_Sentence[i];
        }
    }

}
