using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{
    public Button button;
    public Text nameLabel;
    public Image iconImage;

    private Games game;
    private GameScrollList scrollList;

    public void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(Games currentGame, GameScrollList currentScrollList)
    {
        game = currentGame;
        nameLabel.text = game.name;

        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        Application.OpenURL("market://details?q=pname:com.mycompany.myapp/");
    }
}