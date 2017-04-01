/**
 * This is part of the NEEDSIM Life simulation plug in for Unity, version 1.0.2
 * Copyright 2014 - 2016 Fantasieleben UG (haftungsbeschraenkt)
 *
 * http;//www.fantasieleben.com for further details.
 *
 * For questions please get in touch with Tilman Geishauser: tilman@fantasieleben.com
 */

using UnityEngine;
using System.Collections;

namespace NEEDSIMSampleSceneScripts
{
    /// <summary>
    /// Sets the fox to either run or walk
    /// </summary>
    [RequireComponent(typeof(NEEDSIM.NEEDSIMNode))]
    public class Fox : Animal
    {
        public bool isRunning { get; set; }
        [Tooltip("The speed the NavMeshAgent should have when the fox is running.")]
        public float runSpeed;
        [Tooltip("The speed the NavMeshAgent should have when the fox is walking.")]
        public float walkSpeed;

        private UnityEngine.AI.NavMeshAgent navMeshAgent;

        public override void Start()
        {
            animator = gameObject.GetComponentInChildren<Animator>();
            navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            base.Start();
        }

        public override void Update()
        {
            if (isRunning)
            {
                navMeshAgent.speed = runSpeed;
            }
            else
            {
                navMeshAgent.speed = walkSpeed;
            }
            animator.SetBool("RunOrWalk", isRunning);

            base.Update();
        }
    }
}
