using System.Collections;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;


    private Vector3 lookDir;
    private Vector3 targetPosition;

    private Vector3 velocityCamSmopth = Vector3.zero;
    [SerializeField]
    private float camSmoothDampTime = 0.1f;

    void Start () {
        follow = GameObject.FindWithTag("Player1").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        Vector3 characterOffset = follow.position +  new Vector3(0f, distanceUp, 0f);

        lookDir = characterOffset - this.transform.position;
        lookDir.y = 0;
        lookDir.Normalize();
        Debug.DrawRay(this.transform.position, lookDir, Color.green);

        //  targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        targetPosition = characterOffset + follow.up * distanceUp - lookDir * distanceAway;

        //  Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        //  Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetPosition, Color.magenta);
        //  transform.position = characterOffset + follow.up * distanceUp - lookDir * distanceAway;

        CompensateForWalls(characterOffset, ref targetPosition);
        smoothPosition(this.transform.position, targetPosition);

        transform.LookAt(follow);
    }

    private void smoothPosition(Vector3 fromPos, Vector3 toPos) {
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmopth, camSmoothDampTime);
    }

    private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
    {
        Debug.DrawLine(fromObject, toTarget, Color.cyan);
        RaycastHit wallHit = new RaycastHit();
        if(Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            Debug.DrawLine(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }
    }
}
