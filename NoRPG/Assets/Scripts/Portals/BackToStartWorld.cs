using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToStartWorld : MonoBehaviour {

    void OnTriggerEnter()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PortalControl.control.cameFrom = currentScene;

        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
