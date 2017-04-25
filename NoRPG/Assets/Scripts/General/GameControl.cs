using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    private string secretKey = "norpg";
    public string saveURL = "http://norpg.it.dh-karlsruhe.de/save.php?";
    public string loadURL = "http://norpg.it.dh-karlsruhe.de/load.php?";
    //Player information
    public string username;
    public string correctCharacterModel;
    public string lastPosition;
    public List<Games> downloadedGames;
    //Truhen
    public bool chest_1_forest_open;
    public bool chest_2_forest_open;
    public bool chest_3_forest_open;
    public bool chest_4_forest_open;
    public bool chest_5_forest_open;
    public bool chest_6_forest_open;
    public bool chest_7_forest_open;
    public bool chest_8_forest_open;
    public bool chest_1_tropen_open;
    public bool chest_2_tropen_open;
    public bool chest_3_tropen_open;
    public bool chest_4_tropen_open;
    public bool chest_5_tropen_open;
    public bool chest_6_tropen_open;
    public bool chest_7_tropen_open;
    public bool chest_8_tropen_open;
    public bool chest_1_desert_open;
    public bool chest_2_desert_open;
    public bool chest_3_desert_open;
    public bool chest_4_desert_open;
    public bool chest_5_desert_open;
    public bool chest_6_desert_open;
    public bool chest_7_desert_open;
    public bool chest_8_desert_open;
    public bool chest_1_snow_open;
    public bool chest_2_snow_open;
    public bool chest_3_snow_open;
    public bool chest_4_snow_open;
    public bool chest_5_snow_open;
    public bool chest_6_snow_open;
    public bool chest_7_snow_open;
    public bool chest_8_snow_open;
    public bool chest_1_lava_open;
    public bool chest_2_lava_open;
    public bool chest_3_lava_open;
    public bool chest_4_lava_open;
    public bool chest_5_lava_open;
    public bool chest_6_lava_open;
    public bool chest_7_lava_open;
    public bool chest_8_lava_open;

    //Intro
    public bool playedIntro;

    //Character
    public string characterGender;
    public int characterShader;

    //Settings
    public bool audioSetting;
    public bool qualitySetting;


    void Awake()
    {
        //check is there a GameControl Object!
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    //save last position
    void OnApplicationQuit()
    {
        string currentScene = PortalControl.control.currentScene;

        if (currentScene == "Desert" || currentScene == "first_forrest" || currentScene == "Snow_World" || currentScene == "Lavawelt" || currentScene == "Tropic_World" || currentScene == "Startwelt"){
            Debug.Log("Application will be quit! Last position of the player is " + currentScene);
            lastPosition = currentScene;
        }

        Save();
    }

    public void Save()
    {
        /*BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath);*/

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        PlayerData data = new PlayerData();
        data.username = username;
        data.audioSetting = audioSetting;
        data.qualitySetting = qualitySetting;
        data.downloadedGames = downloadedGames;
        data.chest_1_desert_open = chest_1_desert_open;
        data.chest_2_desert_open = chest_2_desert_open;
        data.chest_3_desert_open = chest_3_desert_open;
        data.chest_4_desert_open = chest_4_desert_open;
        data.chest_5_desert_open = chest_5_desert_open;
        data.chest_6_desert_open = chest_6_desert_open;
        data.chest_7_desert_open = chest_7_desert_open;
        data.chest_8_desert_open = chest_8_desert_open;
        data.chest_1_forest_open = chest_1_forest_open;
        data.chest_2_forest_open = chest_2_forest_open;
        data.chest_3_forest_open = chest_3_forest_open;
        data.chest_4_forest_open = chest_4_forest_open;
        data.chest_5_forest_open = chest_5_forest_open;
        data.chest_6_forest_open = chest_6_forest_open;
        data.chest_7_forest_open = chest_7_forest_open;
        data.chest_8_forest_open = chest_8_forest_open;
        data.chest_1_lava_open = chest_1_lava_open;
        data.chest_2_lava_open = chest_2_lava_open;
        data.chest_3_lava_open = chest_3_lava_open;
        data.chest_4_lava_open = chest_4_lava_open;
        data.chest_5_lava_open = chest_5_lava_open;
        data.chest_6_lava_open = chest_6_lava_open;
        data.chest_7_lava_open = chest_7_lava_open;
        data.chest_8_lava_open = chest_8_lava_open;
        data.chest_1_snow_open = chest_1_snow_open;
        data.chest_2_snow_open = chest_2_snow_open;
        data.chest_3_snow_open = chest_3_snow_open;
        data.chest_4_snow_open = chest_4_snow_open;
        data.chest_5_snow_open = chest_5_snow_open;
        data.chest_6_snow_open = chest_6_snow_open;
        data.chest_7_snow_open = chest_7_snow_open;
        data.chest_8_snow_open = chest_8_snow_open;
        data.chest_1_tropen_open = chest_1_tropen_open;
        data.chest_2_tropen_open = chest_2_tropen_open;
        data.chest_3_tropen_open = chest_3_tropen_open;
        data.chest_4_tropen_open = chest_4_tropen_open;
        data.chest_5_tropen_open = chest_5_tropen_open;
        data.chest_6_tropen_open = chest_6_tropen_open;
        data.chest_7_tropen_open = chest_7_tropen_open;
        data.chest_8_tropen_open = chest_8_tropen_open;
        data.correctCharacterModel = correctCharacterModel;
        data.lastOpenScene = lastPosition;
        data.playedIntro = playedIntro;


        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Successfully saved new data in file");

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            StartCoroutine(SaveDataRoutine(username));
        }
    }
    public IEnumerator SaveDataRoutine (string u) {

        string data = File.ReadAllText(Application.persistentDataPath + "/playerInfo.dat");
        string hash = MD5Test.Md5Sum(u + data + secretKey);

        WWWForm form = new WWWForm();
        form.AddField("username", u);
        form.AddField("data", data);
        form.AddField("hash", hash);
        WWW www = new WWW(saveURL, form);

        yield return www;

        if (www.error != null) {
            Debug.Log("There was an error saving on Cloud: " + www.error);
        } else {
            Debug.Log(www.text);
        }

    }

    public void CreateFile()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat")) { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            Debug.Log(Application.persistentDataPath); 

            PlayerData data = new PlayerData();
            data.username = "";
            data.audioSetting = true;
            data.qualitySetting = true;
            data.downloadedGames = new List<Games>();
            data.playedIntro = false;
            data.lastOpenScene = "Startwelt";
            data.chest_1_desert_open = false;
            data.chest_2_desert_open = false;
            data.chest_3_desert_open = false;
            data.chest_4_desert_open = false;
            data.chest_5_desert_open = false;
            data.chest_6_desert_open = false;
            data.chest_7_desert_open = false;
            data.chest_8_desert_open = false;
            data.chest_1_forest_open = false;
            data.chest_2_forest_open = false;
            data.chest_3_forest_open = false;
            data.chest_4_forest_open = false;
            data.chest_5_forest_open = false;
            data.chest_6_forest_open = false;
            data.chest_7_forest_open = false;
            data.chest_8_forest_open = false;
            data.chest_1_lava_open = false;
            data.chest_2_lava_open = false;
            data.chest_3_lava_open = false;
            data.chest_4_lava_open = false;
            data.chest_5_lava_open = false;
            data.chest_6_lava_open = false;
            data.chest_7_lava_open = false;
            data.chest_8_lava_open = false;
            data.chest_1_snow_open = false;
            data.chest_2_snow_open = false;
            data.chest_3_snow_open = false;
            data.chest_4_snow_open = false;
            data.chest_5_snow_open = false;
            data.chest_6_snow_open = false;
            data.chest_7_snow_open = false;
            data.chest_8_snow_open = false;
            data.chest_1_tropen_open = false;
            data.chest_2_tropen_open = false;
            data.chest_3_tropen_open = false;
            data.chest_4_tropen_open = false;
            data.chest_5_tropen_open = false;
            data.chest_6_tropen_open = false;
            data.chest_7_tropen_open = false;
            data.chest_8_tropen_open = false;
            data.correctCharacterModel = "M1";

            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Creating GameControl successful");
        }
    }

    private bool hasInternetConnection () {
        return false;
       /* try {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://www.google.com");
            return true;
        }
        catch( Exception e) {
            return false;
        } 
        finally {

        }*/
    }

    public void LoadFromFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close();

        username = data.username;
        audioSetting = data.audioSetting;
        qualitySetting = data.qualitySetting;
        downloadedGames = data.downloadedGames;
        chest_1_desert_open = data.chest_1_desert_open;
        chest_2_desert_open = data.chest_2_desert_open;
        chest_3_desert_open = data.chest_3_desert_open;
        chest_4_desert_open = data.chest_4_desert_open;
        chest_5_desert_open = data.chest_5_desert_open;
        chest_6_desert_open = data.chest_6_desert_open;
        chest_7_desert_open = data.chest_7_desert_open;
        chest_8_desert_open = data.chest_8_desert_open;
        chest_1_forest_open = data.chest_1_forest_open;
        chest_2_forest_open = data.chest_2_forest_open;
        chest_3_forest_open = data.chest_3_forest_open;
        chest_4_forest_open = data.chest_4_forest_open;
        chest_5_forest_open = data.chest_5_forest_open;
        chest_6_forest_open = data.chest_6_forest_open;
        chest_7_forest_open = data.chest_7_forest_open;
        chest_8_forest_open = data.chest_8_forest_open;
        chest_1_lava_open = data.chest_1_lava_open;
        chest_2_lava_open = data.chest_2_lava_open;
        chest_3_lava_open = data.chest_3_lava_open;
        chest_4_lava_open = data.chest_4_lava_open;
        chest_5_lava_open = data.chest_5_lava_open;
        chest_6_lava_open = data.chest_6_lava_open;
        chest_7_lava_open = data.chest_7_lava_open;
        chest_8_lava_open = data.chest_8_lava_open;
        chest_1_snow_open = data.chest_1_snow_open;
        chest_2_snow_open = data.chest_2_snow_open;
        chest_3_snow_open = data.chest_3_snow_open;
        chest_4_snow_open = data.chest_4_snow_open;
        chest_5_snow_open = data.chest_5_snow_open;
        chest_6_snow_open = data.chest_6_snow_open;
        chest_7_snow_open = data.chest_7_snow_open;
        chest_8_snow_open = data.chest_8_snow_open;
        chest_1_tropen_open = data.chest_1_tropen_open;
        chest_2_tropen_open = data.chest_2_tropen_open;
        chest_3_tropen_open = data.chest_3_tropen_open;
        chest_4_tropen_open = data.chest_4_tropen_open;
        chest_5_tropen_open = data.chest_5_tropen_open;
        chest_6_tropen_open = data.chest_6_tropen_open;
        chest_7_tropen_open = data.chest_7_tropen_open;
        chest_8_tropen_open = data.chest_8_tropen_open;
        correctCharacterModel = data.correctCharacterModel;
        playedIntro = data.playedIntro;
        lastPosition = data.lastOpenScene;

        Debug.Log("Loading GameControl successful");
    }

    public void LoadFromCloud (string username) {
        StartCoroutine(LoadDataRoutine(username));
    }

    public IEnumerator LoadDataRoutine (string username) {

        string hash = MD5Test.Md5Sum(username + secretKey);

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("hash", hash);
        WWW www = new WWW(loadURL, form);
        
        yield return www;

        if (www.error != null) {
            Debug.Log("There was an error getting the data from Cloud: " + www.error);
        } else {
            if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
                if(www.text != "")
                    File.WriteAllText(Application.persistentDataPath + "/playerInfo.dat", www.text);
                Debug.Log(www.text);
                LoadFromFile();
                Debug.Log("Load successfull from Cloud");
            }
        }
    }
}

