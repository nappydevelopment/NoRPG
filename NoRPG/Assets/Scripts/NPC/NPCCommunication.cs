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
    public Button acceptButton;

    [SerializeField]
    private float distance = 3.0f;

    public GameObject gamelistObject;
    public Text gamelistTitleBar;

    public void StartCommunication()
    {
        // If interactable Object is near to the player then start the interaction, else do nothing
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) < distance)
        {
            commObjekt.SetActive(true);

            string username = GameControl.control.username;
            string interactableObjectName = trader.closest.name;
            string gamelistTitle = "";
            
            switch (interactableObjectName)
            {
                case "Nappy":
                    npcName.text = "Nappy";
                    npcText.text = "Hello " + username + "! My name is Nappy. I am a guardian of NoRPG! Enjoy the game.";
                    break;
                case "Ali":
                    npcName.text = interactableObjectName;
                    npcText.text = "Hey my name is Ali.";
                    break;
                case "Tom":
                    npcName.text = interactableObjectName;
                    npcText.text = "Hey my name is Tom.";
                    break;

                //Händler der ersten Klasse Mathe
                case "0_Math_OA":
                    npcName.text = "Sevakor";
                    npcText.text = "";
                    gamelistTitle = "First class, Math, Operations & Algebraic Thinking";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_Math_AO", gamelistTitle); });
                    break;
                case "0_Math_NBT":
                    npcName.text = "Abbey ";
                    npcText.text = "";
                    gamelistTitle = "First class, Math, Number and Operations in Base Ten";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_Math_NBT", gamelistTitle); });
                    break;
                case "0_Math_MD":
                    npcName.text = "Sylas";
                    npcText.text = "";
                    gamelistTitle = "First class, Math, Measurement and Data";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_Math_MD", gamelistTitle); });
                    break;
                case "0_Math_G":
                    npcName.text = "Nichols";
                    npcText.text = "";
                    gamelistTitle = "First class, Math, Geometry";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_Math_G", gamelistTitle); });
                    break;

                //Händler der zweiten Klasse Mathe
                case "1_Math_OA":
                    npcName.text = "Rudolph";
                    npcText.text = "";
                    gamelistTitle = "Second class, Math, Operations & Algebraic Thinking";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_Math_OA", gamelistTitle); });
                    break;
                case "1_Math_NBT":
                    npcName.text = "Donny";
                    npcText.text = "";
                    gamelistTitle = "Second class, Math, Number and Operations in Base Ten";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_Math_NBT", gamelistTitle); });
                    break;
                case "1_Math_MD":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, Math, Measurement and Data";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_Math_MD", gamelistTitle); });
                    break;
                case "1_Math_G":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, Math, Geometry";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_Math_G", gamelistTitle); });
                    break;

                //Händler der dritten Klasse Mathe
                case "2_Math_OA":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, Math, Operations & Algebraic Thinking";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_Math_OA", gamelistTitle); });
                    break;
                case "2_Math_NBT":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, Math, Number and Operations in Base Ten";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_Math_NBT", gamelistTitle); });
                    break;
                case "2_Math_NF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, Math, Number and Operations Fractions";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_Math_NF", gamelistTitle); });
                    break;
                case "2_Math_MD":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, Math, Measurement and Data";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_MD", gamelistTitle); });
                    break;
                case "2_Math_G":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, Math, Geometry";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_G", gamelistTitle); });
                    break;

                //Händler der vierten Klasse Mathe
                case "3_Math_OA":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, Math, Operations & Algebraic Thinking";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_OA", gamelistTitle); });
                    break;
                case "3_Math_NBT":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, Math, Number and Operations in Base Ten";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_NBT", gamelistTitle); });
                    break;
                case "3_Math_NF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, Math, Number and Operations Fractions";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_NF", gamelistTitle); });
                    break;
                case "3_Math_MD":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, Math, Measurement and Data";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_MD", gamelistTitle); });
                    break;
                case "3_Math_G":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, Math, Geometry";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_Math_G", gamelistTitle); });
                    break;

                //Händler der fünften Klasse Mathe
                case "4_Math_OA":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, Math, Operations & Algebraic Thinking";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_Math_OA", gamelistTitle); });
                    break;
                case "4_Math_NBT":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, Math, Number and Operations in Base Ten";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_Math_NBT", gamelistTitle); });
                    break;
                case "4_Math_NF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, Math, Number and Operations Fractions";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_Math_NF", gamelistTitle); });
                    break;
                case "4_Math_MD":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, Math, Measurement and Data";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_Math_MD", gamelistTitle); });
                    break;
                case "4_Math_G":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, Math, Geometry";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_Math_G", gamelistTitle); });
                    break;

                //Händler der ersten Klasse Englisch
                case "0_English_RL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "First class, English, Reading: Literature";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_English_RL", gamelistTitle); });
                    break;
                case "0_English_RI":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "First class, English, Reading: Informational Text";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_English_RI", gamelistTitle); });
                    break;
                case "0_English_RF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "First class, English, Reading: Foundational Skills";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_English_RF", gamelistTitle); });
                    break;
                case "0_English_W":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "First class, English, Writing";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_English_W", gamelistTitle); });
                    break;
                case "0_English_SL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "First class, English, Speaking & Listening";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_English_SL", gamelistTitle); });
                    break;
                case "0_English_L":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "First class, English, Language";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("0_English_L", gamelistTitle); });
                    break;

                //Händler der zweiten Klasse Englisch
                case "1_English_RL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, English, Reading: Literature";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_English_RL", gamelistTitle); });
                    break;
                case "1_English_RI":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, English, Reading: Informational Text";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_English_RI", gamelistTitle); });
                    break;
                case "1_English_RF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, English, Reading: Foundational Skills";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_English_RF", gamelistTitle); });
                    break;
                case "1_English_W":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, English, Writing";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_English_W", gamelistTitle); });
                    break;
                case "1_English_SL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, English, Speaking & Listening";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_English_SL", gamelistTitle); });
                    break;
                case "1_English_L":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Second class, English, Language";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("1_English_L", gamelistTitle); });
                    break;

                //Händler der dritten Klasse Englisch
                case "2_English_RL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, English, Reading: Literature";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_English_RL", gamelistTitle); });
                    break;
                case "2_English_RI":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, English, Reading: Informational Text";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_English_RI", gamelistTitle); });
                    break;
                case "2_English_RF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, English, Reading: Foundational Skills";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_English_RF", gamelistTitle); });
                    break;
                case "2_English_W":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, English, Writing";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_English_W", gamelistTitle); });
                    break;
                case "2_English_SL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, English, Speaking & Listening";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_English_SL", gamelistTitle); });
                    break;
                case "2_English_L":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Third class, English, Language";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("2_English_L", gamelistTitle); });
                    break;

                //Händler der vierten Klasse Englisch
                case "3_English_RL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, English, Reading: Literature";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_English_RL", gamelistTitle); });
                    break;
                case "3_English_RI":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, English, Reading: Informational Text";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_English_RI", gamelistTitle); });
                    break;
                case "3_English_RF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, English, Reading: Foundational Skills";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_English_RF", gamelistTitle); });
                    break;
                case "3_English_W":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, English, Writing";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_English_W", gamelistTitle); });
                    break;
                case "3_English_SL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, English, Speaking & Listening";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_English_SL", gamelistTitle); });
                    break;
                case "3_English_L":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fourth class, English, Language";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("3_English_L", gamelistTitle); });
                    break;

                //Händler der fünften Klasse Englisch
                case "4_English_RL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, English, Reading: Literature";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_English_RL", gamelistTitle); });
                    break;
                case "4_English_RI":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, English, Reading: Informational Text";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_English_RI", gamelistTitle); });
                    break;
                case "4_English_RF":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, English, Reading: Foundational Skills";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_English_RF", gamelistTitle); });
                    break;
                case "4_English_W":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, English, Writing";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_English_W", gamelistTitle); });
                    break;
                case "4_English_SL":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, English, Speaking & Listening";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_English_SL", gamelistTitle); });
                    break;
                case "4_English_L":
                    npcName.text = "Hans";
                    npcText.text = "";
                    gamelistTitle = "Fifth class, English, Language";
                    acceptButton.onClick.AddListener(delegate () { OpenGameList("4_English_L", gamelistTitle); });
                    break;
            }
        }
    }

    public void CancelCommunication()
    {
        //if there is no more text then 

        commObjekt.SetActive(false);
    }

    public void OpenGameList(string standardName, string titleBar)
    {
        commObjekt.SetActive(false);

        gamelistObject.SetActive(true);
        //call function to fill gamelist
        //fill list

        gamelistTitleBar.text = titleBar;

    }

    public void CloseGameList()
    {
        gamelistObject.SetActive(false);

        //probably a message like "Thank you for visiting the shop!"
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, trader.GetClosestObject("InteractionObject", player).transform.position) > distance)
        {
            CancelCommunication();
        }
    }
}
