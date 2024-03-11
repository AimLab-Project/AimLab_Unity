using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;

public class FPSObject : MonoBehaviour, IFPSObject
{
    GameObject bulletHole;

    void Start()
    {
        //this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
        this.gameObject.transform.LookAt(GameManager.Instance.GetPlayerPos());
        transform.Rotate(Vector3.up, 180.0f);
    }


    public int CheckTime()
    {
        return 0;
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

        Debug.LogError("already set bulletHole" + bulletHole.name + "/" + gameObject.name);
    }
}
