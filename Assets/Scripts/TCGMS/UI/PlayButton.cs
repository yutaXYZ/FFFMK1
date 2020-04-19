using UnityEngine;
using UnityEngine.UI;

public class PlayButton: MonoBehaviour
{
    [SerializeField]
    public Card selected;
    [SerializeField]
    public Button button;
    public Player player;

    private void Start()
    {
        button.onClick.AddListener(Play);
    }

    private void Play()
    {
        if (selected)
            player.Play(selected);
        selected = null;
    }
}
