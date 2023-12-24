using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;
using System.Runtime.InteropServices;
public class TestBridge : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void CallReactMessage(string message);

    [DllImport("__Internal")]
    private static extern void CallReactScore(int score);


    [SerializeField]
    CameraMove cameraMove;


    
    public void MoveMainScene()
    {
        WebGLSceneManager.Instance.LoadScene("Main");
    }

    public void SetNumber(int num)
    {
       // testObj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
    }


   
    public void SetSensitivity(float degree)
    {
        cameraMove.camRotateSpeed = degree;
    }

    public void SendMessageToWeb(string message)
    {
        //OnMessageReceived.Invoke(message);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CallReactMessage(message);
#endif
        Debug.Log(message);
    }
}
