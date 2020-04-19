using UnityEngine;
using System.Collections.Generic;

public class Cemetary : MonoBehaviour
{
    [SerializeField]
    public List<Card> Cards;

    private void Start()
    {
        Cards = new List<Card>();
    }
}
