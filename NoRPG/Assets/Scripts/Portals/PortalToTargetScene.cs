using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PortalToTargetScene : MonoBehaviour
{
    AsyncOperation ao;

    public Canvas loadingScreen;
    public Slider progBar;
    public string targetSceneName; 

    void OnTriggerEnter()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PortalControl.control.cameFrom = currentScene;
        PortalControl.control.currentScene = targetSceneName;

        loadingScreen.gameObject.SetActive(true);

        StartCoroutine(LoadLevelWithRealProgress());
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("Scenes/" + targetSceneName, LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progBar.value = ao.progress;

            if (ao.progress == 0.9f)
            {
                progBar.value = 1f;
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
