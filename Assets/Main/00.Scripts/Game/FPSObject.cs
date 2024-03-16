using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;

public class FPSObject : MonoBehaviour, IFPSObject
{
    GameObject bulletHole;

    float time;
    bool isStop = true ;



    void Start()
    {
        //this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
        this.gameObject.transform.LookAt(GameManager.Instance.GetPlayerPos());
        transform.Rotate(Vector3.up, 180.0f);
   
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
}
