using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Vocabulary_Class{
    private string E_Name = "";
    private string C_Name = "";
    private string Voice = "";
    private string PartOfSpeech = "";
    private string Sentence = "";

    public Vocabulary_Class(string _E_Name = "", string _C_Named = "", string _Voice = "", string _PartOfSpeech = "", string _Sentence = "")
    {
        E_Name = _E_Name;
        C_Name = _C_Named;
        Voice = _Voice;
        PartOfSpeech = _PartOfSpeech;
        Sentence = _Sentence;
    }
    public string GetE_Name()
    {
        return E_Name;
    }
    public string GetC_Name()
    {
        return C_Name;
    }
    public string GetVoice()
    {
        return Voice;
    }
    public string GetPartOfSpeech()
    {
        return PartOfSpeech;
    }
    public string GetSentence()
    {
        return Sentence;
    }
}
