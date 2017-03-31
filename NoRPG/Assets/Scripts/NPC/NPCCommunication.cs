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
    public Button cancelButton;

    public Button openMenuButton;
    public Button openMapButton;
    
    public GameObject descriptionPanel;
    public GameObject gamelistPanel;
    private List<Games> games;

    NPCDialogue dialogue = new NPCDialogue();

    [SerializeField]
    private float distance = 3.0f;

    public void StartCommunication()
    {
        // If interactable Object is near to the player then start the interaction, else do nothing
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            string interactableObjectName = trader.closest.name;
            string npcType = dialogue.GetNpcType(interactableObjectName);

            //disable other UI Buttons
            openMapButton.interactable = false;
            openMenuButton.interactable = false;

            //set speech field active
            commObjekt.SetActive(true);

            //get content for communication
            npcName.text = dialogue.GetNpcName(interactableObjectName);
            npcText.text = dialogue.GetNpcText(interactableObjectName);
            
            if (npcType == "Trader")
            {
                acceptButton.onClick.AddListener(delegate () { OpenGameList(interactableObjectName); });
                cancelButton.onClick.AddListener(delegate () { NextTextPage(); });
            } else
            {
                acceptButton.onClick.AddListener(delegate () { NextTextPage(); });
                cancelButton.onClick.AddListener(delegate () { NextTextPage(); });
            }
        }
    }

    private void OpenGameList(string interactableObjectName)
    {
        commObjekt.SetActive(false);
        gamelistObject.SetActive(true);

        FillPanelWithGames();

        gamelistTitle.text = dialogue.GetGamelistTitle(interactableObjectName);
        gamelistDescription.text = dialogue.GetGamelistDescription(interactableObjectName);

    }

    private void NextTextPage()
    {
        // if npcText1 exists, overwrite the text with the new text
        // npcText.text = NPCDialogue.GetNpcText2(interactableObjectName);
        // else

        //array of pages

        CancelCommunication();
    }

    private void FillPanelWithGames()
    {
        int i = 5; // get i value from GetGameList

        Button[] buttons = new Button[i];

        for (int j = 0; j < i; j++)
        {
            //buttons[j].GetComponentInChildren<Text> = 
            //attach buttons to panel
        }
    }

    private void CloseGameList()
    {
        gamelistObject.SetActive(false);
        descriptionPanel.SetActive(false);
        gamelistPanel.SetActive(true);

        //a message like "Thank you for visiting the shop!"
        npcText.gameObject.SetActive(false);
        npcFarewellText.gameObject.SetActive(true);

        commObjekt.SetActive(true);

        acceptButton.onClick.AddListener(delegate () { CancelCommunication(); });
        cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
    }

    public void CancelCommunication()
    {
        npcText.gameObject.SetActive(true);
        npcFarewellText.gameObject.SetActive(false);

        commObjekt.SetActive(false);
        gamelistObject.SetActive(false);

        openMapButton.interactable = true;
        openMenuButton.interactable = true;

        acceptButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) > distance)
        {
            CancelCommunication();
        }
    }
}
