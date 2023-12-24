using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
