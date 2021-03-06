﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCommunication : MonoBehaviour {

    public FindNearestHandler trader;
    public GameObject player;

    public GameObject textBox;
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
    public Transform gamelistPanel;
    public List<Games> gameList = new List<Games>();

    public GameScrollList scrollList = new GameScrollList();
    NPCDialogue dialogue = new NPCDialogue();

    private bool nextPageFlag;
    public ScriptedStartAnimation ssa;
    public ChestHandle handleChest;

    [SerializeField]
    private float distance = 3.0f;

    private string json;

    void Start()
    {
        string fileName = "npcList";
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        json = textAsset.text;
    }

    public void StartCommunication()
    {
        // If interactable Object is near to the player then start the interaction, else do nothing
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            string interactableObjectName = trader.closest.name;
            string npcType = dialogue.GetNpcType(interactableObjectName, json);

            //disable other UI Buttons
            openMapButton.interactable = false;
            openMenuButton.interactable = false;

            //set speech field active
            textBox.SetActive(true);

            //get content for communication
            npcName.text = dialogue.GetNpcName(interactableObjectName, json);
            npcText.text = dialogue.GetNpcText(interactableObjectName, json);

            if (npcType == "Trader")
            {
                acceptButton.onClick.AddListener(delegate () { OpenGameList(interactableObjectName); });
                cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
            }
            else if (npcType == "ScriptedNPC")
            {
                if (interactableObjectName == "Buergermeister")
                {
                    //Debug.Log("Show attacker");
                    acceptButton.onClick.AddListener(delegate () { ssa.ShowAttacker(); });
                    cancelButton.onClick.AddListener(delegate () { ssa.ShowAttacker(); });
                }
                else if (interactableObjectName == "Buergermeister_1")
                {
                    acceptButton.onClick.AddListener(delegate () { ssa.ShowMajor(); });
                    cancelButton.onClick.AddListener(delegate () { ssa.ShowMajor(); });
                }
                else if (interactableObjectName == "Buergermeister_2")
                {
                    acceptButton.onClick.AddListener(delegate () { ssa.DeleteColor(); });
                    cancelButton.onClick.AddListener(delegate () { ssa.DeleteColor(); });
                }
            }
            else if (npcType == "Chest")
            {
                Debug.Log("The NPC is a chest, do not try to talk with him");
                acceptButton.onClick.AddListener(delegate () { handleChest.OpenChest(interactableObjectName); });
                cancelButton.onClick.AddListener(delegate () { handleChest.OpenChest(interactableObjectName); });
            }
            else
            {
                acceptButton.onClick.AddListener(delegate () { CancelCommunication(); });
                cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
            }
        }
    }

    private void OpenGameList(string interactableObjectName)
    {
        gameList = GetGameList.GetGames(interactableObjectName);

        if(gameList.Count == 0)
        {
            npcText.text = "Sorry you are not allowed to play this games. Come back later.";
            return;
        }

        textBox.SetActive(false);
        gamelistObject.SetActive(true);

        FillPanelWithGames(interactableObjectName);

        scrollList.AddButtons(gameList);

        gamelistTitle.text = dialogue.GetGamelistTitle(interactableObjectName, json);
        gamelistDescription.text = dialogue.GetGamelistDescription(interactableObjectName, json);
    }

    private void FillPanelWithGames(string interactableObjectName)
    {

    }

    private void CloseGameList()
    {
        scrollList.RemoveButtons();

        gamelistObject.SetActive(false);
        descriptionPanel.SetActive(false);
        gamelistPanel.gameObject.SetActive(true);

        npcText.gameObject.SetActive(false);
        npcFarewellText.gameObject.SetActive(true);

        textBox.SetActive(true);

        acceptButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(delegate () { CancelCommunication(); });
        cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
    }

    public void CancelCommunication()
    {
        npcText.gameObject.SetActive(true);
        npcFarewellText.gameObject.SetActive(false);

        textBox.SetActive(false);
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
