using UnityEngine;
using UnityEngine.UI;

public class LoggedInScreenFunctions : MonoBehaviour {

    public Button setQualityOn;
    public Button setQualityOff;
    public Button setAudioOn;
    public Button setAudioOff;
    public Button logOutBtn;

    public void SetQualityOn()
    {
        GameControl.control.qualitySetting = true;
        GameControl.control.Save();
        Debug.Log("QualitySetting changed to true, saving successful!");
    }

    public void SetQualityOff()
    {
        GameControl.control.qualitySetting = false;
        GameControl.control.Save();
        Debug.Log("QualitySetting changed to false, saving successful!");
    }

    public void SetAudioOn()
    {
        GameControl.control.audioSetting = true;
        GameControl.control.Save();
        Debug.Log("AudioSetting changed to true, saving successful!");
    }

    public void SetAudioOff()
    {
        GameControl.control.audioSetting = false;
        GameControl.control.Save();
        Debug.Log("AudioSetting changed to false, saving successful!");
    }

    public void SetTextOfBtn()
    {
        string message = "Not " + GameControl.control.username + "? Log out!";

        logOutBtn.GetComponentInChildren<Text>().text = message;
    }

    public void LogOutCurrentUser()
    {
        GameControl.control.username = "";
        GameControl.control.Save();
        Debug.Log("Username cleared!");
    }

    public void getSettings()
    {
        GameControl.control.Load();

        if (GameControl.control.qualitySetting == true)
        {
            setQualityOn.gameObject.SetActive(false);
            setQualityOff.gameObject.SetActive(true);
        }
        else if (GameControl.control.qualitySetting == false)
        {
            setQualityOn.gameObject.SetActive(true);
            setQualityOff.gameObject.SetActive(false);
        }

        SetTextOfBtn();
    }

    void Awake()
    {
        getSettings();
    }
}