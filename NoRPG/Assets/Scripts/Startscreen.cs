using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startscreen : MonoBehaviour {

    public GameObject settingsCanvas;

	void Update () {
        HideIfClickedOutside(settingsCanvas);
    }

    private void HideIfClickedOutside(GameObject panel)
    {
        if (Input.anyKeyDown && !RectTransformUtility.RectangleContainsScreenPoint(panel.GetComponent<RectTransform>(),Input.mousePosition,Camera.main))
        {
            panel.SetActive(false);
        }
    }
}
