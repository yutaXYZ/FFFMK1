using UnityEngine;
using System.Collections;
using System.Linq;

public class Game : MonoBehaviour
{
    public EndButton button;

    [SerializeField]
    private Player[] players = new Player[0];
    [SerializeField]
    private Player CurrentPlayPlayer;

    [SerializeField]
    public Turn turn = new Turn();

    private void Update()
    {
        if (players.Any(x => x.Life <= 0))
        {
            Quit();
            return;
        }

        turn.Update();
        if (turn.Ends)
        {
            turn = new Turn();
            foreach (var player in players)
                player.turn = turn;
            CurrentPlayPlayer = CurrentPlayPlayer == players[0] ? players[1] : players[0];
            turn.player = CurrentPlayPlayer;
            CurrentPlayPlayer.ChangeTurn();
            if (!CurrentPlayPlayer.IsNPC)
            {
                button.gameObject.SetActive(true);
                StartCoroutine("ShowMessage");
            }
            else
            {
                button.gameObject.SetActive(false);   
            }
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 30), new GUIContent("Terminate")))
        {
            turn.Quit();
        }
    }

    private IEnumerator ShowMessage()
    {
        var message = new Message();
        message.SetText("Your turn");
        yield return new WaitForSeconds(1);
        message.SetText("");
    }

    public void Quit()
    {
        StartCoroutine("ShowMessage");
        gameObject.SetActive(false);
    }
}
