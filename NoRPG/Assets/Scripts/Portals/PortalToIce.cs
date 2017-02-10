using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToIce : MonoBehaviour
{
    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Snow_World", LoadSceneMode.Single);
    }
}