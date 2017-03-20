using UnityEngine;
using CnControls;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class CharacterControll : MonoBehaviour {

    private CharacterController character;
    private Animation kid_animation;
    [SerializeField]
    private float directionDumpTime = .25f;

    private float speed = 0.0f;
    private float h = 0.0f;
    private float v = 0.0f;

    void Start()
    {
        kid_animation = GetComponent<Animation>();
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        h = CnInputManager.GetAxis("Horizontal");
        v = CnInputManager.GetAxis("Vertical");
        speed = new Vector2(h, v).sqrMagnitude;

        if (speed != 0)
        {
            StartAnimation("Walk");
            int multiplier = 4;
            // If the player presses and holds the B button, the charakter will Move faster
            if (CrossPlatformInputManager.GetButton("B"))
            {
                multiplier = 6;
            } 
            Vector3 moveDirection = new Vector3(h, 0, v) * speed * multiplier;
            character.SimpleMove(moveDirection);
            character.transform.rotation = Quaternion.LookRotation(moveDirection);
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
