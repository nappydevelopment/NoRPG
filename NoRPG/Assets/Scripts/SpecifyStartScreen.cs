using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecifyStartScreen : MonoBehaviour {

	void Awake()
    {
        GameControl.control.Load();

        if (GameControl.control.username != "")
        {
            SceneManager.LoadScene("Scenes/LoggedInUser", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Scenes/LoggedOutUser", LoadSceneMode.Single);
        }
    }
}
