using UnityEngine.SceneManagement;
using UnityEngine;

public class BackFromIce : MonoBehaviour {

    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
