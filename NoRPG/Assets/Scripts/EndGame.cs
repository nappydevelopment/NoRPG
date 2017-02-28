using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour {

    public void EndGameButton()
    {
        SceneManager.LoadScene("Scenes/Startscreen", LoadSceneMode.Single);
    }
}
