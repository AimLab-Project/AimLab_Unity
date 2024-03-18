using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;

public class FPSObject : MonoBehaviour, IFPSObject
{
    GameObject bulletHole;

    EQuadrants type;

    float time;
    bool isStop = true ;



    void Start()
    {
        //this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
        this.gameObject.transform.LookAt(GameManager.Instance.GetPlayerPos());
        transform.Rotate(Vector3.up, 180.0f);
        SetScreenPos();
        StartCoroutine(CoCheckTime());
    }

    public float CheckTime()
    {
        isStop = false;
        return time;
    }

    IEnumerator CoCheckTime()
    {
        WaitForSeconds wTime = new WaitForSeconds(0.01f);
        while (isStop)
        {
            yield return wTime;
            time += 0.01f;
        }
        yield return null;
    }

    public float GetDistancePlayer()
    {
        return 0f;
    }

    public GameObject GetTargetObject()
    {
        return this.gameObject;
    }

    public void SetLookAt(Transform pos)
    {
        this.gameObject.transform.LookAt(pos.position, new Vector3(-1,-1,-1));
    }

    public GameObject GetBulletHole()
    {
        if (bulletHole)
            return bulletHole;

        return null;
    }

    public void SetBulletHole(GameObject gameObject)
    {
        if (!bulletHole)
            bulletHole = gameObject;
        else 
            Debug.LogError("already set bulletHole" + bulletHole.name + "/" + gameObject.name);
    }

    public HitType GetHitType(GameObject gameObject)
    {
        FPSChildObject childTemp = gameObject.GetComponent<FPSChildObject>();
        if (childTemp)
            return childTemp.GetHitType();
        else
            return HitType.NONE;
    }
    public EQuadrants GetScreenPos()
    {
        return type;
    }

    public void SetScreenPos()
    {
        // 월드 좌표를 스크린 좌표로 변환
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);


        // 스크린 가로 중심점의 x 좌표
        float screenWidth = Screen.width;
        float screenCenterX = screenWidth / 2f;

        // 스크린 세로 중심점의 y 좌표
        float screenHeight = Screen.height;
        float screenCenterY = screenHeight / 2f;

        // 오른쪽 위에 위치하는 경우
        if (screenPos.x > screenCenterX && screenPos.y > screenCenterY)
        {
            Debug.Log("오른쪽 위에 있습니다.");
            type = EQuadrants.TOPRIGHT;
        }
        // 왼쪽 위에 위치하는 경우
        else if (screenPos.x <= screenCenterX && screenPos.y > screenCenterY)
        {
            Debug.Log("왼쪽 위에 있습니다.");
            type = EQuadrants.TOPRIGHT;
        }
        // 왼쪽 아래에 위치하는 경우
        else if (screenPos.x <= screenCenterX && screenPos.y <= screenCenterY)
        {
            Debug.Log("왼쪽 아래에 있습니다.");
            type = EQuadrants.BOTTOMLEFT;
        }
        // 오른쪽 아래에 위치하는 경우
        else if (screenPos.x > screenCenterX && screenPos.y <= screenCenterY)
        {
            Debug.Log("오른쪽 아래에 있습니다.");
            type = EQuadrants.BOTTOMRIGHT;
        }
    }
}
