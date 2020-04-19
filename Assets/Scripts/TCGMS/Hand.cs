using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public int Capacity;
    [SerializeField]
    public List<Card> Cards;
    [SerializeField]
    private Cemetary cemetary;
    [SerializeField]
    private Text text;

    public void AddCard(Card card)
    {
        if (Cards.Count(x => x != null) == Capacity)
        {
            cemetary.Cards.Add(card);
            return;
        }

        Cards.Add(card);
    }

    private void Update()
    {
        if (text == null) return;
        text.text = "Hand\n";
        foreach (var card in Cards)
        {
            text.text += $"Cost:{card.Cost}/Life:{card.Life}/Power:{card.Power}\n";
        }
    }
}
