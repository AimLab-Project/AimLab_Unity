using UnityEngine;
public enum HitType
{
    NONE = 0,
    HEAD = 100,
    BODY = 101,
    FOOT = 102,
    ZERO = 200,
    ONE = 201,
    TWO = 202,
    THREE = 203,
    FOUR = 204,
    FIVE = 205,
    SIX = 206,
    SEVEN = 207,
    EIGHT = 208,
    NINE = 209,
    TEN = 210
}

//[Todo] : ������� ���콺�� ������Ʈ�� ������ ���� �� ȭ�鿡 ���̴� ������Ʈ ��ġ�� ������� ���ϴ� ��ũ��Ʈ �ۼ� �� ��. 
//[Todo] : ���� �ý��� �߰� 
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
            HitType hitType = HitType.NONE;
            if (hitInfo.transform.gameObject.tag == "Object")
            {
                IFPSObject hitObjInfo = hitInfo.transform.gameObject.GetComponent<IFPSObject>();
                hitObjInfo.SetBulletHole(CreateBulletHole(hitInfo));
                CreateHitEffect(hitInfo);
                temp.SaveHitInfo(hitObjInfo);
            }
            else if (hitInfo.transform.gameObject.tag == "ChildObject")
            {
                Transform parent = hitInfo.transform.gameObject.transform.parent;
                IFPSObject hitObjInfo  = parent.GetComponent<IFPSObject>();

                hitObjInfo.SetBulletHole(CreateBulletHole(hitInfo));
                hitType =  hitObjInfo.GetHitType(hitInfo.transform.gameObject);
                CreateHitEffect(hitInfo);
                temp.SaveHitInfo(hitObjInfo);
                float distance = Vector3.Distance(this.gameObject.transform.parent.position, parent.localPosition);
                HitData hitdata = new HitData(hitType, hitObjInfo.GetScreenPos() , hitInfo.transform.position,distance,GameManager.Instance.GetCurTime(), hitObjInfo.CheckTime());
                GameManager.Instance.gameDataManager.SetHitData(hitdata);
            }
            else
            {
                Debug.Log("hit!" + hitInfo.transform.gameObject.name);
                HitData hitdata = new HitData(GameManager.Instance.GetCurTime());
                GameManager.Instance.gameDataManager.SetHitData(hitdata);
            }

            GameManager.Instance.SetScore(hitType);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

        }
        else
        {
            ShowLog.isHit = false;
            HitData hitdata = new HitData(GameManager.Instance.GetCurTime());
            GameManager.Instance.gameDataManager.SetHitData(hitdata);
        }

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

