using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField]
    public Card selected;
    [SerializeField]
    public Button button;
    public Player player;

    private void Start()
    {
        button.onClick.AddListener(Attack);
    }

    private void Attack()
    {
        if (selected)
            player.Attack(selected, null);
        selected = null;
    }
}
