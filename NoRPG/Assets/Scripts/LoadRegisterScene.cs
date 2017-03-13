using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRegisterScene : MonoBehaviour {

    public AudioSource startAudio;
    public Canvas hud;

	public void RegisterBtn()
    {
        DontDestroyOnLoad(startAudio);
        hud.gameObject.SetActive(false);

        SceneManager.LoadScene("Scenes/Register", LoadSceneMode.Additive);
    }
}
