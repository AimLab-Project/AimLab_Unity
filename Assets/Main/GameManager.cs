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
        if (curGame != null && gameRoutine == null)
        { 
            curGame.StartGame();
            gameRoutine = StartCoroutine(CoGameCountDown());
        }
        else
        {
            InitGame();
        }
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

}
