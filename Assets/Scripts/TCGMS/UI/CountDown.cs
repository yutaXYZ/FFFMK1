using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private Text countDown;
    [SerializeField]
    private Game game;

    private void Awake()
    {
        countDown = GetComponent<Text>();
    }

    private void Update()
    {
        countDown.text = game.turn.RemainingTime.ToString();
    }
}
