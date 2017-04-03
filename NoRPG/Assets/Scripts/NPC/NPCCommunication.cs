﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    public Transform gamelistPanel;
    public List<Game> gameList;
    public GameScrollList scrollList = new GameScrollList();

    private List<Games> games;
    private bool nextPageFlag;
    public ScriptedStartAnimation ssa;

    NPCDialogue dialogue = new NPCDialogue();
    //GameScrollList scrollList = new GameScrollList();

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

            Char delimiter = '%';
            string npcCompleteText = dialogue.GetNpcText(interactableObjectName);
            string[] npcTextArray = npcCompleteText.Split(delimiter);
            Debug.Log("Arraylength= " + npcTextArray.Length);

            //if there is more then one page for this communication 
            if (npcTextArray.Length > 1)
            {
                Debug.Log("Is in IF, length > 1");
                //StartCoroutine(GoThroughConversation(npcTextArray));
                GoThroughConv(npcTextArray);
                Debug.Log("Verlasse gothroughconversation");
            }

            if (npcType == "Trader")
            {
                acceptButton.onClick.AddListener(delegate () { OpenGameList(interactableObjectName); });
                cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
            }
            else if( npcType == "ScriptedNPC")
            {
                if (interactableObjectName == "Buergermeister")
                {
                    Debug.Log("Show attacker");
                    acceptButton.onClick.AddListener(delegate () { ShowAttaker(); });
                    cancelButton.onClick.AddListener(delegate () { ShowAttaker(); });
                }
                else if (interactableObjectName == "Buergermeister_1")
                {
                    acceptButton.onClick.AddListener(delegate () { DeleteColor(); });
                    cancelButton.onClick.AddListener(delegate () { DeleteColor(); });
                }
            }
            else
            {
                acceptButton.onClick.AddListener(delegate () { CancelCommunication(); });
                cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
            }
        }
    }

    private IEnumerator GoThroughConversation(string[] textArray)
    {
        Debug.Log("GoThroughConversation");
        foreach (var i in textArray)
        {
            nextPageFlag = false;
            Debug.Log(i.ToString());
            npcText.text = i.ToString();
            acceptButton.onClick.AddListener(() => nextPageFlag = true);
            yield return new WaitUntil(() => nextPageFlag == true);
            //yield return null;
        }
    }

    private void GoThroughConv(string[] npcTextArray)
    {
        foreach (var i in npcTextArray)
        {
            nextPageFlag = false;
            npcText.text = i.ToString();
            acceptButton.onClick.AddListener(() => nextPageFlag = true);

        }
    }

    private void DeleteColor()
    {
        CancelCommunication();
        ssa.DeleteColor();
    }

    private void ShowAttaker()
    {
        CancelCommunication();
        ssa.ShowUFO();
    }

    private void OpenGameList(string interactableObjectName)
    {
        commObjekt.SetActive(false);
        gamelistObject.SetActive(true);

        FillPanelWithGames();

        gamelistTitle.text = dialogue.GetGamelistTitle(interactableObjectName);
        gamelistDescription.text = dialogue.GetGamelistDescription(interactableObjectName);

    }

    private void FillPanelWithGames()
    {
        Game newGame1 = new Game();
        //get GameName and Downloadlink from GetGameList()
        newGame1.gameName = "Nappy The Ingenious";
        newGame1.downloadLink = "http://www.google.de";
        gameList.Add(newGame1);

        scrollList.AddButtons(gameList);
    }

    private void CloseGameList()
    {
        gamelistObject.SetActive(false);
        descriptionPanel.SetActive(false);
        gamelistPanel.gameObject.SetActive(true);

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
