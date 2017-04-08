using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandle : MonoBehaviour {

    public GameObject chest_1;
    public GameObject chest_2;
    public GameObject chest_3;
    public GameObject chest_4;
    public GameObject chest_5;
    public GameObject chest_6;
    public GameObject chest_7;
    public GameObject chest_8;

    private Animator chest_1_Animator;
    private Animator chest_2_Animator;
    private Animator chest_3_Animator;
    private Animator chest_4_Animator;
    private Animator chest_5_Animator;
    private Animator chest_6_Animator;
    private Animator chest_7_Animator;
    private Animator chest_8_Animator;

    void Start()
    {
        chest_1_Animator = chest_1.GetComponent<Animator>();
        chest_2_Animator = chest_2.GetComponent<Animator>();
        chest_3_Animator = chest_3.GetComponent<Animator>();
        chest_4_Animator = chest_4.GetComponent<Animator>();
        chest_5_Animator = chest_5.GetComponent<Animator>();
        chest_6_Animator = chest_6.GetComponent<Animator>();
        chest_7_Animator = chest_7.GetComponent<Animator>();
        chest_8_Animator = chest_8.GetComponent<Animator>();
    }

    public void OpenChest(string chestNumber)
    {
        if (chestNumber == "1_Chest")
        {
            chest_1_Animator.SetTrigger("Open");
        } if (chestNumber == "2_Chest")
        {
            chest_2_Animator.SetTrigger("Open");
        } if (chestNumber == "3_Chest")
        {
            chest_3_Animator.SetTrigger("Open");
        } if (chestNumber == "4_Chest")
        {
            chest_4_Animator.SetTrigger("Open");
        } if (chestNumber == "5_Chest")
        {
            chest_5_Animator.SetTrigger("Open");
        } if (chestNumber == "6_Chest")
        {
            chest_6_Animator.SetTrigger("Open");
        } if (chestNumber == "7_Chest")
        {
            chest_7_Animator.SetTrigger("Open");
        } if (chestNumber == "8_Chest")
        {
            chest_8_Animator.SetTrigger("Open");
        }
    }

}
