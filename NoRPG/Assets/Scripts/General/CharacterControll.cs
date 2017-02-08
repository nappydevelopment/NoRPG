using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

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
    public GameObject dragon;

    private GameObject kid;
    private Animation kid_animation;

    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterController>();
        chest_1_Ani = chest_1.GetComponent<Animator>();
        chest_2_Ani = chest_2.GetComponent<Animator>();
        chest_3_Ani = chest_3.GetComponent<Animator>();
        chest_4_Ani = chest_4.GetComponent<Animator>();
        chest_5_Ani = chest_5.GetComponent<Animator>();
        chest_6_Ani = chest_6.GetComponent<Animator>();
        chest_7_Ani = chest_7.GetComponent<Animator>();
        chest_8_Ani = chest_8.GetComponent<Animator>();
        kid_animation = kid.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0) {
            GetComponent<Animation>().CrossFade("Walk");
            Vector3 moveDirection = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
            character.SimpleMove(moveDirection);
            character.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        bool isPressed = CrossPlatformInputManager.GetButton("B");

        if (isPressed) {
            chest_1_Ani.SetTrigger("Open");
            chest_2_Ani.SetTrigger("Open");
            chest_3_Ani.SetTrigger("Open");
            chest_4_Ani.SetTrigger("Open");
            chest_5_Ani.SetTrigger("Open");
            chest_6_Ani.SetTrigger("Open");
            chest_7_Ani.SetTrigger("Open");
            chest_8_Ani.SetTrigger("Open");
        }
    }

    void OnLevelWasLoaded(int thisLevel)
    {
        transform.position = GameObject.FindWithTag("SpawnPoint").transform.position;
    }
}
