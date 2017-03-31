using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripptedStartAnimation : MonoBehaviour {

    [SerializeField]
    private GameObject hud;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject playerdot;
    [SerializeField]
    private Camera playerCamera;
    // Use this for initialization
    void Start () {
        hud.SetActive(false);
        playerdot.SetActive(false);
        playerCamera.transform.position = player.transform.position + new Vector3(5, 5, 5);
        Invoke("startCommunication", 5f);
        hud.SetActive(true);

    }

    private void startCommunication()
    {
        //Start Dialoug here 
        //blablablalsjbföiuwunefäoiwnefväfüoiniweväfokmwev



    }

    // Update is called once per frame
    void LateUpdate () {
		
	}
}
