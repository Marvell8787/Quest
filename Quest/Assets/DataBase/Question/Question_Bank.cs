using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Question_Bank {
    public static string[] Question_Level2 = new string[6] { "What do you want for breakfast?", "She wants some noodles.","Tom wants some rice for dinner.", "I eat some noodles.","The girl wants a hamburger and some pizza for lunch.","What does he want for breakfast?" };
    public static string[,] Question_Level2_BtnAns = new string[6, 3] { { "What does she want for lunch?" , "What do you want for breakfast?" , "What does he want for dinner?" },
        { "She wants a hamburger." , "She wants some soup." , "She wants some noodles." },
        {"Tom wants some soup for lunch.","Tom wants some rice for dinner.","Tom wants some noodles for dinner."},
        {"I eat some noodles.","I eat a hamburger.","I eat some rice."},
        {"The girl wants a hamburger and some pizza for lunch","The girl wants some chicken and some pork for lunch","The girl wants some chicken for dinner."},
        {"What does she want for breakfast?","What do you want for breakfast?","What does he want for lunch?"}
        
    };
    public static string[,] Question_Level4 = new string[6,2] {{ "I want a sandwich _ dinner.", "for" },{ "I want _ noodles.", "some" },{ "Sarah _ some want.","wants" }, { "What _ Danny want for breakfast.","does" }, {"Dad wants some _ for lunch.","rice" }, {"He _ some soup.","wants"}};
    public static string[,] Question_Level4_BtnAns = new string[6, 3] { { "with", "for", "to" }, { "a", "this", "some" }, { "want", "wants", "wanting" }, { "do", "does", "are" }, { "a rice", "rice", "rices" }, { "wants", "want", "wanting" } };
}
