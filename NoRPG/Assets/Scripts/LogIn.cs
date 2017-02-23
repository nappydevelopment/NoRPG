using UnityEngine;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour {

    void OnClick()
    {
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
