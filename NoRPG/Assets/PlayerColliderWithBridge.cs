using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderWithBridge : MonoBehaviour {

    public GameObject player;
    public ShipPassenger sp;
    //id player collides with the bridge set shippedstatus to false
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.name == player.name) {
            Debug.Log("Player On Bridge");
            sp.setShippedStatusToFalse();
        }
    }
}
