using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSGame 
{
    public bool IsGame { get; set; }

    // ���� �帧�� ���� <- �ڷ�ƾ�� ������
    public void StartGame();

    public void StopGame();
    
    // �ش� ���� Ÿ���� GameManager �� ���ϴ� Ÿ������ Ȯ�� �� ��ȯ��. 
    public bool CheckType(GAME_TYPE type);

}

public enum GAME_TYPE
{
    SHOOTING,
    AIMBOTGAME,
    AIMCUSTOM
}
