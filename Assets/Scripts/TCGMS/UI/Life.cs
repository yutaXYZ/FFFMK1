using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    private Text text;

    private void Update()
    {
        text.text = player.Life.ToString();
    }
}
