using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToTropical : MonoBehaviour
{
    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Tropic_World", LoadSceneMode.Single);
    }
}