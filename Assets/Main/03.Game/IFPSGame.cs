using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSGame 
{
    public static bool IsGame { get; set; }

    public void StartGame();

    public void StopGame();
    
    public bool CheckType(GAME_TYPE type);

}

public enum GAME_TYPE
{
    SHOOTING,
    AIMBOTGAME,
    AIMCUSTOM
}
