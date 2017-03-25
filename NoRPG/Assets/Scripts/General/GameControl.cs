using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    //Player information
    public string username;
    //public bool loggedInStatus;
    public string lastPosition;

    //Character
    public string characterGender;
    public int characterShader;

    //Settings
    public bool audioSetting;
    public bool qualitySetting;


    void Awake ()
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
        /*string currentScene = PortalControl.control.currentScene;

        if (currentScene == "DesertSpawnPoint" || currentScene == "first_forrestSpawnPoint" || currentScene == "Snow_WorldSpawnPoint" || currentScene == "LavaweltSpawnPoint" || currentScene == "Tropic_WorldSpawnPoint"){
            Debug.Log("Application will be quit!");
            lastPosition = currentScene;
        }*/
    }

    void SaveLocalDataAtServer()
    {

    }

    void LoadLocalDataFromServer()
    {
        
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath);

        PlayerData data = new PlayerData();
        data.username = username;
        data.audioSetting = audioSetting;
        data.qualitySetting = qualitySetting;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            username = data.username;
            audioSetting = data.audioSetting;
            qualitySetting = data.qualitySetting;
        }
    }

    //todo: Method Synchronize this with the player in the database
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

    //Progress

    //Truhen

    public int characterShader;
    public string characterGender;

    //lastLocation
    public string lastOpenScene;

}