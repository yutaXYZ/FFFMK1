using UnityEngine;
using UnityEngine.UI;

public class EndButton : Button
{
    [SerializeField]
    private Game game;

    protected override void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            game.turn.Quit();
        });
    }
}
