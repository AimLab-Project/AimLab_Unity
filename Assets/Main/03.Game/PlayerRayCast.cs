using UnityEngine;
public enum HitType
{
    HEAD = 100,
    BODY = 101,
    FOOT = 102,
    ONE = 1,
    TWO = 2,
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6,
    SEVEN = 7,
    EIGHT = 8,
    NINE = 9,
    TEN = 10
}

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField]
    GameObject bulletHolePrefab;


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
            if (hitInfo.transform.gameObject.tag == "Object")
            {
                //Todo : 게임 매니저 단으로 넘어가야함. 
                IFPSObject hitObjInfo = hitInfo.transform.gameObject.GetComponent<IFPSObject>();
                CreateBulletHole(hitInfo);
                GameManager.Instance.GetCurGameManager().SaveHitInfo(hitObjInfo);
            }
            else if(hitInfo.transform.gameObject.tag == "ChildObject")
            {
                IFPSObject hitObjInfo = hitInfo.transform.gameObject.GetComponentInParent<IFPSObject>();
                CreateBulletHole(hitInfo);
                GameManager.Instance.GetCurGameManager().SaveHitInfo(hitObjInfo);
            }

            Debug.Log("hit!" + hitInfo.transform.gameObject.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }

    }

    void CreateBulletHole(RaycastHit hitInfo)
    {
        GameObject obj = Instantiate(bulletHolePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal),hitInfo.transform.parent);
        Vector3 temp = obj.transform.localPosition;
        temp.z = -0.3f;
        obj.transform.localPosition = temp;
        
        obj.transform.position += obj.transform.forward /1000;
        Debug.Log("obj.transform.position !" + obj.transform.position);
        //Changing the bullet hole's position a bit so it will fit better
    }
}

