using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    private List<Games> games;
    private bool nextPageFlag;
    public ScriptedStartAnimation ssa;
    private string interactableObjectName;

    [SerializeField]
    private float distance = 3.0f;

    public void StartCommunication()
    {
        // If interactable Object is near to the player then start the interaction, else do nothing
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            interactableObjectName = trader.closest.name;
            string npcType = dialogue.GetNpcType(interactableObjectName);

            //disable other UI Buttons
            openMapButton.interactable = false;
            openMenuButton.interactable = false;

            //set speech field active
            textBox.SetActive(true);

            //get content for communication
            npcName.text = dialogue.GetNpcName(interactableObjectName);
            npcText.text = dialogue.GetNpcText(interactableObjectName);

            if (npcType == "Trader")
            {
                acceptButton.onClick.AddListener(delegate () { OpenGameList(interactableObjectName); });
                cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
            }
            else if (npcType == "ScriptedNPC")
            {
                if (interactableObjectName == "Buergermeister")
                {
                    Debug.Log("Show attacker");
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
            else
            {
                acceptButton.onClick.AddListener(delegate () { CancelCommunication(); });
                cancelButton.onClick.AddListener(delegate () { CancelCommunication(); });
            }
        }
    }

    private void OpenGameList(string interactableObjectName)
    {
        textBox.SetActive(false);
        gamelistObject.SetActive(true);

        FillPanelWithGames();

        gamelistTitle.text = dialogue.GetGamelistTitle(interactableObjectName);
        gamelistDescription.text = dialogue.GetGamelistDescription(interactableObjectName);
    }

    private void FillPanelWithGames()
    {
        Games newGame1 = new Games("1_AO_:Nsdhasiud","Nappy The Ingenious", "http://www.google.de");
        gameList.Add(newGame1);

        scrollList.AddButtons(gameList);
    }

    private void CloseGameList()
    {
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

    private List<Games> getGameList(string interactableObjectName)
    {
        //interactableObjectName //1_Math_AO


        return null;
    }
}
