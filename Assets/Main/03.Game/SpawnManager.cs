using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] tempObjs;
    Transform centerPos;

    [Header("RandomRange")]
    public int[] rangeX;
    public int[] rangeZ;

    GameObject spawnMother;

    void Init()
    {
        centerPos = this.transform;

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
            yield return waitTime;
            Spawn();
        }
    }

    void Spawn()
    {
        int spawnNum = 0; 
        if(tempObjs.Length > 0)
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
        Instantiate(tempObjs[spawnNum], spawnPos, Quaternion.identity, spawnMother.transform);
    }


    public void DestroySpawnObj()
    {
        GameObject.Destroy(spawnMother);
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
