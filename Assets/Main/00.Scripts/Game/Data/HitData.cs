using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HitData
{
    //1. 클릭 시간
    public double clickTime;

    //2. 맞춤 유무 
    public bool isHit;

    //3. 화면 타겟 x,y 좌표 
    public EQuadrants quadrants;

    //4. 타겟을 맞췄을 시 필요한 데이터

    //4-1. 반응 속도 
    public double reactionSpeed;

    //4-2. 벡터 거리  
    public double distance;

    //4-3. 타겟 명중 위치 
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

