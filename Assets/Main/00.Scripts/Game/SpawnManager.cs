using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Debug = Project.Utils.Debug;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] tempObjs;

    public Transform center; // ��ä���� �߽�

    [SerializeField]
    [Range(0.0f,100.0f)]
    float radius = 5f; // ��ä���� ������

    [SerializeField]
    [Range(0f,360f)]
    float angle = 90f; // ��ä���� ���� (�� ����)


    GameObject spawnMother;

    bool doSpawn;

    void Init()
    {
        center = this.transform;

        if (!spawnMother)
        {
            spawnMother = Instantiate(new GameObject());
            spawnMother.name = "SpawnMother";
        }
    }

    public IEnumerator CoSpawn(float delay)
    {
        Init();

        WaitForSeconds waitTime = new WaitForSeconds(delay);

        while (ShootingGameManager.IsGame)
        {
            doSpawn = false;
            GameObject temp =  Spawn();
            yield return new WaitUntil(() => doSpawn);
            yield return waitTime;
        }
    }

    public GameObject Spawn()
    {
        int spawnNum = 0; 
        if(tempObjs.Length > 0)
        {
            spawnNum = Random.Range(0, tempObjs.Length);
        }
        else
        {
            Debug.LogError("temp Obj is Null!");
        }

        // float posX = Random.Range((centerPos.position.x - rangeX[0]), (centerPos.position.x + rangeX[1]));
        // float posY = Random.Range(3f , rangeY);
        //  float posZ = Random.Range((centerPos.position.z - rangeZ[0]), (centerPos.position.z + rangeZ[1]));

        //   Vector3 spawnPos = new Vector3(posX, posY, posZ);
       GameObject temp = Instantiate(tempObjs[spawnNum], GenerateRandomPositionInFanShape(), Quaternion.identity, spawnMother.transform);

       return temp;
    }

    Vector3 GenerateRandomPositionInFanShape()
    {
        // ��ä���� �߽� ��ġ
        Vector3 center = this.center.position;

        // ��ä���� ���� ������ �� ����
        float startAngle = -angle / 2f;
        float endAngle = angle / 2f;

        // ������ ������ ����
        float randomAngle = Random.Range(startAngle, endAngle);

        // ������ �Ÿ��� ����
        float randomRadius = Random.Range(0f, radius);

        // ������ ��ġ ���
        Vector3 randomPosition = center + Quaternion.Euler(0, randomAngle, 0) * Vector3.forward * randomRadius;

        return randomPosition;
    }

    public void DestroySpawnMotherObj()
    {
        GameObject.Destroy(spawnMother);
    }

    public void DestroySpawnChildObj()
    {
        GameObject[] children = spawnMother.GetComponentsInChildren<GameObject>();
        if (children.Length > 0)
        {
            for(int i = 0; i < children.Length; i++)
            {
                Destroy(children[i]);
            }
        }
    }
    
    public Transform GetMotherObj()
    {
        return spawnMother.transform;
    }

    public void StartSpawn()
    {
        doSpawn = true;
    }



    void OnDrawGizmos()
    {
        Handles.color = Color.yellow;

        // ��ä���� �߽� ��ġ
        Vector3 center = this.center.position;

        // ��ä���� ���� ������ �� ����
        float startAngle = -angle / 2f;
        float endAngle = angle / 2f;

        // ��ä���� ������

        Handles.DrawWireArc(center, Vector3.up, Quaternion.Euler(0, startAngle, 0) * Vector3.forward, angle, radius);

        Vector3 startPos = center + Quaternion.Euler(0, startAngle, 0) * Vector3.forward * radius;
        Vector3 endPos = center + Quaternion.Euler(0, endAngle, 0) * Vector3.forward * radius;
        Handles.DrawLine(center, startPos);
        Handles.DrawLine(center, endPos);
    }

}
