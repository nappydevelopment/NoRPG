using UnityEngine;
using SimpleJSON;

public class NPCDialogue : MonoBehaviour
{
    public NPCDialogue(){}
  
    public string GetNpcName(string key, string json)
    { 
        string npcName = JSON.Parse(json)[key]["npcName"];
        return npcName;
    }

    public string GetNpcText(string key, string json)
    {
        string npcText = JSON.Parse(json)[key]["npcText"];
        return npcText;
    }

    public string GetGamelistTitle(string key, string json)
    {
        string gamelistTitle = JSON.Parse(json)[key]["gamelistTitle"];
        return gamelistTitle;
    }

    public string GetGamelistDescription(string key, string json)
    {
        string gamelistDescription = JSON.Parse(json)[key]["gamelistDescription"];
        return gamelistDescription;
    }

    public string GetNpcType(string key, string json)
    {
        string npcType = JSON.Parse(json)[key]["npcType"];
        return npcType;
    }
}
