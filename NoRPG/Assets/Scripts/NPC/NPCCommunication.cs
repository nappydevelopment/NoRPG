using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCommunication : MonoBehaviour {

    public FindNearestHandler trader;
    public GameObject player;

    public GameObject commObjekt;
    public Image npcImage;
    public Text npcName;
    public Text npcText;
    public Text npcFarewellText;

    public GameObject gamelistObject;
    public Text gamelistTitle;
    public Text gamelistDescription;

    public Button acceptButton;

    private List<Games> games;

    [SerializeField]
    private float distance = 3.0f;

    public void StartCommunication()
    {
        // If interactable Object is near to the player then start the interaction, else do nothing
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            commObjekt.SetActive(true);

            string username = GameControl.control.username;
            string interactableObjectName = trader.closest.name;

            //games = GetGameList.GetGames(interactableObjectName);

            npcName.text = NPCDialogue.GetNpcName(interactableObjectName);
            npcText.text = NPCDialogue.GetNpcText(interactableObjectName);
            string npcType = NPCDialogue.GetNpcType(interactableObjectName);

            acceptButton.onClick.AddListener(delegate () { if (npcType == "Trader") { OpenGameList(interactableObjectName); } else { CancelCommunication(); }});
        }
    }

    public void OpenGameList(string interactableObjectName)
    {
        commObjekt.SetActive(false);
        gamelistObject.SetActive(true);

        gamelistTitle.text = NPCDialogue.GetGamelistTitle(interactableObjectName);
        gamelistDescription.text = NPCDialogue.GetGamelistDescription(interactableObjectName);

    }

    public void CancelCommunication()
    {
        commObjekt.SetActive(false);
        gamelistObject.SetActive(false);
        npcText.gameObject.SetActive(true);
        npcFarewellText.gameObject.SetActive(false);
    }

    public void CloseGameList()
    {
        gamelistObject.SetActive(false);

        //a message like "Thank you for visiting the shop!"
        npcText.gameObject.SetActive(false);
        npcFarewellText.gameObject.SetActive(true);

        commObjekt.SetActive(true);
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) > distance)
        {
            CancelCommunication();
        }
    }
}
