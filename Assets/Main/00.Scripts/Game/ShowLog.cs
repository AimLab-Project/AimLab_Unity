using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLog : MonoBehaviour
{
    //1. 클릭 시간
    public static float clickTime;

    //2. 맞춤 유무 
    public static bool isHit;

    //3. 화면 x,y 좌표 
    public static Vector2 mousePoint;

    //4. 타겟을 맞췄을 시 필요한 데이터

    //4-1. 반응 속도 
    public static float reactionSpeed;
    //4-2.벡터 거리  
    public static float distance;
    //4-3. 타겟 명중 위치 
    public static Vector3 targetVec;
    //4-4. 헤드샷 유무 
    public static HitType hitType = HitType.NONE;

    //5.타겟 못 맞췄을 시 데이터 


    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 27;
        style.normal.textColor = Color.green;

        GUI.Label(new Rect(5, 0, Screen.width, 20), "클릭 시간" + clickTime.ToString("#.##"), style);
        GUI.Label(new Rect(5, 30, Screen.width, 20), "맞춤 유무 " + isHit, style);
        GUI.Label(new Rect(5, 60, Screen.width, 20), "화면 x,y 좌표 ( " + mousePoint.x + "," + mousePoint.y+")", style);
        
        if (isHit)
        {
            GUI.Label(new Rect(5, 90, Screen.width, 20), "----- [타겟 정보] -----", style);
            GUI.Label(new Rect(5, 120, Screen.width, 20), "반응 속도  " + reactionSpeed, style);
            GUI.Label(new Rect(5, 150, Screen.width, 20), "벡터 거리  " + distance, style);
            GUI.Label(new Rect(5, 180, Screen.width, 20), "타겟 명중 위치   ( " + targetVec.x + "," + targetVec.y + ","+ targetVec.z + ")", style);
            GUI.Label(new Rect(5, 210, Screen.width, 20), "Hit Type" + hitType, style);
        }
    }
}
