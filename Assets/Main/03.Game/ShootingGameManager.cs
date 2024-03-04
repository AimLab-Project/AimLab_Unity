using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour, IFPSGame
{
    GAME_TYPE type = GAME_TYPE.SHOOTING;

    [Range(0.0f,60.0f)]
    public float delay;

    public bool IsGame { get; set; }

    void Init()
    {

    }


    public bool CheckType(GAME_TYPE type)
    {
        if (this.type == type)
            return true;

        return false;
    }

    public IEnumerator GetCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(delay);

        yield return waitTime;
    }

    public void StartGame()
    {
        IsGame = true;
    }

    public void StopGame()
    {
        IsGame = false;
    }
}
