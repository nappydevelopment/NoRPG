using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

    private CharacterController character;
    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        character.SimpleMove(new Vector3(1, 0, 0));

    }
}
