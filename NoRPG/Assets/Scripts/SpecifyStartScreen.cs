using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecifyStartScreen : MonoBehaviour {

    public static SpecifyStartScreen control;

    public AudioSource audioSource;

	void Awake()
    {
        DontDestroyOnLoad(audioSource);
        SceneManager.LoadScene("Scenes/LoggedOutUser", LoadSceneMode.Single);
    }
}
