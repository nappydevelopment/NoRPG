using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    //Player information
    public string username;
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

    void Start()
    {
        CreateFile();
    }

    //save last position
    void OnApplicationQuit()
    {
        string currentScene = PortalControl.control.currentScene;

        if (currentScene == "Desert" || currentScene == "first_forrest" || currentScene == "Snow_World" || currentScene == "Lavawelt" || currentScene == "Tropic_World" || currentScene == "Startwelt"){
            Debug.Log("Application will be quit! Last position of the player is " + currentScene);
            lastPosition = currentScene;
        }
    }

    void SaveLocalDataAtServer()
    {

    }

    void LoadLocalDataFromServer()
    {
        
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
        data.playedIntro = playedIntro;


        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Saving GameControl successful");
    }

    public void CreateFile()
    {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Debug.Log(Application.persistentDataPath);
            Load();
            Debug.Log("Loading GameControl successful");
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            Debug.Log(Application.persistentDataPath); 

            PlayerData data = new PlayerData();
            data.username = "";
            data.audioSetting = true;
            data.qualitySetting = true;
            data.downloadedGames = new List<Games>();
            playedIntro = false;
            chest_1_desert_open = false;
            chest_2_desert_open = false;
            chest_3_desert_open = false;
            chest_4_desert_open = false;
            chest_5_desert_open = false;
            chest_6_desert_open = false;
            chest_7_desert_open = false;
            chest_8_desert_open = false;
            chest_1_forest_open = false;
            chest_2_forest_open = false;
            chest_3_forest_open = false;
            chest_4_forest_open = false;
            chest_5_forest_open = false;
            chest_6_forest_open = false;
            chest_7_forest_open = false;
            chest_8_forest_open = false;
            chest_1_lava_open = false;
            chest_2_lava_open = false;
            chest_3_lava_open = false;
            chest_4_lava_open = false;
            chest_5_lava_open = false;
            chest_6_lava_open = false;
            chest_7_lava_open = false;
            chest_8_lava_open = false;
            chest_1_snow_open = false;
            chest_2_snow_open = false;
            chest_3_snow_open = false;
            chest_4_snow_open = false;
            chest_5_snow_open = false;
            chest_6_snow_open = false;
            chest_7_snow_open = false;
            chest_8_snow_open = false;
            chest_1_tropen_open = false;
            chest_2_tropen_open = false;
            chest_3_tropen_open = false;
            chest_4_tropen_open = false;
            chest_5_tropen_open = false;
            chest_6_tropen_open = false;
            chest_7_tropen_open = false;
            chest_8_tropen_open = false;

            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Creating GameControl successful");
        }
    }

    public void Load()
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
        playedIntro = data.playedIntro;

        Debug.Log("Loading GameControl successful");
    }
}

[Serializable]
class PlayerData
{
    //Player information
    public string username;

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