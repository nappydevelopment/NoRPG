using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCommunication : MonoBehaviour {

    public GameObject commObjekt;
    public FindNearestHandler trader;
    public GameObject player;
    public Image npcImage; //mehrere Bilder von allen 32 Personen - Gegner (Drache, ...) 5, Truhe + Nappy --> 39 Bilder
    public Text npcName;
    public Text npcText;

    [SerializeField]
    private float distance = 3.0f;

    public GameObject gamelistObject;

    public void StartCommunication()
    {
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            Debug.Log("Distance less then 6");
            //if(NPC is in front of the character){ start this } else { do nothing }
            commObjekt.SetActive(true);

            //choose correct image of NPC

            //choose correct Name of NPC

            //choose correct Text of NPC
            string username = GameControl.control.username;
            npcText.text = "Hello " + username + "! My name is Nappy. I am a guardian of NoRPG! Enjoy the game.";

            //if Spielehändler --> open gamelist
            //gamelistObject.SetActive(true);

            //fill gameList with Buttons ... which will open google play store
        }
        else {
            //Eventually feedback on UI
        }
    }

    public void CancelCommunication()
    {
        //if there is no more text then 

        commObjekt.SetActive(false);
    }
}
