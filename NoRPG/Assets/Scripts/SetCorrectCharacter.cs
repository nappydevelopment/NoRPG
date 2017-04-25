using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCorrectCharacter : MonoBehaviour {

    public GameObject m1;
    public GameObject m2;
    public GameObject m3;
    public GameObject m4;
    public GameObject m5;
    public GameObject m6;
    public GameObject m7;
    public GameObject m8;

    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;
    public GameObject f5;
    public GameObject f6;
    public GameObject f7;
    public GameObject f8;

    public GameObject player;

    public Avatar m1a;
    public Avatar m2a;
    public Avatar m3a;
    public Avatar m4a;
    public Avatar m5a;
    public Avatar m6a;
    public Avatar m7a;
    public Avatar m8a;

    public Avatar f1a;
    public Avatar f2a;
    public Avatar f3a;
    public Avatar f4a;
    public Avatar f5a;
    public Avatar f6a;
    public Avatar f7a;
    public Avatar f8a;

    void Awake()
    {
        //LOAD
        string correctCharacterModel = GameControl.control.correctCharacterModel;
        
        switch (correctCharacterModel)
        {
            case "M1":
                m1.SetActive(true);
                player.GetComponent<Animator>().avatar = m1a;
                break;
            case "M2":
                m2.SetActive(true);
                player.GetComponent<Animator>().avatar = m2a;
                break;
            case "M3":
                m3.SetActive(true);
                player.GetComponent<Animator>().avatar = m3a;
                break;
            case "M4":
                m4.SetActive(true);
                player.GetComponent<Animator>().avatar = m4a;
                break;
            case "M5":
                m5.SetActive(true);
                player.GetComponent<Animator>().avatar = m5a;
                break;
            case "M6":
                m6.SetActive(true);
                player.GetComponent<Animator>().avatar = m6a;
                break;
            case "M7":
                m7.SetActive(true);
                player.GetComponent<Animator>().avatar = m7a;
                break;
            case "M8":
                m8.SetActive(true);
                player.GetComponent<Animator>().avatar = m8a;
                break;

            case "F1":
                f1.SetActive(true);
                player.GetComponent<Animator>().avatar = f1a;
                break;
            case "F2":
                f2.SetActive(true);
                player.GetComponent<Animator>().avatar = f2a;
                break;
            case "F3":
                f3.SetActive(true);
                player.GetComponent<Animator>().avatar = f3a;
                break;
            case "F4":
                f4.SetActive(true);
                player.GetComponent<Animator>().avatar = f4a;
                break;
            case "F5":
                f5.SetActive(true);
                player.GetComponent<Animator>().avatar = f5a;
                break;
            case "F6":
                f6.SetActive(true);
                player.GetComponent<Animator>().avatar = f6a;
                break;
            case "F7":
                f7.SetActive(true);
                player.GetComponent<Animator>().avatar = f7a;
                break;
            case "F8":
                f8.SetActive(true);
                player.GetComponent<Animator>().avatar = f8a;
                break;
        }
    }
}
