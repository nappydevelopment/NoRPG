﻿#pragma strict

function OnTriggerEnter(Col : Collider)
    {
        if (Col.tag == "Player")
        {
            Application.LoadLevel("Scenes/Startwelt");
        }
    }