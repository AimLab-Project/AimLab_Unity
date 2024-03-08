using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;
public class ShootingGameManager : MonoBehaviour, IFPSGame
{
    GAME_TYPE type = GAME_TYPE.SHOOTING;

    [Header("Game Setting")]
    [Range(0.0f,60.0f)]
    public float delay = 3f;
    public static bool IsGame { get; set; }

    SpawnManager spawnManager;

    Coroutine gameCo;

    [Header("Shoot Redult")]
    [SerializeField]
    Transform resultShowPos;

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
        GameObject temp = hitobj.GetTargetObject();

        temp.transform.parent = resultShowPos;
        temp.transform.position = resultShowPos.position;
        // hitobj.SetLookAt(Vector3.zero);
        //temp.transform.rotation = Quaternion.Euler(0, 0f, 0);
    }
}
