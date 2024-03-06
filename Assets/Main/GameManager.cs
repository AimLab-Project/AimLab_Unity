using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = Project.Utils.Debug;
public class GameManager : Singleton<GameManager>
{

    //public IFPSGame[] fPSGames;

    IFPSGame curGame;


    public void SetGame(IFPSGame game)
    {
        curGame = game;
    }

    public void MoveScene(string name)
    {
        WebGLSceneManager.Instance.LoadSceneCallback(name, () => {
            InitGame();
        });
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
                WebGLSceneManager.Instance.LoadScene("Main");
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
                curGame = temp;
        }

        if (curGame == null)
            Debug.LogError("cur Game Empty");
    }

    private void StartGame()
    {
        if (curGame != null)
        { 
            curGame.StartGame();
        }
        else
        {
            InitGame();
            curGame.StartGame();
        }
    }

    private void StopGame()
    {
        if (curGame != null)
        {
            curGame.StopGame();
            curGame = null;
        }
            
    }
}