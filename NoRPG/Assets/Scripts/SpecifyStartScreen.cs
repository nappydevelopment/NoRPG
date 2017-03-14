using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecifyStartScreen : MonoBehaviour {

	void Awake()
    {
        GetUsername();

        if (GameControl.control.username != "")
        {
            SceneManager.LoadScene("Scenes/LoggedInUser", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Scenes/LoggedOutUser", LoadSceneMode.Single);
        }
    }

    void GetUsername()
    {
        GameControl.control.Load();
    }
}
