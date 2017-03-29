using UnityEngine;
using Newtonsoft.Json;

public class NPCDialogue : MonoBehaviour {

    static string json = "{ \"0_Math_OA\" : { \"npcName\" : \"Hans\", \"npcText\" : \"First class, Math, Operations and Algebraic Thinkin\", \"gamelistTitle\" : \"Blablabla\", \"gamelistDescription\" : \"bababababaa\" }";

    public string GetNpcName(string key)
    {
        var data = JsonConvert.DeserializeObject(json);
        //string returnValue = data["0_Math_OA"].Value<string>();
        return null;
    }

    public string GetNpcText(string key)
    {
        return null;
    }

    public string GetGamelistTitle(string key)
    {
        return null;
    }

    public string GetGamelistDescription(string key)
    {
        return null;
    }
}
