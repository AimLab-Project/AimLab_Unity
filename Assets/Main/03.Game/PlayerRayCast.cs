using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitType
{

}


public class PlayerRayCast : MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
        }
       
    }

    void CheckHitObj()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 10000))
        {
            //닿았다 (Raycast가 true일때)
            if (hitInfo.transform.gameObject.tag == "Object")
            {
                //Todo : 게임 매니저 단으로 넘어가야함. 
                Destroy(hitInfo.transform.gameObject);
            }
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }

    }
}
