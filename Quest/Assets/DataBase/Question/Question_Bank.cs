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

    public static string[,] Question_Battle = new string[6, 2] { { "A: What do you want for _ ?\n B:I want some noodles for dinner.", "dinner" }, { "A: What time is it?\n B:It's 12 o'clock. Time for _ !", "lunch" }, { "A: What do you want?\n B: I want _ salad,please.", "some" }, { "A: What _ Amy want for dinner?\nB: Some salad and noodles,please.", "does" }, { "A: Mom wants some _ for lunch.\nB:I want some soup,too.", "soup" }, { "A: He _ some rice.\nB:I also want it.", "wants" } };
    public static string[,] Question_Battle_BtnAns = new string[6, 3] { { "dinner", "lunch", "breakfast" }, { "dinner", "lunch", "breakfast" }, { "some", "many", "two" }, { "do", "does", "are" }, { "rice", "soup", "noodles" }, { "wants", "want", "wanting" } };

}
