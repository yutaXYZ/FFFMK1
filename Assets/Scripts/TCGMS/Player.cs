using UnityEngine;

public class Player : MonoBehaviour
{
    public int Life = 10;
    public int Mana = 0;
    public int ManaCapacity = 0;

    public bool IsNPC = false;
    public string Name = "";
    public Card[] Cards;
    public int DeckCardNum = 40;
    public Deck deck;
    public Hand hand;
    public bool Enable;
    public Player Enemy;
    public Turn turn;

    public Field Field;

    public void ChangeTurn()
    {
        ManaCapacity++;
        Mana = ManaCapacity;
        var card = deck.cards.Trim(0, 1)[0];
        hand.AddCard(card);
        foreach (var c in Field.Cards)
        {
            c.hasAttacked = false;
        }
    }

    private void Start()
    {
        Cards = MakeCards();
        SetParentThis(Cards);
        deck.SetCards(Cards);

        var cards = deck.cards.Trim(0, 5);
        
        foreach (var card in cards)
        {
            hand.AddCard(card);
        }
    }

    private void SetParentThis(Card[] cards)
    {
        foreach (var c in cards)
            c.transform.SetParent(transform);
    }

    private Card[] MakeCards()
    {
        Card[] result = new Card[DeckCardNum];
        for (int i = 0; i < DeckCardNum; i++)
        {
            var obj = new GameObject("Card");
            result[i] = obj.AddComponent<Card>();
        }
            
        return result;
    }

    public void Play(Card card)
    {
        if (turn.player != this) return;
        if (hand.Cards.Count == 0) return;
        if (Mana < card.Cost) return;

        hand.Cards.Remove(card);
        Field.Cards.Add(card);
        Mana -= card.Cost;
    }

    public void Attack(Card card, Card target)
    {
        if (turn.player != this) return;
        if (card.hasAttacked == true) return;

        if (target)
            target.Life -= card.Power;
        else
            Enemy.Life -= card.Power;

        card.hasAttacked = true;
    }
}
