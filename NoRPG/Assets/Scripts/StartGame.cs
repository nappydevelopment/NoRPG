using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

    //get LastSavedPosition (GameObject)
    //if lastSavedPosition != null --> Load Last Scene 
    //else StartScene

    private static string secretKey = "norpg";
    public static string loginURL = "http://norpg.it.dh-karlsruhe.de/login.php?";

    AsyncOperation ao;

    public Image progressCircle;
    public InputField username;
    public InputField password;

	public void StartGameAtLastPosition() {
        progressCircle.gameObject.SetActive(true);
        Debug.Log(MD5Test.Md5Sum(password.text));
        StartCoroutine(LoginUser(username.text, MD5Test.Md5Sum(password.text)));
    }

    public IEnumerator LoadLevelWithRealProgress() {
        yield return new WaitForSeconds(1);

        ao = SceneManager.LoadSceneAsync("Scenes/Startwelt", LoadSceneMode.Single);
        ao.allowSceneActivation = false;

        while (!ao.isDone) {
            progressCircle.fillAmount = ao.progress +0.1f;

            if (ao.progress == 0.9f) {
               // progressCircle.fillAmount = 1.0f;
                ao.allowSceneActivation = true;
            }

            Debug.Log(ao.progress);
            yield return null;
        }
    }

    public IEnumerator LoginUser(string user, string password) {
    string hash = MD5Test.Md5Sum(user + password + secretKey);


    string get_url = loginURL
        + "user=" + WWW.EscapeURL(user)
        + "&password=" + WWW.EscapeURL(password)
        + "&hash=" + hash;

    WWW hs_get = new WWW(get_url);
    yield return hs_get;

    if (hs_get.error != null) {
        print("There was an error getting the information: " + hs_get.error);
    }
    else {
        Debug.Log(hs_get.text);
        if (hs_get.text.Contains("true")) {
            StartCoroutine(LoadLevelWithRealProgress());
        }else{
            Debug.Log("no user / wrong password");
        }
    }
}
}
