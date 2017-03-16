﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRegisterScene : MonoBehaviour {

    public AudioSource startAudio;
    public GameObject loggedOut;

	public void RegisterBtn()
    {
        DontDestroyOnLoad(startAudio);

        SceneManager.LoadScene("Scenes/Register", LoadSceneMode.Single);
    }
}
