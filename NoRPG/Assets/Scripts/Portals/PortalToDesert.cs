using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToDesert : MonoBehaviour
{
    void OnTriggerEnter()
    {
        PortalControl.control.currentScene = "Desert";

        SceneManager.LoadScene("Scenes/Desert", LoadSceneMode.Single);
    }
}