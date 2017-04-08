using System.Collections.Generic;
using UnityEngine;

public class GameScrollList : MonoBehaviour
{
    public List<Games> gameList;
    public Transform gamelistPanel;
    public SimpleObjectPool buttonObjectPool;

    public GameScrollList() { }

    public void AddButtons(List<Games> gamesToAdd)
    {
        gameList = gamesToAdd;

        for (int i = 0; i < gameList.Count; i++)
        {
            Games game = gameList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(gamelistPanel);
            newButton.transform.localScale = new Vector3(1, 1, 1);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(game, this);
        }
    }

    public void RemoveButtons()
    {
        //removes every child from panel after closing the panel
        var children = new List<GameObject>();

        foreach (Transform child in gamelistPanel)
        {
            children.Add(child.gameObject);
        }

        children.ForEach(child => Destroy(child));
    }

    public void TransferToDownloadedGameList(Games game)
    {
        Debug.Log("Transfer to downloaded game list");
        GameControl.control.CreateFile();

        List<Games> downloadedGames = GameControl.control.downloadedGames;
        
        if (!downloadedGames.Contains(game))
        {
            GameControl.control.downloadedGames.Add(game);
            GameControl.control.Save();
            Debug.Log("Game attempted");
        }        
    }
}
