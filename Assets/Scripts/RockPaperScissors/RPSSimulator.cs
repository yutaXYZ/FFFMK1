using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[Serializable]
public class RPSSimulator : MonoBehaviour
{
    public bool IsActive;

    public string Player1;
    public Button Rock1;
    public Button Paper1;
    public Button Sissors1;
    public Button Select1;

    public string Player2;
    public Button Rock2;
    public Button Paper2;
    public Button Sissors2;
    public Button Select2;

    public float CountDown;
    public Text CountDownDisplayer;
    public float InitialCount;
    public Button SubmitButton;
    public Text Result;

    public Button[] Buttons => new Button[] { Rock1, Paper1, Sissors1, Rock2, Paper2, Sissors2 };

    public string Winner { get; private set; } = "";
    public string Looser { get; private set; } = "";

    private void Start()
    {
        foreach (var button in Buttons)
            button.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
        CountDownDisplayer.gameObject.SetActive(false);
        SetEvent();
    }

    private void SetEvent()
    {
        Rock1.onClick.AddListener(() => Select1 = Rock1);
        Paper1.onClick.AddListener(() => Select1 = Paper1);
        Sissors1.onClick.AddListener(() => Select1 = Sissors1);
    }

    public void Activate()
    {
        SelectNPCHand();
        IsActive = true;
        CountDown = InitialCount;
        foreach (var b in Buttons)
            b.gameObject.SetActive(true);
        SubmitButton.gameObject.SetActive(true);
        CountDownDisplayer.gameObject.SetActive(true);
        CountDownDisplayer.text = InitialCount.ToString();

        SubmitButton.onClick.AddListener(() =>
        {
            foreach (var button in Buttons)
            {
                if (Select1 != button && Select2 != button)
                    button.gameObject.SetActive(false);
            }
            SubmitButton.gameObject.SetActive(false);
            IsActive = false;
            SetResult();
            if (Winner == "") {
                Result.text = "Drow";
            } else if (Winner == Player1) {
                Result.text = "You win!";
            } else {
                Result.text = "You lose";
            }
        });
    }

    public void SelectNPCHand()
    {
        var rand = new System.Random();
        var val = rand.Next(0, 3);
        var hands = new Button[] { Rock2, Paper2, Sissors2 };
        Select2 = hands[val];
    }

    private void Update()
    {
        if (!IsActive) return;

        CountDown -= Time.deltaTime;
        CountDownDisplayer.text = Math.Floor(CountDown).ToString();

        if (CountDown <= 0)
        {
            foreach (var button in Buttons)
                if (button != Select1 || button != Select2)
                    button.gameObject.SetActive(false);

            CountDownDisplayer.text = "0";
            IsActive = false;
        }
    }

    public void SetResult()
    {
        if (Select1 == Rock1)
        {
            if (Select2 == Rock2)
            {
                StartCoroutine(Reset());
            }
            else if (Select2 == Paper2)
            {
                Winner = Player2;
                Looser = Player1;
                CleanUp();
            }
            else
            {
                Winner = Player1;
                Looser = Player2;
                CleanUp();
            }
        }
        else if (Select1 == Paper1)
        {
            if (Select2 == Rock2)
            {
                Winner = Player1;
                Looser = Player2;
                CleanUp();
            }
            else if (Select2 == Paper2)
            {
                StartCoroutine(Reset());
            }
            else
            {
                Winner = Player2;
                Looser = Player1;
                CleanUp();
            }
        }
        else
        {
            if (Select2 == Rock2)
            {
                Winner = Player2;
                Looser = Player1;
                CleanUp();
            }
            else if (Select2 == Paper2)
            {
                Winner = Player1;
                Looser = Player2;
                CleanUp();
            }
            else
            {
                StartCoroutine(Reset());
            }
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 30), "Activate"))
        {
            Activate();
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        Result.text = "";
        foreach (var button in Buttons)
            button.gameObject.SetActive(true);
        IsActive = true;
        CountDown = InitialCount;
        SubmitButton.gameObject.SetActive(true);
        Select1 = Select2 = null;
        SelectNPCHand();
        yield break;
    }

    private void CleanUp()
    {
        StartCoroutine(HideUIElements());
    }

    private IEnumerator HideUIElements()
    {
        yield return new WaitForSeconds(1);
        foreach (var button in Buttons)
            button.gameObject.SetActive(false);

        StartCoroutine(HideUIElements());

        CountDownDisplayer.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
        Result.gameObject.SetActive(false);
    }
}
