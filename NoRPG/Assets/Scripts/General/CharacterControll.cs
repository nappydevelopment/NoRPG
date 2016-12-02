using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

    private CharacterController character;
    public int x = 0;
    public int z = 0;

    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        character.SimpleMove(new Vector3(x, 0, z));

    }
}
