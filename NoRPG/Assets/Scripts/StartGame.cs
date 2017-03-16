using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

    //get LastSavedPosition (GameObject)
    //if lastSavedPosition != null --> Load Last Scene 
    //else StartScene

    AsyncOperation ao;

    public Image progressCircle;

	public void StartGameAtLastPosition() {

        progressCircle.gameObject.SetActive(true);

        StartCoroutine(LoadLevelWithRealProgress());

    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("Scenes/Startwelt", LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            progressCircle.fillAmount = ao.progress +0.1f;

            if (ao.progress == 0.9f)
            {
               // progressCircle.fillAmount = 1.0f;
                ao.allowSceneActivation = true;
            }

            Debug.Log(ao.progress);
            yield return null;
        }
    }
}
