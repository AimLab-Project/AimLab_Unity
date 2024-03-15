using UnityEngine;
public enum HitType
{
    NONE = 0,
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

    [SerializeField]
    GameObject hitEffect;

    Camera camera;

    private void Start()
    {
        camera = GetComponentInChildren<Camera>();
        if (!camera)
            camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
#if UNITY_EDITOR        
            ShowLog.clickTime = GameManager.Instance.GetCurTime();
#elif Develop
            ShowLog.clickTime = GameManager.Instance.GetCurTime();
#endif
        }
    }

    void CheckHitObj()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        IFPSGame temp = GameManager.Instance.GetCurGameManager();

        if (Physics.Raycast(ray, out hitInfo, 10000))
        {
            if (hitInfo.transform.gameObject.tag == "Object")
            {
                IFPSObject hitObjInfo = hitInfo.transform.gameObject.GetComponent<IFPSObject>();
                hitObjInfo.SetBulletHole(CreateBulletHole(hitInfo));
                CreateHitEffect(hitInfo);
                temp.SaveHitInfo(hitObjInfo);

                // ShowLog
#if UNITY_EDITOR || Develop
                ShowLog.targetVec = hitInfo.transform.position;
                ShowLog.isHit = true;
#endif
            }
            else if (hitInfo.transform.gameObject.tag == "ChildObject")
            {
                IFPSObject hitObjInfo = hitInfo.transform.gameObject.GetComponentInParent<IFPSObject>();
                hitObjInfo.SetBulletHole(CreateBulletHole(hitInfo));
                CreateHitEffect(hitInfo);
                temp.SaveHitInfo(hitObjInfo);

#if UNITY_EDITOR || Develop
                ShowLog.targetVec = hitInfo.transform.position;
                ShowLog.isHit = true;
#endif
            }
            else
            {
                Debug.Log("hit!" + hitInfo.transform.gameObject.name);
            }
         

          
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            ShowLog.isHit = false;
        }
        Vector3 point = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                  Input.mousePosition.y, -Camera.main.transform.position.z));

        Vector3 point2 = camera.WorldToScreenPoint(hitInfo.point);

        Debug.Log("point" + point);
        Debug.Log("point2" + point2);
    }

    GameObject CreateBulletHole(RaycastHit hitInfo)
    {
        GameObject obj = Instantiate(bulletHolePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal),hitInfo.transform.parent);
        Vector3 temp = obj.transform.localPosition;
        temp.z = -0.3f;
        obj.transform.localPosition = temp;
        
        obj.transform.position += obj.transform.forward /1000;
        Debug.Log("obj.transform.position !" + obj.transform.position);
        //Changing the bullet hole's position a bit so it will fit better

        return obj;
    }

    void CreateHitEffect(RaycastHit hitInfo)
    {        
        //To Do (1002) : Add Object Pool
        GameObject obj = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
    }
}

