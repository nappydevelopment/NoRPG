#pragma strict

function OnTriggerEnter(Col : Collider)
    {
        if (Col.tag == "Player")
        {
            Application.LoadLevel("Scenes/Desert");
            //SceneManager.LoadScene("Scenes/Desert");
        }
    }