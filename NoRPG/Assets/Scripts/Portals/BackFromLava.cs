using UnityEngine;
using UnityEngine.SceneManagement;

public class BackFromLava : MonoBehaviour {

    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
