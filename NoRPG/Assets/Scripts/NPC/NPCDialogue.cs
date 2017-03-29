using UnityEngine;
using SimpleJSON;

public class NPCDialogue : MonoBehaviour
{
    static string json = "{ \"0_Math_OA\" : { \"npcName\" : \"Hans\", \"npcText\" : \"First class, Math, Operations and Algebraic Thinkin\", \"gamelistTitle\" : \"Blablabla\", \"gamelistDescription\" : \"Representing and solve problems involving addition and subtraction.\\nUnderstand and apply properties of operations and the relationship between addition and subtraction.\\nAdd and subtract within 20.\\nWork with addition and subtraction equations.\", \"npcType\" : \"Trader\" } }";

    public static string GetNpcName(string key)
    {
        string npcName = JSON.Parse(json)[key]["npcName"];
        return npcName;
    }

    public static string GetNpcText(string key)
    {
        string npcText = JSON.Parse(json)[key]["npcText"];
        return npcText;
    }

    public static string GetGamelistTitle(string key)
    {
        string gamelistTitle = JSON.Parse(json)[key]["gamelistTitle"];
        return gamelistTitle;
    }

    public static string GetGamelistDescription(string key)
    {
        string gamelistDescription = JSON.Parse(json)[key]["gamelistDescription"];
        return gamelistDescription;
    }

    public static string GetNpcType(string key)
    {
        string npcType = JSON.Parse(json)[key]["npcType"];
        return npcType;
    }
}
