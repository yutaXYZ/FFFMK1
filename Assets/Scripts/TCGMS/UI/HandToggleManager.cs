using UnityEngine;

public class HandToggleManager : MonoBehaviour
{
    [SerializeField]
    private Hand hand;
    [SerializeField]
    private HandToggle[] handToggles;
    private void Update()
    {
        foreach (var toggle in handToggles)
            toggle.card = null;
        var toggleIndex = 0;
        foreach(var card in hand.Cards)
        {
            handToggles[toggleIndex++].card = card;
        }
    }
}
