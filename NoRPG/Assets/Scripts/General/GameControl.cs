using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    //Player information
    public string username;
    public bool loggedInStatus;

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

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath);

        PlayerData data = new PlayerData();
        data.username = username;
        data.loggedInStatus = loggedInStatus;
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
            loggedInStatus = data.loggedInStatus;
            audioSetting = data.audioSetting;
            qualitySetting = data.qualitySetting;
        }
    }
}

[Serializable]
class PlayerData
{
    //Player information
    public string username;
    public bool loggedInStatus;    

    //Settings
    public bool audioSetting;
    public bool qualitySetting;

    //Fortschritt Games

    //Frotschritt Truhen

    //lastLocation
    public string lastOpenScene;
    //public Vector3 lastPositionInScene;

    //Character
    public string characterGender;
    public int characterShader;



}