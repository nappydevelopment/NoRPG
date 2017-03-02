using UnityEngine.SceneManagement;
using UnityEngine;

public class BackFromDesert : MonoBehaviour {

    void OnTriggerEnter()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scenes/Startwelt", LoadSceneMode.Single);

        //Access to global variable from CharacterControll to specify from which map the player is coming from
        GameObject thePlayer = GameObject.Find("Player");
        CharacterControll characterControll = thePlayer.GetComponent<CharacterControll>();

        characterControll.globalCameFrom = "Desert";
    }
}
