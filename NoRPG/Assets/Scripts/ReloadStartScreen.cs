using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadStartScreen : MonoBehaviour {

	public void ReloadScene() {
        SceneManager.LoadScene("Scenes/LoggedOutUser", LoadSceneMode.Single);
    }
}
