using UnityEngine.SceneManagement;
using UnityEngine;

public class BackFromDesert : MonoBehaviour {

    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
