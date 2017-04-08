using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPassenger : MonoBehaviour {

    public EditorPathScript path;
    public int currentWayPointId = 0;
    public float speed;
    public float rotationSpeed = 5.0f;
    public string pathName;

    //Player and Ship
    public GameObject player;
    public GameObject ship;
    public GameObject hud;

    private bool playerOnShip = false;
    private string lastButtonClicked = "1";
    private bool hudIsOpen = false;
    


    Vector3 lastPosition;
    Vector3 currentPosition;

    private float reachDistance = 1.0f;


    void Start () {
        lastPosition = transform.position;

    }

    void Update () {
        moveShip();
    }

    public void moveShip () {
        if (playerOnShip) {
            float distance = Vector3.Distance(path.path_objs[currentWayPointId].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, path.path_objs[currentWayPointId].position, Time.deltaTime * speed);

            var rotation = Quaternion.LookRotation(path.path_objs[currentWayPointId].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            if (distance <= reachDistance) {
                currentWayPointId++;
            }

            if (currentWayPointId >= path.path_objs.Count) {
                this.transform.position = path.path_objs[path.path_objs.Count-1].position;
                playerOnShip = false;
                currentWayPointId = 0;
            }
        }
    }

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.name == player.name) {
            Debug.Log("Player On Ship");
            playerGetOnShip();
        }
    }

    public void playerGetOnShip () {
        if(!playerOnShip)
            hud.SetActive(true);
    }

    public void selectFirstClass () {
        if (lastButtonClicked != "1") {
            hud.SetActive(false);
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
