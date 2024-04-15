using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HitData
{
    //1. Ŭ�� �ð�
    public double clickTime;

    //2. ���� ���� 
    public bool isHit;

    //3. ȭ�� Ÿ�� x,y ��ǥ 
    public EQuadrants quadrants;

    //4. Ÿ���� ������ �� �ʿ��� ������

    //4-1. ���� �ӵ� 
    public double reactionSpeed;

    //4-2. ���� �Ÿ�  
    public double distance;

    //4-3. Ÿ�� ���� ��ġ 
    public double[] targetVec;

    //4-4. Hit Type
    public HitType hitType = HitType.NONE;

    void SetTargetVec(Vector3 vec)
    {
        targetVec = new double[3] { ConvertDoudle(vec.x), ConvertDoudle(vec.y), ConvertDoudle(vec.z) };
    }

    double ConvertDoudle(float num)
    {
        return Math.Round(num, 2);
    }
    //exist Target
    public HitData(HitType hitType, EQuadrants quadrants, Vector3 vector3, float distance, float clickTime = 0, float reactionSpeed = 0)
    {
        this.clickTime = ConvertDoudle(clickTime);
        this.isHit = true;
        this.distance = ConvertDoudle(distance);
        this.reactionSpeed = ConvertDoudle(reactionSpeed);
        this.hitType = hitType;
        this.quadrants = quadrants;

        if (vector3 != null)
            SetTargetVec(vector3);

#if UNITY_EDITOR || Develop
        ShowLog.targetVec = vector3;
        ShowLog.isHit = true;
        ShowLog.reactionSpeed = reactionSpeed;
        ShowLog.hitType = hitType;
        ShowLog.distance = distance;
        ShowLog.quadrants = quadrants;
#endif

    }
    //null Target
    public HitData(float clickTime, EQuadrants eQuadrants)
    {
        this.clickTime = ConvertDoudle(clickTime);
        this.quadrants = eQuadrants;
        this.isHit = false;

#if UNITY_EDITOR || Develop
        ShowLog.isHit = false;
        ShowLog.hitType = this.hitType;
        ShowLog.clickTime = clickTime;
        ShowLog.quadrants = quadrants;
#endif

    }
}

