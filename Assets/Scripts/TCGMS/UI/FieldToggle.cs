using UnityEngine;
using UnityEngine.UI;

public class FieldToggle : MonoBehaviour
{
    public Text text;
    public Card card;

    public AttackButton attackButton;
    public Toggle toggle;

    public Toggle[] toggles;

    private void Start()
    {
        if (toggle)
            toggle.onValueChanged.AddListener((val) =>
            {
                if (val)
                {
                    attackButton.selected = card;
                    foreach (var t in toggles)
                        t.isOn = false;
                }
            });
    }

    private void Update()
    {
        if (card)
            text.text = $"{card.name}-Attack/{card.hasAttacked.ToString()}";
        else
            text.text = "";
    }
}
