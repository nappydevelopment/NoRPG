using UnityEngine;
using UnityEngine.SceneManagement;

public class LogOut : MonoBehaviour {
	
	void OnClick ()
    {
        SceneManager.LoadScene("Scenes/Startscreen", LoadSceneMode.Single);
    }
}
