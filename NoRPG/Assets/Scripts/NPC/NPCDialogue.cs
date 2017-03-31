using UnityEngine;
using SimpleJSON;

public class NPCDialogue : MonoBehaviour
{
    string json;

    public NPCDialogue()
    {
       System.IO.FileStream fs = System.IO.File.OpenRead("Assets/Scripts/NPC/npcList.json");
       long length = fs.Length;
       byte[] stream = new byte[length];
       fs.Read(stream, 0, (int)length);
       json = System.Text.Encoding.UTF8.GetString(stream);
    }
  
    public string GetNpcName(string key)
    {
        string npcName = JSON.Parse(json)[key]["npcName"];
        return npcName;
    }

    public string GetNpcText(string key)
    {
        string username = GameControl.control.username;
        string npcText = "Hey " + username + "!\n" + JSON.Parse(json)[key]["npcText"];
        return npcText;
    }

    public string GetGamelistTitle(string key)
    {
        string gamelistTitle = JSON.Parse(json)[key]["gamelistTitle"];
        return gamelistTitle;
    }

    public string GetGamelistDescription(string key)
    {
        string gamelistDescription = JSON.Parse(json)[key]["gamelistDescription"];
        return gamelistDescription;
    }

    public string GetNpcType(string key)
    {
        string npcType = JSON.Parse(json)[key]["npcType"];
        return npcType;
    }
}
