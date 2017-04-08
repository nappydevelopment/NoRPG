using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecifyStartScreen : MonoBehaviour {

	void Start()
    {
        GameControl.control.CreateFile();

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
