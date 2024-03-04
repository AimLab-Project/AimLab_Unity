using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public IFPSGame[] fPSGames;

    IFPSGame curGame;


    public void SetGame(IFPSGame game)
    {
        curGame = game;
    }

    public void MoveScene(string name)
    {
        WebGLSceneManager.Instance.LoadScene(name);
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
                WebGLSceneManager.Instance.LoadScene("ForTest");
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                WebGLSceneManager.Instance.LoadScene("Main");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }

    private void StartGame()
    {
        if (curGame != null)
            curGame.StartGame();
    }

    private void StopGame()
    {
        if (curGame != null)
            curGame.StartGame();
    }
}
