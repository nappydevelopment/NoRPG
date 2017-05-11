using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPathScript : MonoBehaviour {

    //Color of the lines betwwen the single points
    public Color rayColor = Color.white;
    //List of all points of the path
    public List<Transform> path_objs = new List<Transform>();
    //List of all transformobjects of every point in path
    Transform[] transforms;

    //Method to draw in the Unity Editor
    void OnDrawGizmos () {
        //Set Color of lines to selected color
        Gizmos.color = rayColor;
        //Get all transformobjects of childrends
        transforms = GetComponentsInChildren<Transform>();
        //Clear the list
        path_objs.Clear();

        //Foreach transformobject at it to list if it is not the parentobject
        foreach (Transform path_obj in transforms) {
            if (path_obj != this.transform) {
                path_objs.Add(path_obj);
            }
        }
        //Draw lines between every Point
        for(int i = 0; i < path_objs.Count; i++) {
            Vector3 position = path_objs[i].position;
            if (i > 0) {
                Vector3 previos = path_objs[i - 1].position;
                Gizmos.DrawLine(previos, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
