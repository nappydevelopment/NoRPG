﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedStartAnimation : MonoBehaviour {


    [SerializeField]
    private GameObject hud;
    [SerializeField]
    private GameObject animie;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject nfc;  
    [SerializeField]
    private GameObject playerdot;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Camera scriptCamera;
    [SerializeField]
    private Animator animatorPlayer;
    [SerializeField]
    private Animator animatorNfc;
    [SerializeField]
    private Animator animatorAnimie;
    [SerializeField]
    private NPCCommunication npcc;
    private bool played = false;
    private Vector3 cameraMovement;
    private Quaternion rotation;

    void Start()
    {
        playerCamera.enabled = true;
        scriptCamera.enabled = false;
        hud.SetActive(false);
        playerdot.SetActive(false);
        player.GetComponent<CharacterControll>().enabled = false;
        animatorPlayer = player.GetComponent<Animator>();
        animatorNfc = nfc.GetComponent<Animator>();
        animatorAnimie = animie.GetComponent<Animator>();


    }

    private void startCommunication() {
        Debug.Log("Start Communication");
    }


    void Update () {
        if (!played) { 
        if (nfc.transform.position.z > 275.0f) {
            animatorNfc.SetFloat("speed", 1f);
            animatorNfc.SetFloat("direction", 0.0f);
        }
        else  {
            animatorNfc.SetFloat("speed", 0.0f);
            animatorNfc.SetFloat("direction", 0.0f);
        }

        

            if (!played && animatorNfc.GetFloat("speed") == 0.0f)
            {
                Debug.Log("Start");
                player.transform.LookAt(nfc.transform);
                nfc.transform.LookAt(player.transform);
                scriptCamera.transform.position = playerCamera.transform.position;
                hud.SetActive(true);
                npcc.StartCommunication();
                player.GetComponent<CharacterControll>().enabled = true;
                played = true;
            }
        }
    }

    internal void ShowUFO()
    {
        animatorAnimie.SetBool("Fly Idle", true);

        scriptCamera.enabled = true;
        playerCamera.enabled = false;

        scriptCamera.transform.LookAt(animie.transform); //smother?
        nfc.name = "Buergermeister_1";
        npcc.StartCommunication();

        //DeleteColor
    }

    internal void DeleteColor()
    {
        GetComponent<FadeOut>().BeginFade(1);
        playerCamera.enabled = true;
        scriptCamera.enabled = false;
        player.transform.position = new Vector3(317.36f, 6.37f, 278.28f);
        GetComponent<FadeOut>().setFade(false);
        GetComponent<FadeOut>().BeginFade(-1);

        Debug.Log("Test");
    }
}
