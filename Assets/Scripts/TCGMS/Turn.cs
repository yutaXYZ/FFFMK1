using System;
using UnityEngine;

[Serializable]
public class Turn
{
    [SerializeField]
    private float TimeLimit = 10;
    [SerializeField]
    private float elapsedTime = 0;
    [SerializeField]
    private bool active = true;
    [SerializeField]
    private bool end;
    public bool Ends => end;
    public Player player;

    public int RemainingTime => (int)Math.Floor(TimeLimit - elapsedTime);

    public void Update()
    {
        if (!active) return;

        elapsedTime += Time.deltaTime;
        if (elapsedTime > TimeLimit)
        {
            active = false;
            end = true;
            return;
        }
    }

    public void Quit()
    {
        active = false;
        end = true;
    }
}