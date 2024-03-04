using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] tempObjs;
    List<GameObject> objs;
    Transform centerPos;

    [Tooltip("RandomRange")]
    public int[] rangeX;
    public int[] rangeZ;

    void Start()
    {
        Init();
        StartCoroutine(test(1f));
    }

    void Init()
    {
        objs = new List<GameObject>();
        centerPos = this.transform;
    }

    IEnumerator test(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Spawn();
        }
    }



    void Spawn()
    {
        int spawnNum = 0; 
        if(tempObjs.Length > 1)
        {
            spawnNum = Random.Range(0, tempObjs.Length - 1);
        }
        else
        {
            Debug.LogError("temp Obj is Null!");
        }

        float posX = Random.Range((centerPos.position.x - rangeX[0]), (centerPos.position.x + rangeX[1]));
        float posZ = Random.Range((centerPos.position.z - rangeZ[0]), (centerPos.position.z + rangeZ[1]));

        Vector3 spawnPos = new Vector3(posX, 0, posZ);

        GameObject instance = Instantiate(tempObjs[spawnNum], spawnPos, Quaternion.identity);
        objs.Add(instance);
    }
    /**
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, this.transform.localRotation * Vector3.right * rangeX[1]);
        Gizmos.DrawRay(this.transform.position, this.transform.localRotation * Vector3.left * rangeX[0]);
        Gizmos.DrawRay(this.transform.position, this.transform.localRotation * Vector3.forward * rangeZ[1]);

    }
    **/
}
