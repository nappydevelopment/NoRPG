using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToLava : MonoBehaviour
{
    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Lavawelt", LoadSceneMode.Single);
    }
}
