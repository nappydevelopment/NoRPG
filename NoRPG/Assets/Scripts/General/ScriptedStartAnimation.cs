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
    private GameObject npc;  
    [SerializeField]
    private GameObject playerdot;
    [SerializeField]
    private GameObject miniMap;
    [SerializeField]
    private GameObject miniMapPanel;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Camera scriptCamera;
    [SerializeField]
    private Animator animatorPlayer;
    [SerializeField]
    private Animator animatorNpc;
    [SerializeField]
    private Animator animatorAnimie;
    [SerializeField]
    private GameObject dragon;
    [SerializeField]
    private NPCCommunication npcc;
    [SerializeField]
    private BWEffect effect;
    private Vector3 cameraMovement;
    private Quaternion rotation;
    private bool showCityColoured = false;
    [SerializeField]
    private GameObject joystick;

    void Start()
    {
        //GameControl.control.Load();
        playerCamera.enabled = true;
        scriptCamera.enabled = false;
        if (!GameControl.control.playedIntro)
        {
            hud.SetActive(false);
            playerdot.SetActive(false);
            miniMap.SetActive(false);
            miniMapPanel.SetActive(false);
            player.GetComponent<CharacterControll>().enabled = false;
        }
        else
        {
            playerCamera.transform.position = player.transform.position + new Vector3(-3, 3, -3);
            dragon.SetActive(false);
        }
        animatorPlayer = player.GetComponent<Animator>();
        animatorNpc = npc.GetComponent<Animator>();
        animatorAnimie = animie.GetComponent<Animator>();
    }

    private void startCommunication() {
        Debug.Log("Start Communication");
    }

    void Update () {
        if (!GameControl.control.playedIntro) { 
        if (npc.transform.position.z > 275.0f) {
            animatorNpc.SetFloat("speed", 1f);
            animatorNpc.SetFloat("direction", 0.0f);
        }
        else  {
            animatorNpc.SetFloat("speed", 0.0f);
            animatorNpc.SetFloat("direction", 0.0f);
        }
            if (!GameControl.control.playedIntro && animatorNpc.GetFloat("speed") == 0.0f)
            {
                //Debug.Log("ScriptedStartAnimation Update");
                player.transform.LookAt(npc.transform);
                npc.transform.LookAt(player.transform);
                scriptCamera.transform.position = playerCamera.transform.position;
                hud.SetActive(true);
                joystick.SetActive(false);
                npcc.StartCommunication();
                player.GetComponent<CharacterControll>().enabled = true;
                GameControl.control.playedIntro = true;
                GameControl.control.Save();
            }
        }
    }

    internal void ShowAttacker()
    {
        animatorAnimie.SetBool("Fly Idle", true);

        scriptCamera.enabled = true;
        playerCamera.enabled = false;

        scriptCamera.transform.LookAt(animie.transform); //smother?
        npc.name = "Buergermeister_1";
        npcc.StartCommunication();

        scriptCamera.GetComponent<BWEffect>().Intensity = 1.0f;
        playerCamera.GetComponent<BWEffect>().Intensity = 1.0f;
    }

    internal void ShowMajor()
    {
        //player normal view, show again major
        //he ask for help

        if (showCityColoured == false)
        {
            //this buergermeister_2 will stay until end
            npc.name = "Buergermeister_2";
        }
        else
        {
            npc.name = "Buergermeister_3";
        }

        npcc.StartCommunication();
    }

    internal void DeleteColor()
    {
        GetComponent<FadeOut>().BeginFade(1);
        playerCamera.enabled = true;
        scriptCamera.enabled = false;
        //player.transform.position = new Vector3(317.36f, 6.37f, 278.28f);
        GetComponent<FadeOut>().setFade(false);
        GetComponent<FadeOut>().BeginFade(-1);
        //Debug.Log("Delete Color Log");
        joystick.SetActive(true);
        playerdot.SetActive(true);
        miniMap.SetActive(true);
        miniMapPanel.SetActive(true);
        npcc.CancelCommunication();
    }

    internal void ShowColouredCity()
    {
        //after finishing the game the camera will go up show the city full with color
        //Major will say: Thanks for saving our city! Look all colors are back.

        //then back to normal player view 

        // --> Just once with city look, after this he will just say the same sentence
        //set bool showCityColoured = true;
        showCityColoured = true;
    }
}
