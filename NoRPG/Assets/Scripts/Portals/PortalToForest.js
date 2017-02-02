#pragma strict

function OnTriggerEnter(Col : Collider)
{
    if (Col.tag == "Player")
    {
        Application.LoadLevel("Scenes/first_forrest");
        //SceneManager.LoadScene("Scenes/first_forrest");
    }
}