using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSGame 
{
    public bool IsGame { get; set; }

    // 게임 흐름을 전달 <- 코루틴을 전달함
    public void StartGame();

    public void StopGame();
    
    // 해당 게임 타입이 GameManager 가 원하는 타입인지 확인 후 반환함. 
    public bool CheckType(GAME_TYPE type);

}

public enum GAME_TYPE
{
    SHOOTING,
    AIMBOTGAME,
    AIMCUSTOM
}
