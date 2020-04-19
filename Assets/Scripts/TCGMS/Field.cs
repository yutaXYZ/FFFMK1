using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Field : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();
    [SerializeField]
    Text text;

    public void Add(Card card)
    {
        Cards.Add(card);
    }

    private void Update()
    {
        if (text == null) return;
        text.text = "Field\n";
        foreach (var card in Cards)
        {
            text.text += $"Cost:{card.Cost}/Life:{card.Life}/Power:{card.Power}\n";
        }
    }
}
