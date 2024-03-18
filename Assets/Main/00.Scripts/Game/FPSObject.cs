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
        // ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);


        // ��ũ�� ���� �߽����� x ��ǥ
        float screenWidth = Screen.width;
        float screenCenterX = screenWidth / 2f;

        // ��ũ�� ���� �߽����� y ��ǥ
        float screenHeight = Screen.height;
        float screenCenterY = screenHeight / 2f;

        // ������ ���� ��ġ�ϴ� ���
        if (screenPos.x > screenCenterX && screenPos.y > screenCenterY)
        {
            Debug.Log("������ ���� �ֽ��ϴ�.");
            type = EQuadrants.TOPRIGHT;
        }
        // ���� ���� ��ġ�ϴ� ���
        else if (screenPos.x <= screenCenterX && screenPos.y > screenCenterY)
        {
            Debug.Log("���� ���� �ֽ��ϴ�.");
            type = EQuadrants.TOPRIGHT;
        }
        // ���� �Ʒ��� ��ġ�ϴ� ���
        else if (screenPos.x <= screenCenterX && screenPos.y <= screenCenterY)
        {
            Debug.Log("���� �Ʒ��� �ֽ��ϴ�.");
            type = EQuadrants.BOTTOMLEFT;
        }
        // ������ �Ʒ��� ��ġ�ϴ� ���
        else if (screenPos.x > screenCenterX && screenPos.y <= screenCenterY)
        {
            Debug.Log("������ �Ʒ��� �ֽ��ϴ�.");
            type = EQuadrants.BOTTOMRIGHT;
        }
    }
}
