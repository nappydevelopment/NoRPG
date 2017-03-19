using UnityEngine;
using CnControls;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class CharacterControll : MonoBehaviour {

    public float moveForce = 5;
    private CharacterController character;
        
    private Animation kid_animation;

    // Use this for initialization
    void Start()
    {
        kid_animation = GetComponent<Animation>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CnInputManager.GetAxis("Horizontal") != 0 || CnInputManager.GetAxis("Vertical") != 0)
        {
            StartAnimation("Walk");
            Vector3 moveDirection = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical")) * moveForce;
            character.SimpleMove(moveDirection);
            character.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        
        // If the player presses and holds the B button, the charakter will Move faster
        if (CrossPlatformInputManager.GetButton("B"))
        {
            moveForce = 9;
        }
        else
        {
            moveForce = 5;
        }
    }

    private bool StartAnimation(string animation)
    {
        return kid_animation.Play(animation);
    }

    //new Method since Unity5.3 and since OnLevelWasLoaded is deprecated
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. 
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //get current scene and last used scene befor hitting Startwelt
        string currentScene = SceneManager.GetActiveScene().name;
        string cameFrom = PortalControl.control.cameFrom;

        //overwrite current scene in PortalControl
        PortalControl.control.currentScene = currentScene;

        //if current scene is Startwelt then specify spawnpoint
        if (currentScene == "Startwelt")
        {
            //cameFromTag can be --> "DesertSpawnPoint" || "first_forrestSpawnPoint || "Snow_WorldSpawnPoint" || "LavaweltSpawnPoint" || "Tropic_WorldSpawnPoint"
            string cameFromTag = cameFrom + "SpawnPoint";

            try
            {
                LoadSpawnPoint(cameFromTag);
            }
            catch
            {
                // if the Spawnpoint doesnt exist spawn in the center of the town
                LoadSpawnPoint("CitySpawnPoint");
            }
        }
        else
        {
            LoadSpawnPoint("SpawnPoint");
        }
    }

    void LoadSpawnPoint(string tagName)
    {
        transform.position = GameObject.FindWithTag(tagName).transform.position;
    }
}
