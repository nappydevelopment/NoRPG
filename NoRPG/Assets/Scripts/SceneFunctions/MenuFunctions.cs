using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour {

    public Switch qualityToggle;
    public Image goodQuality;
    public Image badQuality;

    public Switch musicToggle;
    public Image musicOn;
    public Image musicOff;
    public AudioSource audioSource;

    public GameScrollList scrollList = new GameScrollList();

    void Start () {
        GameControl.control.Load();

        if (GameControl.control.qualitySetting == true)
        {
            goodQuality.gameObject.SetActive(true);
            badQuality.gameObject.SetActive(false);
            qualityToggle.isOn = true;
        }
        else if (GameControl.control.qualitySetting == false)
        {
            goodQuality.gameObject.SetActive(false);
            badQuality.gameObject.SetActive(true);
            qualityToggle.isOn = false;
        }

        if (GameControl.control.audioSetting == true)
        {
            musicOn.gameObject.SetActive(true);
            musicOff.gameObject.SetActive(false);
            musicToggle.isOn = true;
            audioSource.Play();
        }
        else if (GameControl.control.audioSetting == false)
        {
            musicOn.gameObject.SetActive(false);
            musicOff.gameObject.SetActive(true);
            musicToggle.isOn = false;
            audioSource.Stop();
        }
    }

    public void ChangeQualitySettings()
    {
        bool toggleStatus = qualityToggle.isOn;

        if (toggleStatus == false)
        {
            goodQuality.gameObject.SetActive(false);
            badQuality.gameObject.SetActive(true);

            GameControl.control.qualitySetting = false;
            GameControl.control.Save();
            Debug.Log("QualitySetting changed to false, saving successful!");
        }
        else
        {
            goodQuality.gameObject.SetActive(true);
            badQuality.gameObject.SetActive(false);

            GameControl.control.qualitySetting = true;
            GameControl.control.Save();
            Debug.Log("QualitySetting changed to true, saving successful!");
        }
    }

    public void ChangeMusicSetting()
    {
        bool toggleStatus = musicToggle.isOn;

        if (toggleStatus == false)
        {
            musicOn.gameObject.SetActive(false);
            musicOff.gameObject.SetActive(true);

            GameControl.control.audioSetting = false;
            GameControl.control.Save();
            Debug.Log("audioSetting changed to false, saving successful!");
            audioSource.Stop();
        }
        else
        {
            musicOn.gameObject.SetActive(true);
            musicOff.gameObject.SetActive(false);

            GameControl.control.audioSetting = true;
            GameControl.control.Save();
            Debug.Log("audioSetting changed to true, saving successful!");
            audioSource.Play();
        }
    }

    public void LoadDownloadedGames()
    {
        List<Games> downloadedGames = GameControl.control.downloadedGames;

        scrollList.AddButtons(downloadedGames);
    }
}
