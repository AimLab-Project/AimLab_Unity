using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFPSObject 
{
    //������Ʈ ���� ������ ���� �������̽� 
    public int CheckTime(); //return. ���� �� ������ �ð�.
    public float GetDistancePlayer(); // ������ ������Ʈ �� �Ÿ�. 

    public GameObject GetTargetObject();

    public void SetLookAt(Transform pos);
}
