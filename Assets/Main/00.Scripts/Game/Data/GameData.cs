using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // 명중률 (정확도)    
    public float a;

    // 게임 점수
    public int score;

    // 반응 시간 (평균치)
    public float responseTime;

    public List<HitData> hitDatas;

}


[System.Serializable]
public class HitData
{
    //1. 클릭 시간
    public double clickTime;

    //2. 맞춤 유무 
    public bool isHit;

    //3. 화면 x,y 좌표 
    public double mousePointX;
    public double mousePointY;

    //4. 타겟을 맞췄을 시 필요한 데이터

    //4-1. 반응 속도 
    public double reactionSpeed;

    //4-2. 벡터 거리  
    public double distance;

    //4-3. 타겟 명중 위치 
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

