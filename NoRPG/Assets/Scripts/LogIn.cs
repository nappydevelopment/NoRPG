using UnityEngine;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour {

    protected virtual void OnClick()
    {
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
