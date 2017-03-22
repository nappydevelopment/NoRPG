﻿using UnityEngine;
using CnControls;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class CharacterControll : MonoBehaviour {

    //   private CharacterController character;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float directionDumpTime = .25f;
    [SerializeField]
    private ThirdPersonCamera gamecam;
    [SerializeField]
    private float directionSpeed = 3.0f;
    [SerializeField]
    private float rotationDegreePerSecound = 120f;

    private float speed = 0.0f;
    private float direction = 0f;
    private float h = 0.0f;
    private float v = 0.0f;
    private AnimatorStateInfo stateInfo;

    private int m_LocomotionID = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        if(animator.layerCount >= 2)
        {
            animator.SetLayerWeight(1, 1);
        }
        m_LocomotionID = Animator.StringToHash("Base Layer.Locomotion");
    }

    void FixedUpdate()
    {
        if(IsInLocomotion() && ((direction>=0 && h>=0) || (direction <0 && h < 0)))
        {
            Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecound * (h < 0f ? -1f : 1f), 0f), Mathf.Abs(h));
            Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
            this.transform.rotation = (this.transform.rotation * deltaRotation);
        }
    }

    public bool IsInLocomotion()
    {
        return stateInfo.nameHash == m_LocomotionID;
    }

    void Update()
    {
        if (animator)
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            h = CnInputManager.GetAxis("Horizontal");
            v = CnInputManager.GetAxis("Vertical");

            StickToWorldspace(this.transform, gamecam.transform, ref direction, ref speed);

            animator.SetFloat("speed", speed);
            animator.SetFloat("direction", direction, directionDumpTime, Time.deltaTime);
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. 
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //get current scene and last used scene befor hitting Startwelt
        string currentScene = SceneManager.GetActiveScene().name;
        string cameFrom = PortalControl.control.cameFrom;

        PortalControl.control.currentScene = currentScene;

        if (currentScene == "Startwelt")
        {
            //cameFromTag can be --> "DesertSpawnPoint" || "first_forrestSpawnPoint || "Snow_WorldSpawnPoint" || "LavaweltSpawnPoint" || "Tropic_WorldSpawnPoint"
            string cameFromTag = cameFrom + "SpawnPoint";

            try
            {
                LoadSpawnPoint(cameFromTag);
            }
            catch
            {
                // if the Spawnpoint doesnt exist spawn in the center of the town
                LoadSpawnPoint("CitySpawnPoint");
            }
        }
        else
        {
            LoadSpawnPoint("SpawnPoint");
        }
    }

    void LoadSpawnPoint(string tagName)
    {
        transform.position = GameObject.FindWithTag(tagName).transform.position;
    }

    public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut)
    {
        Vector3 rootDirection = root.forward;

        Vector3 stickDirection = new Vector3(h, 0, v);

        speedOut = stickDirection.sqrMagnitude;

        // Get camera rotation
        Vector3 CameraDirection = camera.forward;
        CameraDirection.y = 0.0f; // kill Y
        Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, Vector3.Normalize(CameraDirection));

        // Convert joystick input in Worldspace coordinates
        Vector3 moveDirection = referentialShift * stickDirection;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);

        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), moveDirection, Color.green);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), rootDirection, Color.magenta);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), stickDirection, Color.blue);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2.5f, root.position.z), axisSign, Color.red);

        float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);
        
        angleRootToMove /= 180f;

        directionOut = angleRootToMove * directionSpeed;
    }
}
