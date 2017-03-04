using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToStartWorld : MonoBehaviour {

    void OnTriggerEnter()
    {
        //Access to global variable from CharacterControll to specify from which map the player is coming from
        GameObject thePlayer = GameObject.Find("Player");
        CharacterControll characterControll = thePlayer.GetComponent<CharacterControll>();

        string currentScene = SceneManager.GetActiveScene().name;

        characterControll.globalCameFrom = currentScene;
        Debug.Log(characterControll.globalCameFrom);

        //switch Scene
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);
    }
}
