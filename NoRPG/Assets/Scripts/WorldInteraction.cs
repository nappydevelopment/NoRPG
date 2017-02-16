using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("InteractButton")) && !UnityEngine.EventSystems.EventTrigger.Entry.)
                GetInteraction();
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Interactable interacted")
            }
            else
            {

            }
        }
    }
	
}
