using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public string gameName;
    public string downloadLink;
}

public class GameScrollList : MonoBehaviour
{
    public List<Games> gameList;
    public Transform gamelistPanel;
    public GameScrollList downloadedGamesPanel;
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

    public void TransferToDownloadedGameList(Games game)
    {
        AddGame(game, downloadedGamesPanel);

    }

    private void AddGame(Games gameToAdd, GameScrollList scrollList)
    {
        scrollList.gameList.Add(gameToAdd);
    }
}
