using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToDesert : MonoBehaviour
{
    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Desert", LoadSceneMode.Single);
    }
}