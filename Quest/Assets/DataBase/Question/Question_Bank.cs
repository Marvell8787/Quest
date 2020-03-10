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
    public static string[,] Question_Level4 = new string[10,2] {{ "I want a sandwich _ dinner.", "for" },{ "I want _ noodles.", "some" },{ "Sarah _ some want.","wants" }, { "What _ Danny want for breakfast.","does" }, {"Dad wants some _ for lunch.","rice" }, { "Danny _  to school every day.", "walks" }, { "Dino _  basketball at 2:00.", "plays" }, { "My sister and I _ in the bedroom .", "sleep" }, { "I _ two hamburgers.", "eat" }, { "I _ TV at 7:00 pm.", "watch" } };
    public static string[,] Question_Level4_BtnAns = new string[10, 3] { { "with", "for", "to" }, { "a", "this", "some" }, { "want", "wants", "wanting" }, { "do", "does", "are" }, { "a rice", "rice", "rices" }, { "walks", "walk", "walking" }, { "plays", "play", "playing" }, { "sleep", "sleeps", "sleeping" }, { "eat", "eats", "eating" }, { "watches", "watch", "watching" } };

    public static int Question_Battl_Num = 8;
    public static string[]  Question_Battle = new string[8] { "like", "file", "dave", "by", "wine", "sky","tile","flea" };
    public static string[,] Question_Battle_BtnAns = new string[8, 3] { { "like", "lunch", "lake" }, { "file", "fill", "far" }, { "dave", "dive", "dark" }, { "by", "bar", "bee" }, { "win", "wine", "why" }, { "sky", "skin", "skate" }, { "tell", "tail", "tile" }, { "flea", "fly", "fine" } };

    public static string[,] Question_Battle2 = new string[6, 2] { { "A: What do you want for lunch ?\n B: __.", "I want some salad for lunch." }, { "A: What time is it?\n B:It's 12 o'clock. _ ", "Time for lunch!" }, { "A: May I help you?\n B: __.", "Yes. A table for three, please." }, { "A: __ \nB: Yes, please.", "May I help you?" }, { "A: Thank you very much.\nB: __.", "You're welcome." }, { "A: What does Amy want for dinner?\nB: __", "She wants some soup." } };
    public static string[,] Question_Battle2_BtnAns = new string[6, 3] { { "I want some soup for dinner.", "I want some salad for lunch.", "He wants some soup for dinner" }, { "Time for dinner!", "Time for lunch!", "Time for breakfast!" }, { "Yes. A table for three, please.", "Good job!", "It's noodle day" }, { "May I help you?", "Say cheese.", "You're welcome." }, { "You're welcome.", "Excuse me.", "Be careful." }, { "She sees some rabbits.", "She has a headache.", "She wants some soup." } };

}
