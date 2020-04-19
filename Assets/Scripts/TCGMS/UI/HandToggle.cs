using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HandToggle : MonoBehaviour
{
    public Text text;
    public Card card;

    public PlayButton PlayButton;
    public Toggle toggle;
    public Toggle[] toggles;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        if (toggle)
            toggle.onValueChanged.AddListener((val) =>
            {
                if (val)
                {
                    PlayButton.selected = card;
                    foreach (var t in toggles)
                        t.isOn = false;
                }
            });
    }

    private void Update()
    {
        if (card)
            text.text = $"{card.name}/{card.Cost}/{card.Life}/{card.Power}";
        else
            text.text = "";
    }
}
