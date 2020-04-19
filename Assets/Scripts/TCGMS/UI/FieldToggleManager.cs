using UnityEngine;

public class FieldToggleManager : MonoBehaviour
{
    [SerializeField]
    private Field field;
    [SerializeField]
    private FieldToggle[] FieldToggles;
    private void Update()
    {
        foreach (var toggle in FieldToggles)
            toggle.card = null;
        var toggleIndex = 0;
        foreach (var card in field.Cards)
        {
            FieldToggles[toggleIndex++].card = card;
        }
    }
}
