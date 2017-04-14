using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour {

    //Settings
    public Switch qualityToggle;
    public Image goodQuality;
    public Image badQuality;
    public Switch musicToggle;
    public Image musicOn;
    public Image musicOff;
    public AudioSource audioSource;

    //Gamelist
    public GameScrollList scrollList = new GameScrollList();

    //Achievements
    public RawImage class1_gem1_not;
    public RawImage class1_gem1_found;
    public RawImage class1_gem2_not;
    public RawImage class1_gem2_found;
    public RawImage class1_gem3_not;
    public RawImage class1_gem3_found;
    public RawImage class1_gem4_not;
    public RawImage class1_gem4_found;
    public RawImage class1_gem5_not;
    public RawImage class1_gem5_found;
    public RawImage class1_gem6_not;
    public RawImage class1_gem6_found;
    public RawImage class1_gem7_not;
    public RawImage class1_gem7_found;
    public RawImage class1_gem8_not;
    public RawImage class1_gem8_found;
    public RawImage class2_gem1_not;
    public RawImage class2_gem1_found;
    public RawImage class2_gem2_not;
    public RawImage class2_gem2_found;
    public RawImage class2_gem3_not;
    public RawImage class2_gem3_found;
    public RawImage class2_gem4_not;
    public RawImage class2_gem4_found;
    public RawImage class2_gem5_not;
    public RawImage class2_gem5_found;
    public RawImage class2_gem6_not;
    public RawImage class2_gem6_found;
    public RawImage class2_gem7_not;
    public RawImage class2_gem7_found;
    public RawImage class2_gem8_not;
    public RawImage class2_gem8_found;
    public RawImage class3_gem1_not;
    public RawImage class3_gem1_found;
    public RawImage class3_gem2_not;
    public RawImage class3_gem2_found;
    public RawImage class3_gem3_not;
    public RawImage class3_gem3_found;
    public RawImage class3_gem4_not;
    public RawImage class3_gem4_found;
    public RawImage class3_gem5_not;
    public RawImage class3_gem5_found;
    public RawImage class3_gem6_not;
    public RawImage class3_gem6_found;
    public RawImage class3_gem7_not;
    public RawImage class3_gem7_found;
    public RawImage class3_gem8_not;
    public RawImage class3_gem8_found;
    public RawImage class4_gem1_not;
    public RawImage class4_gem1_found;
    public RawImage class4_gem2_not;
    public RawImage class4_gem2_found;
    public RawImage class4_gem3_not;
    public RawImage class4_gem3_found;
    public RawImage class4_gem4_not;
    public RawImage class4_gem4_found;
    public RawImage class4_gem5_not;
    public RawImage class4_gem5_found;
    public RawImage class4_gem6_not;
    public RawImage class4_gem6_found;
    public RawImage class4_gem7_not;
    public RawImage class4_gem7_found;
    public RawImage class4_gem8_not;
    public RawImage class4_gem8_found;
    public RawImage class5_gem1_not;
    public RawImage class5_gem1_found;
    public RawImage class5_gem2_not;
    public RawImage class5_gem2_found;
    public RawImage class5_gem3_not;
    public RawImage class5_gem3_found;
    public RawImage class5_gem4_not;
    public RawImage class5_gem4_found;
    public RawImage class5_gem5_not;
    public RawImage class5_gem5_found;
    public RawImage class5_gem6_not;
    public RawImage class5_gem6_found;
    public RawImage class5_gem7_not;
    public RawImage class5_gem7_found;
    public RawImage class5_gem8_not;
    public RawImage class5_gem8_found;

    public RawImage rainbow0;
    public RawImage rainbow1;
    public RawImage rainbow2;
    public RawImage rainbow3;
    public RawImage rainbow4;
    public RawImage rainbow5;

    public GameObject secondClassPanel;
    public GameObject thirdClassPanel;
    public GameObject fourthClassPanel;
    public GameObject fifthClassPanel;

    void Start () {
        GameControl.control.LoadFromFile();

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

    public void LoadAchievements()
    {
        if (GameControl.control.chest_1_desert_open == true && GameControl.control.chest_1_forest_open == true && GameControl.control.chest_1_lava_open == true && GameControl.control.chest_1_snow_open == true && GameControl.control.chest_1_tropen_open == true)
        {
            rainbow0.gameObject.SetActive(false);
            rainbow1.gameObject.SetActive(true);
            rainbow2.gameObject.SetActive(false);
            rainbow3.gameObject.SetActive(false);
            rainbow4.gameObject.SetActive(false);
            rainbow5.gameObject.SetActive(false);

            secondClassPanel.SetActive(true);
        }
        if (GameControl.control.chest_2_desert_open == true && GameControl.control.chest_2_forest_open == true && GameControl.control.chest_2_lava_open == true && GameControl.control.chest_2_snow_open == true && GameControl.control.chest_2_tropen_open == true)
        {
            rainbow0.gameObject.SetActive(false);
            rainbow1.gameObject.SetActive(false);
            rainbow2.gameObject.SetActive(true);
            rainbow3.gameObject.SetActive(false);
            rainbow4.gameObject.SetActive(false);
            rainbow5.gameObject.SetActive(false);

            thirdClassPanel.SetActive(true);
        }
        if (GameControl.control.chest_3_desert_open == true && GameControl.control.chest_3_forest_open == true && GameControl.control.chest_3_lava_open == true && GameControl.control.chest_3_snow_open == true && GameControl.control.chest_3_tropen_open == true)
        {
            rainbow0.gameObject.SetActive(false);
            rainbow1.gameObject.SetActive(false);
            rainbow2.gameObject.SetActive(false);
            rainbow3.gameObject.SetActive(true);
            rainbow4.gameObject.SetActive(false);
            rainbow5.gameObject.SetActive(false);

            fourthClassPanel.SetActive(true);
        }
        if (GameControl.control.chest_4_desert_open == true && GameControl.control.chest_4_forest_open == true && GameControl.control.chest_4_lava_open == true && GameControl.control.chest_4_snow_open == true && GameControl.control.chest_4_tropen_open == true)
        {
            rainbow0.gameObject.SetActive(false);
            rainbow1.gameObject.SetActive(false);
            rainbow2.gameObject.SetActive(false);
            rainbow3.gameObject.SetActive(false);
            rainbow4.gameObject.SetActive(true);
            rainbow5.gameObject.SetActive(false);

            fifthClassPanel.SetActive(true);
        }
        if (GameControl.control.chest_5_desert_open == true && GameControl.control.chest_5_forest_open == true && GameControl.control.chest_5_lava_open == true && GameControl.control.chest_5_snow_open == true && GameControl.control.chest_5_tropen_open == true)
        {
            rainbow0.gameObject.SetActive(false);
            rainbow1.gameObject.SetActive(false);
            rainbow2.gameObject.SetActive(false);
            rainbow3.gameObject.SetActive(false);
            rainbow4.gameObject.SetActive(false);
            rainbow5.gameObject.SetActive(true);
        }

        GameControl.control.LoadFromFile();
        //First class gems
        if (GameControl.control.chest_1_forest_open == true) { class1_gem1_found.gameObject.SetActive(true); class1_gem1_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_2_forest_open == true) { class1_gem2_found.gameObject.SetActive(true); class1_gem2_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_3_forest_open == true) { class1_gem3_found.gameObject.SetActive(true); class1_gem3_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_4_forest_open == true) { class1_gem4_found.gameObject.SetActive(true); class1_gem4_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_5_forest_open == true) { class1_gem5_found.gameObject.SetActive(true); class1_gem5_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_6_forest_open == true) { class1_gem6_found.gameObject.SetActive(true); class1_gem6_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_7_forest_open == true) { class1_gem7_found.gameObject.SetActive(true); class1_gem7_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_8_forest_open == true) { class1_gem8_found.gameObject.SetActive(true); class1_gem8_not.gameObject.SetActive(false);}
        //Second class gems
        if (GameControl.control.chest_1_tropen_open == true) { class2_gem1_found.gameObject.SetActive(true); class2_gem1_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_2_tropen_open == true) { class2_gem2_found.gameObject.SetActive(true); class2_gem2_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_3_tropen_open == true) { class2_gem3_found.gameObject.SetActive(true); class2_gem3_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_4_tropen_open == true) { class2_gem4_found.gameObject.SetActive(true); class2_gem4_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_5_tropen_open == true) { class2_gem5_found.gameObject.SetActive(true); class2_gem5_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_6_tropen_open == true) { class2_gem6_found.gameObject.SetActive(true); class2_gem6_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_7_tropen_open == true) { class2_gem7_found.gameObject.SetActive(true); class2_gem7_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_8_tropen_open == true) { class2_gem8_found.gameObject.SetActive(true); class2_gem8_not.gameObject.SetActive(false);}
        //Third class gems
        if (GameControl.control.chest_1_desert_open == true) { class3_gem1_found.gameObject.SetActive(true); class3_gem1_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_2_desert_open == true) { class3_gem2_found.gameObject.SetActive(true); class3_gem2_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_3_desert_open == true) { class3_gem3_found.gameObject.SetActive(true); class3_gem3_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_4_desert_open == true) { class3_gem4_found.gameObject.SetActive(true); class3_gem4_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_5_desert_open == true) { class3_gem5_found.gameObject.SetActive(true); class3_gem5_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_6_desert_open == true) { class3_gem6_found.gameObject.SetActive(true); class3_gem6_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_7_desert_open == true) { class3_gem7_found.gameObject.SetActive(true); class3_gem7_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_8_desert_open == true) { class3_gem8_found.gameObject.SetActive(true); class3_gem8_not.gameObject.SetActive(false);}
        //Fourth class gems
        if (GameControl.control.chest_1_snow_open == true) { class4_gem1_found.gameObject.SetActive(true); class4_gem1_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_2_snow_open == true) { class4_gem2_found.gameObject.SetActive(true); class4_gem2_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_3_snow_open == true) { class4_gem3_found.gameObject.SetActive(true); class4_gem3_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_4_snow_open == true) { class4_gem4_found.gameObject.SetActive(true); class4_gem4_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_5_snow_open == true) { class4_gem5_found.gameObject.SetActive(true); class4_gem5_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_6_snow_open == true) { class4_gem6_found.gameObject.SetActive(true); class4_gem6_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_7_snow_open == true) { class4_gem7_found.gameObject.SetActive(true); class4_gem7_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_8_snow_open == true) { class4_gem8_found.gameObject.SetActive(true); class4_gem8_not.gameObject.SetActive(false);}
        //Fifth class gems
        if (GameControl.control.chest_1_lava_open == true) { class5_gem1_found.gameObject.SetActive(true); class5_gem1_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_2_lava_open == true) { class5_gem2_found.gameObject.SetActive(true); class5_gem2_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_3_lava_open == true) { class5_gem3_found.gameObject.SetActive(true); class5_gem3_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_4_lava_open == true) { class5_gem4_found.gameObject.SetActive(true); class5_gem4_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_5_lava_open == true) { class5_gem5_found.gameObject.SetActive(true); class5_gem5_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_6_lava_open == true) { class5_gem6_found.gameObject.SetActive(true); class5_gem6_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_7_lava_open == true) { class5_gem7_found.gameObject.SetActive(true); class5_gem7_not.gameObject.SetActive(false);}
        if (GameControl.control.chest_8_lava_open == true) { class5_gem8_found.gameObject.SetActive(true); class5_gem8_not.gameObject.SetActive(false);}
    }
}
