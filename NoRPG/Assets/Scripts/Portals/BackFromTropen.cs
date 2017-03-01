using UnityEngine.SceneManagement;
using UnityEngine;

public class BackFromTropen : MonoBehaviour {

    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
