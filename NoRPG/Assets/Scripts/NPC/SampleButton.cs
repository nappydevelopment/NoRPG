using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    public Button button;
    public Text nameLabel;
    public Image iconImage;

    private Game game;
    private GameScrollList scrollList;

    public void Setup(Game currentGame, GameScrollList currentScrollList)
    {
        game = currentGame;
        nameLabel.text = game.gameName;
        iconImage.sprite = game.downloadIcon;

        scrollList = currentScrollList;
    }
}