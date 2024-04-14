using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLog : MonoBehaviour
{
    //1. Ŭ�� �ð�
    public static float clickTime;

    //2. ���� ���� 
    public static bool isHit;

    //3. ȭ�� x,y ��ǥ 
    public static EQuadrants quadrants;

    //4. Ÿ���� ������ �� �ʿ��� ������

    //4-1. ���� �ӵ� 
    public static float reactionSpeed;
    //4-2. ���� �Ÿ�  
    public static float distance;
    //4-3. Ÿ�� ���� ��ġ 
    public static Vector3 targetVec;
    //4-4. Hit Type
    public static HitType hitType = HitType.NONE;

    //5. Ÿ�� �� ������ �� ������ 

#if UNITY_EDITOR

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 27;
        style.normal.textColor = Color.green;
        GUI.Label(new Rect(500,0, Screen.width, 20), "----- [Score] -----", style);
        GUI.Label(new Rect(500, 30, Screen.width, 20), "" + GameManager.Instance.GetScore(), style);

        GUI.Label(new Rect(5, 0, Screen.width, 20), "Ŭ�� �ð�" + clickTime.ToString("#.##"), style);
        GUI.Label(new Rect(5, 30, Screen.width, 20), "���� ���� " + isHit, style);
        GUI.Label(new Rect(5, 60, Screen.width, 20), "Ÿ�� ȭ�� ��ǥ "+ quadrants, style);
        
        if (isHit)
        {
            GUI.Label(new Rect(5, 90, Screen.width, 20), "----- [Ÿ�� ����] -----", style);
            GUI.Label(new Rect(5, 120, Screen.width, 20), "���� �ӵ�  " + reactionSpeed.ToString("#.##"), style);
            GUI.Label(new Rect(5, 150, Screen.width, 20), "���� �Ÿ�  " + distance, style);
            GUI.Label(new Rect(5, 180, Screen.width, 20), "Ÿ�� ���� ��ġ   ( " + targetVec.x.ToString("#.##") + "," + targetVec.y.ToString("#.##") + ","+ targetVec.z.ToString("#.##") + ")", style);
            GUI.Label(new Rect(5, 210, Screen.width, 20), "Hit Type : " + hitType, style);
        }
        /**

        if(GUI.Button(new Rect(5,250,300,20),"HitData json ��ȯ")){
            GameManager.Instance.gameDataManager.GetHitdataToJson();
        }
        if (GUI.Button(new Rect(305, 250, 300, 20), "GameResult json ��ȯ"))
        {
            GameManager.Instance.gameDataManager.GetResultdataToJson();
        }
        **/
    }

#endif

}
 


