using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    Coroutine game; // 각 게임 코루틴 저장 

    public IFPSGame[] fPSGames; 

    public void SetGame(Coroutine game)
    {
        this.game = game;
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            WebGLSceneManager.Instance.LoadScene("ForTest");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            WebGLSceneManager.Instance.LoadScene("Main");
        }

    }
}
