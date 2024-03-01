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
        //�ü� (ray�� ��� ��ġ, ��� ����)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //���� ���� ����
        RaycastHit hitInfo;
        //�ٶ󺻴�
        //Raycast�� �⺻������ bool���� ��ȯ�ϰ� �ȴ�. �׷��� ���� ���� out������ �����ϳ��� �� ��ȯ�ϰ� �ȴ�.
        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            //��Ҵ� (Raycast�� true�϶�)
            if (hitInfo.transform.gameObject.tag == "Object")
            {
                Destroy(hitInfo.transform.gameObject);
            }
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }

        /**

          // ���̾� ����ũ�� ����Ͽ� ���ϴ� �浹 ��� ���͸��մϴ�.
int layerMask = LayerMask.GetMask("Enemy", "Obstacle");
if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
{
    // �浹�� ������Ʈ�� �̸��� ����� �α׿� ����մϴ�.
    Debug.Log("�浹�� ������Ʈ: " + hit.collider.name);
    
    // ����ĳ��Ʈ�� ���������� �浹 �������� ���������� ���� �׷� �ð�ȭ�մϴ�.
    Debug.DrawLine(transform.position, hit.point, Color.red);
}

// �� ���� ���� �浹�� �����ϱ� ���� Physics.RaycastAll() �޼��带 ����մϴ�.
RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity, layerMask);
foreach (RaycastHit hit in hits)
{
    // �� �浹�� ������Ʈ�� �̸��� ����� �α׿� ����մϴ�.
    Debug.Log("�浹�� ������Ʈ: " + hit.collider.name);
    
    // ����ĳ��Ʈ�� ���������� �浹 �������� �Ķ������� ���� �׷� �ð�ȭ�մϴ�.
    Debug.DrawLine(transform.position, hit.point, Color.blue);
}
         **/
    }
}
