using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterControll : MonoBehaviour {

    public float moveForce = 5;
    private CharacterController character;

    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        character.SimpleMove(new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce);
        if(CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0) {
            GetComponent<Animation>().CrossFade("Walk");
        }
    }
}
