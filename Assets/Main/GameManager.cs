using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;

[RequireComponent(typeof(WebGLSceneManager), typeof(GameDataManager))]
public class GameManager : Singleton<GameManager>
{

    //public IFPSGame[] fPSGames;

    IFPSGame curGame;

    CameraMove player;

    float gameTime = 60f;
    float curGameTime;

    Coroutine gameRoutine;

    ShowLog showLog;

    int score;

    private GameDataManager _gameDataManager;
    public GameDataManager gameDataManager
    {
        get
        {
            if(_gameDataManager == null)
            {
                _gameDataManager = GetComponent<GameDataManager>();
            }

            return _gameDataManager;
        }
        private set
        {
            _gameDataManager = value;
        }
    }


    public void SetGame(IFPSGame game)
    {
        curGame = game;
    }

#pragma warning disable CS4014
    public void MoveScene(string name)
    {
        WebGLSceneManager.Instance.LoadSceneCallback(name, () => {
            InitGame();
        });
    }

    protected override void InternalAwake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                MoveScene("ShootingGame");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                MoveScene("Main");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopGame();
            }
        }
    }

    private void InitGame()
    {
        //find IFPSGame Interface
        score = 0;
        GameObject scriptManager = GameObject.Find("ScriptManager");
        Component[] components = scriptManager.GetComponents<Component>();

        foreach (Component component in components)
        {
            IFPSGame temp = component as IFPSGame;
            if (temp != null)
            {
                curGame = temp;
                player = FindFirstObjectByType<CameraMove>();
                curGameTime = 0f;
            }
                
        }

        if (curGame == null)
            Debug.LogError("cur Game Empty");

#if UNITY_EDITOR
      showLog = this.gameObject.AddComponent<ShowLog>();
#endif

    }

    private void StartGame()
    {
        if (curGame == null && gameRoutine == null)
        {
            InitGame();
        }

        curGame.StartGame();
        gameRoutine = StartCoroutine(CoGameCountDown());
    }

    private void StopGame()
    {
        if (curGame != null)
        {
            curGame.StopGame();
           // curGame = null;
            gameRoutine = null;
        }
    }

    public IFPSGame GetCurGameManager()
    {
        if (curGame != null)
            return curGame;

        return null;
    }

    public Transform GetPlayerPos()
    {
        return player.gameObject.transform;
    }

    IEnumerator CoGameCountDown()
    {
        WaitForSecondsRealtime time = new WaitForSecondsRealtime(0.01f);

        while(curGameTime <= gameTime)
        {
            yield return time;
            curGameTime += 0.01f;
            //Debug.Log("gameTime" + curGameTime);
        }
        yield return null;
        StopGame();
    }

    public float GetCurTime()
    {
        return curGameTime;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(HitType type)
    {
        switch (type)
        {
            case HitType.NONE:
                score += 0;
                break;
            case HitType.HEAD:
                score += 1000;
                break;
            case HitType.BODY:
                score += 500;
                break;
            case HitType.FOOT:
                score += 100;
                break;
            case HitType.ZERO:
                score += 0;
                break;
            case HitType.ONE:
                score += 100;
                break;
            case HitType.TWO:
                score += 200;
                break;
            case HitType.THREE:
                score += 300;
                break;
            case HitType.FOUR:
                score += 400;
                break;
            case HitType.FIVE:
                score += 500;
                break;
            case HitType.SIX:
                score += 600;
                break;
            case HitType.SEVEN:
                score += 700;
                break;
            case HitType.EIGHT:
                score += 800;
                break;
            case HitType.NINE:
                score += 900;
                break;
            case HitType.TEN:
                score += 1000;
                break;
        }
    }

}
