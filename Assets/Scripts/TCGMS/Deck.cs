using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Deck : MonoBehaviour
{
    [SerializeField]
    public List<Card> cards;
    public void SetCards(IEnumerable<Card> cards)
    {
        this.cards = cards.ToList();
    }
}
