using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PortalToForrest : MonoBehaviour
{
    AsyncOperation ao;

    public Canvas hud;
    public Canvas loadingScreen;
    public Slider progBar;

    void OnTriggerEnter()
    {
        
        loadingScreen.gameObject.SetActive(true);

        StartCoroutine(LoadLevelWithRealProgress());

        hud.gameObject.SetActive(true);
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("Scenes/first_forrest", LoadSceneMode.Single);
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
