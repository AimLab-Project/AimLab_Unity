using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;
public class ShootingGameManager : MonoBehaviour, IFPSGame
{
    GAME_TYPE type = GAME_TYPE.SHOOTING;

    [Space]
    [Header("[Game Setting]")]
    [Range(0.0f,60.0f)]
    public float delay = 0.5f;
    public static bool IsGame { get; set; }

    SpawnManager spawnManager;

    Coroutine gameCo;
    
    [Space]
    [Header("[Shoot Redult]")]
    [SerializeField]
    Transform resultShowPos;
    [SerializeField]
    GameObject resultTarget;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        if(spawnManager == null)
            spawnManager = FindObjectOfType<SpawnManager>();
    }

    public bool CheckType(GAME_TYPE type)
    {
        if (this.type == type)
            return true;

        return false;
    }

    public IEnumerator CoStartGame()
    {
        yield return null; 

        StartCoroutine(spawnManager.CoSpawn(delay));
    }

    public void StartGame()
    {
        IsGame = true;
        gameCo = StartCoroutine(CoStartGame());
    }

    public void StopGame()
    {
        IsGame = false;
        if(gameCo != null)
        {
            StopCoroutine(gameCo);
            gameCo = null;
        }
    }
    public void SaveHitInfo(IFPSObject hitobj)
    {
        //GameObject temp = hitobj.GetTargetObject();

        // temp.transform.position = resultShowPos.position;
        //  temp.transform.localScale = new Vector3(-2f, -2f, -2f);
        // temp.transform.eulerAngles = Vector3.left;

        Vector3 localTempPos = hitobj.GetBulletHole().transform.localPosition;
        hitobj.GetBulletHole().transform.parent = resultTarget.transform;
        hitobj.GetBulletHole().transform.localPosition = localTempPos;
        hitobj.GetBulletHole().transform.eulerAngles = Vector3.left;

        //To Do (1001) : Save the Bullet Hole Object and Checking System.

        Destroy(hitobj.GetTargetObject());
        //To Do (1002) : Create Object Pool


        spawnManager.StartSpawn();
    }
}
