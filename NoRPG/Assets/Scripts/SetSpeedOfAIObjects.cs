using NEEDSIM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetSpeedOfAIObjects : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent nma;
    private Vector3 position;
    private NEEDSIMNode nnode;

    void Start () {
        animator = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();
        nnode = GetComponent<NEEDSIMNode>();
	}
	
	// Update is called once per frame
	void Update () {
        position = this.transform.position;
        if (nnode.AcceptSlot())
            animator.SetFloat("speed", 0f);
        else
            animator.SetFloat("speed", nma.speed);

        Debug.Log(this.name + " :" + nma.speed);
	}
}
