using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSObject : MonoBehaviour, IFPSObject
{


    void Start()
    {
        this.gameObject.transform.LookAt(GameManager.Instance.GetPlayerPos(),Vector3.left);
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
}
