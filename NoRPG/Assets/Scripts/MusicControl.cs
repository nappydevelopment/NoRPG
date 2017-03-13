using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

    public static MusicControl control;

    public AudioSource audioSource;

    void Awake()
    {
        //check is there a MusicControl Object!
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

        SelectMusic();
    }

    void SelectMusic()
    {
        string currentSceneName = PortalControl.control.currentScene;


    }
}
