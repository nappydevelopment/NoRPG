using UnityEngine;
using UnityEngine.SceneManagement;

public class BackFromForest : MonoBehaviour
{
    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
