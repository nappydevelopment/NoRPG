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
    public List<Game> gameList;
    public Transform gamelistPanel;
    public GameScrollList downloadedGamesPanel;
    public SimpleObjectPool buttonObjectPool;

    public GameScrollList() { }

    public void AddButtons(List<Game> gamesToAdd)
    {
        gameList = gamesToAdd;

        for (int i = 0; i < gameList.Count; i++)
        {
            Game game = gameList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(gamelistPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(game, this);
        }
    }

    public void TransferToDownloadedGameList(Game game)
    {
        AddGame(game, downloadedGamesPanel);

    }

    private void AddGame(Game gameToAdd, GameScrollList scrollList)
    {
        scrollList.gameList.Add(gameToAdd);
    }
}
