using UnityEngine;
using CnControls;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class CharacterControll : MonoBehaviour {

    public float moveForce = 5;
    private CharacterController character;
    public GameObject chest_1;
    public GameObject chest_2;
    public GameObject chest_3;
    public GameObject chest_4;
    public GameObject chest_5;
    public GameObject chest_6;
    public GameObject chest_7;
    public GameObject chest_8;
    private Animator chest_1_Ani;
    private Animator chest_2_Ani;
    private Animator chest_3_Ani;
    private Animator chest_4_Ani;
    private Animator chest_5_Ani;
    private Animator chest_6_Ani;
    private Animator chest_7_Ani;
    private Animator chest_8_Ani;
        
    private Animation kid_animation;

    // Use this for initialization
    void Start()
    {
        kid_animation = GetComponent<Animation>();
        character = GetComponent<CharacterController>();
        chest_1_Ani = chest_1.GetComponent<Animator>();
        chest_2_Ani = chest_2.GetComponent<Animator>();
        chest_3_Ani = chest_3.GetComponent<Animator>();
        chest_4_Ani = chest_4.GetComponent<Animator>();
        chest_5_Ani = chest_5.GetComponent<Animator>();
        chest_6_Ani = chest_6.GetComponent<Animator>();
        chest_7_Ani = chest_7.GetComponent<Animator>();
        chest_8_Ani = chest_8.GetComponent<Animator>();
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
        bool isPressed = CrossPlatformInputManager.GetButton("B");

        if (isPressed)
        {
            chest_1_Ani.SetTrigger("Open");
            chest_2_Ani.SetTrigger("Open");
            chest_3_Ani.SetTrigger("Open");
            chest_4_Ani.SetTrigger("Open");
            chest_5_Ani.SetTrigger("Open");

            chest_6_Ani.SetTrigger("Open");
            chest_7_Ani.SetTrigger("Open");
            chest_8_Ani.SetTrigger("Open");
            StartAnimation("Cheer");
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
