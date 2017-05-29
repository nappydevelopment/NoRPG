using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandle : MonoBehaviour {

    public GameObject chest_1;
    public GameObject chest_2;
    public GameObject chest_3;
    public GameObject chest_4;
    public GameObject chest_5;
    public GameObject chest_6;
    public GameObject chest_7;
    public GameObject chest_8;

    public GameObject gem_1;
    public GameObject gem_2;
    public GameObject gem_3;
    public GameObject gem_4;
    public GameObject gem_5;
    public GameObject gem_6;
    public GameObject gem_7;
    public GameObject gem_8;

    public Button acceptButton;
    public Button cancelButton;
    public Text npcText;

    private NPCCommunication npcc;

    private Animator chest_1_Animator;
    private Animator chest_2_Animator;
    private Animator chest_3_Animator;
    private Animator chest_4_Animator;
    private Animator chest_5_Animator;
    private Animator chest_6_Animator;
    private Animator chest_7_Animator;
    private Animator chest_8_Animator;

    public int gemCound = GameControl.control.gemCount;

    public int GemCound {
        get {
            return gemCound;
        }

        set {
            gemCound = value;
        }
    }

    void Start()
    {
        chest_1_Animator = chest_1.GetComponent<Animator>();
        chest_2_Animator = chest_2.GetComponent<Animator>();
        chest_3_Animator = chest_3.GetComponent<Animator>();
        chest_4_Animator = chest_4.GetComponent<Animator>();
        chest_5_Animator = chest_5.GetComponent<Animator>();
        chest_6_Animator = chest_6.GetComponent<Animator>();
        chest_7_Animator = chest_7.GetComponent<Animator>();
        chest_8_Animator = chest_8.GetComponent<Animator>();

        LoadChests();
    }

    public void OpenChest(string chestNumber)
    {
        acceptButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        if (chestNumber == "1_Chest")
        {
            chest_1_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_1); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_1); });

            SetCorrectChest(1);
        }
        if (chestNumber == "2_Chest")
        {
            chest_2_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_2); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_2); });
            SetCorrectChest(2);
        }
        if (chestNumber == "3_Chest")
        {
            chest_3_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_3); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_3); });
            SetCorrectChest(3);
        }
        if (chestNumber == "4_Chest")
        {
            chest_4_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_4); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_4); });
            SetCorrectChest(4);
        }
        if (chestNumber == "5_Chest")
        {
            chest_5_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_5); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_5); });
            SetCorrectChest(5);
        }
        if (chestNumber == "6_Chest")
        {
            chest_6_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_6); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_6); });
            SetCorrectChest(6);
        }
        if (chestNumber == "7_Chest")
        {
            chest_7_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_7); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_7); });
            SetCorrectChest(7);
        }
        if (chestNumber == "8_Chest")
        {
            chest_8_Animator.SetTrigger("Open");
            acceptButton.onClick.AddListener(delegate () { CollectGem(gem_8); });
            cancelButton.onClick.AddListener(delegate () { CollectGem(gem_8); });
            SetCorrectChest(8);
        }

        GameControl.control.Save();
    }

    private void CollectGem(GameObject gem)
    {
        gem.SetActive(false);
        GemCound++;
        GameControl.control.gemCount = GemCound;
        npcText.text = "You collected the gem! You can look at your collected gems in the achievements.";
    }

    private void SetCorrectChest(int gemNumber)
    {
        string currentScene = PortalControl.control.currentScene;

        switch (gemNumber)
        {
            case 1:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_1_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_1_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_1_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_1_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_1_lava_open = true;
                        break;
                }
                break;
            case 2:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_2_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_2_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_2_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_2_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_2_lava_open = true;
                        break;
                }
                break;
            case 3:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_3_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_3_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_3_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_3_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_3_lava_open = true;
                        break;
                }
                break;
            case 4:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_4_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_4_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_4_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_4_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_4_lava_open = true;
                        break;
                }
                break;
            case 5:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_5_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_5_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_5_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_5_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_5_lava_open = true;
                        break;
                }
                break;
            case 6:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_6_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_6_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_6_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_6_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_6_lava_open = true;
                        break;
                }
                break;
            case 7:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_7_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_7_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_7_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_7_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_7_lava_open = true;
                        break;
                }
                break;
            case 8:
                switch (currentScene)
                {
                    case "first_forrest":
                        GameControl.control.chest_8_forest_open = true;
                        break;
                    case "Tropic_World":
                        GameControl.control.chest_8_tropen_open = true;
                        break;
                    case "Desert":
                        GameControl.control.chest_8_desert_open = true;
                        break;
                    case "Snow_World":
                        GameControl.control.chest_8_snow_open = true;
                        break;
                    case "Lavawelt":
                        GameControl.control.chest_8_lava_open = true;
                        break;
                }
                break;
        }

        
    }

    private void LoadChests()
    {
        string currentScene = PortalControl.control.currentScene;
        GameControl.control.LoadFromFile();

        if (currentScene == "first_forrest")
        {
            if (GameControl.control.chest_1_forest_open == true)
            {
                chest_1_Animator.SetTrigger("Open");
                gem_1.SetActive(false);
            }
            if (GameControl.control.chest_2_forest_open == true)
            {
                chest_2_Animator.SetTrigger("Open");
                gem_2.SetActive(false);
            }
            if (GameControl.control.chest_3_forest_open == true)
            {
                chest_3_Animator.SetTrigger("Open");
                gem_3.SetActive(false);
            }
            if (GameControl.control.chest_4_forest_open == true)
            {
                chest_4_Animator.SetTrigger("Open");
                gem_4.SetActive(false);
            }
            if (GameControl.control.chest_5_forest_open == true)
            {
                chest_5_Animator.SetTrigger("Open");
                gem_5.SetActive(false);
            }
            if (GameControl.control.chest_6_forest_open == true)
            {
                chest_6_Animator.SetTrigger("Open");
                gem_6.SetActive(false);
            }
            if (GameControl.control.chest_7_forest_open == true)
            {
                chest_7_Animator.SetTrigger("Open");
                gem_7.SetActive(false);
            }
            if (GameControl.control.chest_8_forest_open == true)
            {
                chest_8_Animator.SetTrigger("Open");
                gem_8.SetActive(false);
            }
        }

        if (currentScene == "Tropic_World")
        {
            if (GameControl.control.chest_1_tropen_open == true)
            {
                chest_1_Animator.SetTrigger("Open");
                gem_1.SetActive(false);
            }
            if (GameControl.control.chest_2_tropen_open == true)
            {
                chest_2_Animator.SetTrigger("Open");
                gem_2.SetActive(false);
            }
            if (GameControl.control.chest_3_tropen_open == true)
            {
                chest_3_Animator.SetTrigger("Open");
                gem_3.SetActive(false);
            }
            if (GameControl.control.chest_4_tropen_open == true)
            {
                chest_4_Animator.SetTrigger("Open");
                gem_4.SetActive(false);
            }
            if (GameControl.control.chest_5_tropen_open == true)
            {
                chest_5_Animator.SetTrigger("Open");
                gem_5.SetActive(false);
            }
            if (GameControl.control.chest_6_tropen_open == true)
            {
                chest_6_Animator.SetTrigger("Open");
                gem_6.SetActive(false);
            }
            if (GameControl.control.chest_7_tropen_open == true)
            {
                chest_7_Animator.SetTrigger("Open");
                gem_7.SetActive(false);
            }
            if (GameControl.control.chest_8_tropen_open == true)
            {
                chest_8_Animator.SetTrigger("Open");
                gem_8.SetActive(false);
            }
        }

        if (currentScene == "Desert")
        {
            if (GameControl.control.chest_1_desert_open == true)
            {
                chest_1_Animator.SetTrigger("Open");
                gem_1.SetActive(false);
            }
            if (GameControl.control.chest_2_desert_open == true)
            {
                chest_2_Animator.SetTrigger("Open");
                gem_2.SetActive(false);
            }
            if (GameControl.control.chest_3_desert_open == true)
            {
                chest_3_Animator.SetTrigger("Open");
                gem_3.SetActive(false);
            }
            if (GameControl.control.chest_4_desert_open == true)
            {
                chest_4_Animator.SetTrigger("Open");
                gem_4.SetActive(false);
            }
            if (GameControl.control.chest_5_desert_open == true)
            {
                chest_5_Animator.SetTrigger("Open");
                gem_5.SetActive(false);
            }
            if (GameControl.control.chest_6_desert_open == true)
            {
                chest_6_Animator.SetTrigger("Open");
                gem_6.SetActive(false);
            }
            if (GameControl.control.chest_7_desert_open == true)
            {
                chest_7_Animator.SetTrigger("Open");
                gem_7.SetActive(false);
            }
            if (GameControl.control.chest_8_desert_open == true)
            {
                chest_8_Animator.SetTrigger("Open");
                gem_8.SetActive(false);
            }
        }

        if (currentScene == "Snow_World")
        {
            if (GameControl.control.chest_1_snow_open == true)
            {
                chest_1_Animator.SetTrigger("Open");
                gem_1.SetActive(false);
            }
            if (GameControl.control.chest_2_snow_open == true)
            {
                chest_2_Animator.SetTrigger("Open");
                gem_2.SetActive(false);
            }
            if (GameControl.control.chest_3_snow_open == true)
            {
                chest_3_Animator.SetTrigger("Open");
                gem_3.SetActive(false);
            }
            if (GameControl.control.chest_4_snow_open == true)
            {
                chest_4_Animator.SetTrigger("Open");
                gem_4.SetActive(false);
            }
            if (GameControl.control.chest_5_snow_open == true)
            {
                chest_5_Animator.SetTrigger("Open");
                gem_5.SetActive(false);
            }
            if (GameControl.control.chest_6_snow_open == true)
            {
                chest_6_Animator.SetTrigger("Open");
                gem_6.SetActive(false);
            }
            if (GameControl.control.chest_7_snow_open == true)
            {
                chest_7_Animator.SetTrigger("Open");
                gem_7.SetActive(false);
            }
            if (GameControl.control.chest_8_snow_open == true)
            {
                chest_8_Animator.SetTrigger("Open");
                gem_8.SetActive(false);
            }
        }

        if (currentScene == "Lavawelt")
        {
            if (GameControl.control.chest_1_lava_open == true)
            {
                chest_1_Animator.SetTrigger("Open");
                gem_1.SetActive(false);
            }
            if (GameControl.control.chest_2_lava_open == true)
            {
                chest_2_Animator.SetTrigger("Open");
                gem_2.SetActive(false);
            }
            if (GameControl.control.chest_3_lava_open == true)
            {
                chest_3_Animator.SetTrigger("Open");
                gem_3.SetActive(false);
            }
            if (GameControl.control.chest_4_lava_open == true)
            {
                chest_4_Animator.SetTrigger("Open");
                gem_4.SetActive(false);
            }
            if (GameControl.control.chest_5_lava_open == true)
            {
                chest_5_Animator.SetTrigger("Open");
                gem_5.SetActive(false);
            }
            if (GameControl.control.chest_6_lava_open == true)
            {
                chest_6_Animator.SetTrigger("Open");
                gem_6.SetActive(false);
            }
            if (GameControl.control.chest_7_lava_open == true)
            {
                chest_7_Animator.SetTrigger("Open");
                gem_7.SetActive(false);
            }
            if (GameControl.control.chest_8_lava_open == true)
            {
                chest_8_Animator.SetTrigger("Open");
                gem_8.SetActive(false);
            }
        }
    }

}
