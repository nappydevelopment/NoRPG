using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BackToStartWorld : MonoBehaviour {

    AsyncOperation ao;

    public Canvas hud;
    public Canvas loadingScreen;
    public Slider progBar;

    void OnTriggerEnter()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PortalControl.control.cameFrom = currentScene;

        hud.gameObject.SetActive(false);
        loadingScreen.gameObject.SetActive(true);

        StartCoroutine(LoadLevelWithRealProgress());
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("Scenes/Startwelt", LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;

            if (ao.progress == 0.9f)
            {
                progBar.value = 1f;
                ao.allowSceneActivation = true;
            }

            Debug.Log(ao.progress);
            yield return null;
        }

    }
}
