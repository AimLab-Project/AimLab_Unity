using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSGame 
{
    // ���� �帧�� ���� <- �ڷ�ƾ�� ������
    public Coroutine GetCoroutine();
    
    // �ش� ���� Ÿ���� GameManager �� ���ϴ� Ÿ������ Ȯ�� �� ��ȯ��. 
    public bool CheckType(GAME_TYPE type);

}

public enum GAME_TYPE
{
    SHOOTING,
    AIMBOTGAME,
    AIMCUSTOM
}
