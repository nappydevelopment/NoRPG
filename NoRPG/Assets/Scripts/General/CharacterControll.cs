using UnityEngine;
using System.Collections;
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

    private bool loadOnce = true;
    
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
        /*
        if (loadOnce == true)
        {
            //objektorientiert abbilden in interfaces! todo
            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log(currentScene);

            if (currentScene == "Startwelt")
            {
                //todo
            }
            else
            {
                transform.position = GameObject.FindWithTag("SpawnPoint").transform.position;
            }

            loadOnce = false;
        }
        */
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0)
        {
            StartAnimation("Walk");
            Vector3 moveDirection = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
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
        //objektorientiert abbilden in interfaces! todo
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);

        if (currentScene == "Startwelt")
        {
            //todo
        }
        else
        {
            transform.position = GameObject.FindWithTag("SpawnPoint").transform.position;
        }
    }
}
