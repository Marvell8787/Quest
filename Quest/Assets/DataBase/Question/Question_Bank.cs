using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Question_Bank {
    public static string[] Question_Level2 = new string[6] { "What do you want for breakfast?", "She wants some noodles.","Tom wants some rice for dinner.", "I eat some noodles.", "The girl wants a hamburger and some pizza for lunch.", "What does he want for breakfast?" };
    public static string[,] Question_Level2_BtnAns = new string[6, 3] { { "What does she want for lunch?" , "What do you want for breakfast?" , "What does he want for dinner?" },
        {"She wants a hamburger." , "She wants some soup." , "She wants some noodles." },
        {"Tom wants some soup for lunch.","Tom wants some rice for dinner.","Tom wants some noodles for dinner."},
        {"I eat some noodles.","I eat a hamburger.","I eat some rice."},
        {"The girl wants a hamburger and some pizza for lunch.","The girl wants some chicken for dinner.","The girl wants a hamburger and some pork for lunch."},
        {"What does she want for breakfast?","What do you want for breakfast?","What does he want for lunch?"}
        
    };
    public static int Question_Level4_Num=10;
    public static string[,] Question_Level4 = new string[10,2] {{ "I want a sandwich _ dinner.", "for" },{ "I want _ noodles.", "some" },{ "Sarah _ some want.","wants" }, { "What _ Danny want for breakfast.","does" }, {"Dad wants some _ for lunch.","rice" }, { "Danny _  to school every day.", "walks" }, { "Dino _  basketball at 2:00.", "plays" }, { "My sister and I _ in the bedroom .", "sleep" }, { "I _ two hamburgers.", "eat" }, { "Wow! We are _ Japan.", "in" } };
    public static string[,] Question_Level4_BtnAns = new string[10, 3] { { "with", "for", "to" }, { "a", "this", "some" }, { "want", "wants", "wanting" }, { "do", "does", "are" }, { "a rice", "rice", "rices" }, { "walks", "walk", "walking" }, { "plays", "play", "playing" }, { "sleep", "sleeps", "sleeping" }, { "eat", "eats", "eating" }, { "in", "on", "under" } };

    public static int Question_Level5_Num = 2; //雖然2題 但實際上輸出只會有1題
    public static int Question_Level5_QuestionNum = 4; //每1閱讀分為4小題
    public static string[,] Question_Level5 = new string[2, 5]{ {"It’s lunch time.\n Today, I want a (1) and Tim (2) some salad (3) lunch.\n We are very hungry.\n Mmm, the food looks good.\n Wow! The food is really (4).\n We love it! ","hambuger","wants","for","yummy" }
    ,{"Zac: Winnie, what are you (1) ?\nWinnie: I’m eating beef noodles. Do you want (2) ? \nZac: Yes, (3). Mmm, they taste good.\nWinnie: Are you eating fried rice, Zac?\nZac: Yes, I am. It (4) yummy, too.","doing","some","please","is" }};
    public static string[,,] Question_Level5_BtnAns = new string[2, 4, 3]{{
    {"rice","soup","hambuger"},{"want","wants","wanting"},{"for","to","in"},{"yuck","yummy","happy"}},
    {{"doing","do","does"},{"a","some","the"},{"good","please","OK"},{"does","are","is"}}
    };

    public static int Question_Battl_Num = 8;
    public static string[]  Question_Battle = new string[8] { "like", "file", "dave", "by", "wine", "sky","tile","flea" };
    public static string[,] Question_Battle_BtnAns = new string[8, 3] { { "like", "lunch", "lake" }, { "file", "fill", "far" }, { "dave", "dive", "dark" }, { "by", "bar", "bee" }, { "win", "wine", "why" }, { "sky", "skin", "skate" }, { "tell", "tail", "tile" }, { "flea", "fly", "fine" } };

    public static string[,] Question_Battle2 = new string[6, 2] { { "A: What do you want for lunch ?\nB: __.", "I want some salad for lunch." }, { "A: What time is it?\nB:It's 12 o'clock. _ ", "Time for lunch!" }, { "A: May I help you?\nB: __.", "Yes. A table for three, please." }, { "A: __ \nB: Yes, please.", "May I help you?" }, { "A: Thank you very much.\nB: __.", "You're welcome." }, { "A: What does Amy want for dinner?\nB: __", "She wants some soup." } };
    public static string[,] Question_Battle2_BtnAns = new string[6, 3] { { "I want some soup for dinner.", "I want some salad for lunch.", "He wants some soup for dinner" }, { "Time for dinner!", "Time for lunch!", "Time for breakfast!" }, { "Yes. A table for three, please.", "Good job!", "It's noodle day." }, { "May I help you?", "Say cheese.", "You're welcome." }, { "You're welcome.", "Excuse me.", "Be careful." }, { "She sees some rabbits.", "She has a headache.", "She wants some soup." } };

}
