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
    public Button acceptButton;

    [SerializeField]
    private float distance = 3.0f;

    public GameObject gamelistObject;

    public void StartCommunication()
    {
        // If interactable Object is near to the player then start the interaction, else do nothing
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            commObjekt.SetActive(true);

            string username = GameControl.control.username;
            string interactableObjectName = trader.closest.name;
            
            switch (interactableObjectName)
            {
                case "Nappy":
                    npcName.text = "Nappy";
                    npcText.text = "Hello " + username + "! My name is Nappy. I am a guardian of NoRPG! Enjoy the game.";
                    break;
                case "Ali":
                    npcName.text = interactableObjectName;
                    npcText.text = "Hello this is a new Text";
                    break;
                case "Tom":
                    npcName.text = interactableObjectName;
                    npcText.text = "Hello this is a new Text TExt Text";
                    break;
                case "0_Math_AO":
                    npcName.text = "Hans";
                    npcText.text = "I have games for the first class math object analysis!";

                    acceptButton.onClick.AddListener(delegate () { OpenGameList(); });
                    break;
            }
        }
    }

    public void CancelCommunication()
    {
        //if there is no more text then 

        commObjekt.SetActive(false);
    }

    public void OpenGameList()
    {
        gamelistObject.SetActive(true);
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) > distance)
        {
            CancelCommunication();
        }
    }
}
