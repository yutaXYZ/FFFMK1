using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Text text;

    void Update()
    {
        text.text = player.Mana.ToString();
    }
}
