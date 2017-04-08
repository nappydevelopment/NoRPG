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

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Saving GameControl successful");
    }

    public void CreateFile()
    {
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
            data.downloadedGames = null;

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

    public int characterShader;
    public string characterGender;

    //lastLocation
    public string lastOpenScene;

}