using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public string gameName;
    public Sprite downloadIcon;
}

public class GameScrollList : MonoBehaviour {
    public Transform gamelistPanel;
    public SimpleObjectPool buttonObjectPool;
    public List<Game> gameList;

    public GameScrollList(){}

    public void AddButtons()
    {
        int countGames = 5; // get i value from GetGameList

        for (int i = 0; i < countGames; i++)
        {
            Game game = gameList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(gamelistPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(game, this);
        }
    }
}
