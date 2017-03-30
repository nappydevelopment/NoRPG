using UnityEngine;
using SimpleJSON;

public class NPCDialogue : MonoBehaviour
{
    static string json = "{ \"0_Math_OA\" : { \"npcName\" : \"Hans\", \"npcText\" : \"I am Alfred and I offer math games for the first class. With me you learn Operations and Algebraic Thinking. Do you want to see my games?\", \"gamelistTitle\" : \"Blablabla\", \"gamelistDescription\" : \"Representing and solve problems involving addition and subtraction.\\nUnderstand and apply properties of operations and the relationship between addition and subtraction.\\nAdd and subtract within 20.\\nWork with addition and subtraction equations.\", \"npcType\" : \"Trader\" } }";

    static System.IO.FileStream fs = System.IO.File.OpenRead("Assets/Scripts/NPC/npcList.json");
    static long length = fs.Length;
    static byte[] stream = new byte[length];
    //fs.Read(stream, 0, (int)length);
    //static string json = System.Text.Encoding.UTF8.GetString(stream);
    //var N = JSONNode.Parse(json);

    // doesnt work --> Exception: Error deserializing JSON. Unknown tag: 123
    //static string json = JSONNode.LoadFromFile("Assets/Scripts/NPC/npcList.json");

    public static string GetNpcName(string key)
    {
        string npcName = JSON.Parse(json)[key]["npcName"];
        return npcName;
    }

    public static string GetNpcText(string key)
    {
        string username = GameControl.control.username;
        string npcText = "Hey " + username + "!\n" + JSON.Parse(json)[key]["npcText"];
        return npcText;
    }

    public static string GetNpcText2(string key)
    {
        string npcText2 = JSON.Parse(json)[key]["npcText2"];
        return npcText2;
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
