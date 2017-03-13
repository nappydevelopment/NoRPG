using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecifyStartScreen : MonoBehaviour {

	void Awake()
    {
        SceneManager.LoadScene("Scenes/LoggedOutUser", LoadSceneMode.Single);
    }
}
