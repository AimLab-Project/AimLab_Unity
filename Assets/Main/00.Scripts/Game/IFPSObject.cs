using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSObject 
{
    //������Ʈ ���� ������ ���� �������̽� 
    public float CheckTime(); //return. ���� �� ������ �ð�.
    public float GetDistancePlayer(); // ������ ������Ʈ �� �Ÿ�. 

    public GameObject GetTargetObject();

    public void SetLookAt(Transform pos);

    public GameObject GetBulletHole();

    public void SetBulletHole(GameObject gameObject);

    public HitType GetHitType(GameObject gameObject);

    public EQuadrants GetScreenPos();
}
