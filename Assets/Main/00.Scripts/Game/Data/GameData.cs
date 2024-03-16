using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // ���߷� (��Ȯ��)    
    public float a;

    // ���� ����
    public int score;

    // ���� �ð� (���ġ)
    public float responseTime;

    public List<HitData> hitDatas;

}


[System.Serializable]
public class HitData
{
    //1. Ŭ�� �ð�
    public double clickTime;

    //2. ���� ���� 
    public bool isHit;

    //3. ȭ�� x,y ��ǥ 
    public double mousePointX;
    public double mousePointY;

    //4. Ÿ���� ������ �� �ʿ��� ������

    //4-1. ���� �ӵ� 
    public double reactionSpeed;

    //4-2. ���� �Ÿ�  
    public double distance;

    //4-3. Ÿ�� ���� ��ġ 
    public double targetVecX;
    public double targetVecY;
    public double targetVecZ;

    //4-4. Hit Type
    public HitType hitType = HitType.NONE;

    void SetMousePoint(Vector2 vec)
    {
        mousePointX = ConvertDoudle(vec.x);
        mousePointY = ConvertDoudle(vec.y);
    }

    void SetTargetVec(Vector3 vec)
    {
        targetVecX = ConvertDoudle(vec.x);
        targetVecY = ConvertDoudle(vec.y);
        targetVecZ = ConvertDoudle(vec.z);
    }

    double ConvertDoudle(float num)
    {
       return Math.Round(num, 2);
    }
    //exist Target
    public HitData(HitType hitType, Vector2 vec, Vector3 vector3,  float distance , float clickTime = 0,  float reactionSpeed = 0)
    {
        this.clickTime = ConvertDoudle(clickTime);
        this.isHit = true;
        this.distance = ConvertDoudle(distance);
        this.reactionSpeed = ConvertDoudle(reactionSpeed);
        this.hitType = hitType;

        if (vec != null)
            SetMousePoint(vec);
        if (vector3 != null)
            SetTargetVec(vector3);

#if UNITY_EDITOR || Develop
        ShowLog.targetVec = vector3;
        ShowLog.isHit = true;
        ShowLog.reactionSpeed = reactionSpeed;
        ShowLog.hitType = hitType;
        ShowLog.distance = distance;
#endif

    }
    //null Target
    public HitData(float clickTime, Vector2 vec )
    {
        this.clickTime = ConvertDoudle(clickTime);
        this.isHit = false;

        if (vec != null)
            SetMousePoint(vec);

#if UNITY_EDITOR || Develop
        ShowLog.isHit = false;
        ShowLog.hitType = this.hitType;
        ShowLog.clickTime = clickTime;
#endif

    }
}

