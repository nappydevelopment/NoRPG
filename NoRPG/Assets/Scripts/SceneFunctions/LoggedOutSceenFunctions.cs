using UnityEngine;
using UnityEngine.UI;

public class LoggedOutSceenFunctions : MonoBehaviour {

    public Button setQualityOn;
    public Button setQualityOff;
    public Button setAudioOn;
    public Button setAudioOff;
    public AudioSource audioSource;

    public Button logInButton;
    public InputField usernameInput;

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
        audioSource.Play();
    }

    public void SetAudioOff()
    {
        GameControl.control.audioSetting = false;
        GameControl.control.Save();
        Debug.Log("AudioSetting changed to false, saving successful!");
        audioSource.Stop();
    }

    public void SetUsername()
    {
        GameControl.control.username = usernameInput.text;
        GameControl.control.Save();
        Debug.Log("Username saved!");
    }

    public void getSettings()
    {
        GameControl.control.LoadFromFile();

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

        if (GameControl.control.audioSetting == true)
        {
            setAudioOn.gameObject.SetActive(false);
            setAudioOff.gameObject.SetActive(true);
            audioSource.Play();
        }
        else if (GameControl.control.audioSetting == false)
        {
            setAudioOn.gameObject.SetActive(true);
            setAudioOff.gameObject.SetActive(false);
            audioSource.Stop();
        }
    }
    
    void Awake()
    {
        getSettings();
    }
}
