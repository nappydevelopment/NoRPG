﻿#pragma strict

function OnTriggerEnter(Col : Collider)
    {
        if (Col.tag == "Player")
        {
            DontDestroyOnLoad(Col.gameObject);
            Application.LoadLevel("Scenes/Snow_World"); 
        }
    }
