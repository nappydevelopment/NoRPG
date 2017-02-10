using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToForrest : MonoBehaviour
{
    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/first_forrest", LoadSceneMode.Single);
    }
}
