using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPassenger : MonoBehaviour {

    //some public variables
    public EditorPathScript path;
    public int currentWayPointId = 0;
    public float speed;
    public float rotationSpeed = 5.0f;
    public string pathName;

    public GameObject player;
    public GameObject ship;
    public GameObject follow;
    public GameObject player_mesh;
    public GameObject player_text;
    public GameObject minidot;
    public GameObject hud;
    public CharacterControll cc;

    //Is the player on ship
    private bool playerOnShip = false;

    //last clicked button
    private string lastButtonClicked = "1";

    //is the HUD open
    private bool hudIsOpen = false;

    //has the player travel with the ship
    private bool playerShipped = false;

    //the last and the current position of the ship
    Vector3 lastPosition;
    Vector3 currentPosition;

    //distance minimum distance between point and ship
    private float reachDistance = 1.0f;


    void Start () {
        lastPosition = transform.position;

        for (int i = 0; i < player.transform.childCount; i++) {
            if (player.transform.GetChild(i).gameObject.activeSelf == true) {
               player_mesh  = player.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject;
               player_text = player.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject;
               break;
            }
        }
    }

    void Update () {
        moveShip();
    }

    public void moveShip () {
        //if player is on the ship
        if (playerOnShip) {
            //get the distance between ship and the first point
            float distance = Vector3.Distance(path.path_objs[currentWayPointId].position, transform.position);
            //set the ship to the first point
            transform.position = Vector3.MoveTowards(transform.position, path.path_objs[currentWayPointId].position, Time.deltaTime * speed);
            //set the player on ship
            player.transform.position = transform.position;

            //rotate the ship in direction to the next point
            var rotation = Quaternion.LookRotation(path.path_objs[currentWayPointId].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            player.transform.rotation = ship.transform.rotation;

            //if the distance between the ship and the point is less then reachDistance raise the currentwaypointid
            if (distance <= reachDistance) {
                currentWayPointId++;
            }

            //if the currentwaypoint is greater equal the size of the list
            if (currentWayPointId >= path.path_objs.Count) {
                //set ship to the last position
                this.transform.position = path.path_objs[path.path_objs.Count-1].position;
                //set playershipped status to true and make some other things
                playerShipped = true;
                cc.enabled = true;
                playerOnShip = false;
                player_mesh.SetActive(true);
                player_text.SetActive(true);
                follow.transform.parent = player.transform;
                follow.transform.position = player.transform.position;

                minidot.SetActive(true);
                player.transform.position = new Vector3(path.path_objs[path.path_objs.Count - 1].position.x, 6.3f, path.path_objs[path.path_objs.Count - 1].position.z);
                
                currentWayPointId = 0;
            }
        }
    }

    void OnCollisionEnter (Collision col) {
        //if the ship collides with the player and the player is on ship
        if (col.gameObject.name == player.name) {
            Debug.Log("Player On Ship");
            if(!playerShipped)
                playerGetOnShip();
        }
    }

    public void setShippedStatusToFalse () {
        playerShipped = false;
    }

    public void playerGetOnShip () {
        if (!playerOnShip) {
            cc.enabled = false;

            player.GetComponent<Animator>().SetFloat("speed", 0.0f);
            player.GetComponent<Animator>().SetFloat("direction", 0.0f);
            player.transform.position = ship.transform.position;

            player_mesh.SetActive(false);
            player_text.SetActive(false);

            follow.transform.parent = ship.transform;
            follow.transform.position = ship.transform.position + new Vector3(2.25f, 18.07f, -7.07f);

            minidot.SetActive(false);

            hud.SetActive(true);
        }
    }

    //if button one is clicked
    public void selectFirstClass () {
        //if player is not on the same Island
        if (lastButtonClicked != "1") {
            hud.SetActive(false);
            // set path to the island on that the player is to island 1
            path = GameObject.Find("Path" + lastButtonClicked + "_1").GetComponent<EditorPathScript>();
            lastButtonClicked = "1";
            playerOnShip = true;
        }
    }

    public void selectSecoundClass () {
        if (lastButtonClicked != "2") {
            hud.SetActive(false);
            path = GameObject.Find("Path" + lastButtonClicked + "_2").GetComponent<EditorPathScript>();
            lastButtonClicked = "2";
            playerOnShip = true;
        }
    }

    public void selectThirdClass () {
        if (lastButtonClicked != "3") {
            hud.SetActive(false);
            path = GameObject.Find("Path" + lastButtonClicked + "_3").GetComponent<EditorPathScript>();
            lastButtonClicked = "3";

            playerOnShip = true;
        }
    }

    public void selectFourthClass () {
        if (lastButtonClicked != "4") {
            hud.SetActive(false);
            path = GameObject.Find("Path" + lastButtonClicked + "_4").GetComponent<EditorPathScript>();
            lastButtonClicked = "4";
            playerOnShip = true;
        }
    }

    public void selectFithstClass () {
        if (lastButtonClicked != "5") {
            hud.SetActive(false);
            path = GameObject.Find("Path" + lastButtonClicked + "_5").GetComponent<EditorPathScript>();
            lastButtonClicked = "5";
            playerOnShip = true;
        }
    }
}
