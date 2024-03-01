using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera cam;

    public float camRotateSpeed = 1f;

    bool isvisible = true;
    void Awake()
    {
        SetLoockedMouse();
    }
    void Update()
    {
        
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetConfinedMouse();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SetConfinedMouse();
        }
#endif

    }

    private void LateUpdate()
    {
        cameraViewControl();
    }

    void cameraViewControl()
    {
        float rotX = Input.GetAxis("Mouse Y") * camRotateSpeed;
        float rotY = Input.GetAxis("Mouse X") * camRotateSpeed;

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        cam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);
    }

    void SetLoockedMouse()
    {
        isvisible = false;
        Cursor.visible = isvisible;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void SetConfinedMouse()
    {
        isvisible = true;
        Cursor.visible = isvisible;
        Cursor.lockState = CursorLockMode.Confined;
    }

}
