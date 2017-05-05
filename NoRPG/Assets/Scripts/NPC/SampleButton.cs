using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    public Button button;
    public Text nameLabel;
    public Image iconImage;

    private Games game;
    private GameScrollList scrollList;
    private string marketUrl;

    public void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(Games currentGame, GameScrollList currentScrollList)
    {
        game = currentGame;
        nameLabel.text = game.name;
        marketUrl = game.url;

        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        //add clicked game to played game list
        GameControl.control.playedGames.Add(game.Standard);
        scrollList.TransferToDownloadedGameList(game);
        
        //open google play store
        Application.OpenURL(marketUrl);
    }
}