[Serializable]
class PlayerData
{
    //Player information
    public string username;
    public string correctCharacterModel;

    //Settings
    public bool audioSetting;
    public bool qualitySetting;

    public bool loggedInStatus;

    //Games
    public List<Games> downloadedGames;

    //Progress

    //Truhen
    public bool chest_1_forest_open;
    public bool chest_2_forest_open;
    public bool chest_3_forest_open;
    public bool chest_4_forest_open;
    public bool chest_5_forest_open;
    public bool chest_6_forest_open;
    public bool chest_7_forest_open;
    public bool chest_8_forest_open;
    public bool chest_1_tropen_open;
    public bool chest_2_tropen_open;
    public bool chest_3_tropen_open;
    public bool chest_4_tropen_open;
    public bool chest_5_tropen_open;
    public bool chest_6_tropen_open;
    public bool chest_7_tropen_open;
    public bool chest_8_tropen_open;
    public bool chest_1_desert_open;
    public bool chest_2_desert_open;
    public bool chest_3_desert_open;
    public bool chest_4_desert_open;
    public bool chest_5_desert_open;
    public bool chest_6_desert_open;
    public bool chest_7_desert_open;
    public bool chest_8_desert_open;
    public bool chest_1_snow_open;
    public bool chest_2_snow_open;
    public bool chest_3_snow_open;
    public bool chest_4_snow_open;
    public bool chest_5_snow_open;
    public bool chest_6_snow_open;
    public bool chest_7_snow_open;
    public bool chest_8_snow_open;
    public bool chest_1_lava_open;
    public bool chest_2_lava_open;
    public bool chest_3_lava_open;
    public bool chest_4_lava_open;
    public bool chest_5_lava_open;
    public bool chest_6_lava_open;
    public bool chest_7_lava_open;
    public bool chest_8_lava_open;

    //intro
    public bool playedIntro;

    public int characterShader;
    public string characterGender;

    //lastLocation
    public string lastOpenScene;

}