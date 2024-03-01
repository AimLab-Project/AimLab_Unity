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
        //시선 (ray를 쏘는 위치, 쏘는 방향)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //닿은 곳의 정보
        RaycastHit hitInfo;
        //바라본다
        //Raycast는 기본적으로 bool형을 반환하게 된다. 그런데 인자 값에 out형으로 인자하나를 더 반환하게 된다.
        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            //닿았다 (Raycast가 true일때)
            if (hitInfo.transform.gameObject.tag == "Object")
            {
                Destroy(hitInfo.transform.gameObject);
            }
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }

        /**

          // 레이어 마스크를 사용하여 원하는 충돌 대상만 필터링합니다.
int layerMask = LayerMask.GetMask("Enemy", "Obstacle");
if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
{
    // 충돌한 오브젝트의 이름을 디버그 로그에 출력합니다.
    Debug.Log("충돌한 오브젝트: " + hit.collider.name);
    
    // 레이캐스트의 시작점부터 충돌 지점까지 빨간색으로 선을 그려 시각화합니다.
    Debug.DrawLine(transform.position, hit.point, Color.red);
}

// 한 번에 여러 충돌을 감지하기 위해 Physics.RaycastAll() 메서드를 사용합니다.
RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity, layerMask);
foreach (RaycastHit hit in hits)
{
    // 각 충돌한 오브젝트의 이름을 디버그 로그에 출력합니다.
    Debug.Log("충돌한 오브젝트: " + hit.collider.name);
    
    // 레이캐스트의 시작점부터 충돌 지점까지 파란색으로 선을 그려 시각화합니다.
    Debug.DrawLine(transform.position, hit.point, Color.blue);
}
         **/
    }
}
