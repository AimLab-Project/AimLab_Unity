using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSObject 
{
    //오브젝트 정보 전달을 위한 인터페이스 
    public float CheckTime(); //return. 생성 후 삭제전 시간.
    public float GetDistancePlayer(); // 유저와 오브젝트 간 거리. 

    public GameObject GetTargetObject();

    public void SetLookAt(Transform pos);

    public GameObject GetBulletHole();

    public void SetBulletHole(GameObject gameObject);

    public HitType GetHitType(GameObject gameObject);

    public EQuadrants GetScreenPos();
}
