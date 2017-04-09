using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPassenger : MonoBehaviour {

    public EditorPathScript path;
    public int currentWayPointId = 0;
    public float speed;
    public float rotationSpeed = 5.0f;
    public string pathName;
    private Vector3 position = new Vector3(2.25f, 18.07f, -7.07f);

    public GameObject player;
    public GameObject ship;
    public GameObject follow;
    public GameObject player_mesh;
    public GameObject player_text;
    public GameObject minidot;


    public GameObject hud;
    public CharacterControll cc;

    private bool playerOnShip = false;
    private string lastButtonClicked = "1";
    private bool hudIsOpen = false;
    private bool playerShipped = false;

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
            player.transform.position = transform.position;

            var rotation = Quaternion.LookRotation(path.path_objs[currentWayPointId].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            player.transform.rotation = ship.transform.rotation;

            if (distance <= reachDistance) {
                currentWayPointId++;
            }

            if (currentWayPointId >= path.path_objs.Count) {
                this.transform.position = path.path_objs[path.path_objs.Count-1].position;
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
            follow.transform.position = ship.transform.position + position;

            minidot.SetActive(false);

            hud.SetActive(true);
        }
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
