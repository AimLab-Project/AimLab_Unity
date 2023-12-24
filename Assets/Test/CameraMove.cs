using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera cam;

    public float camRotateSpeed = 1f;

    bool isvisible = true;
    private void Awake()
    {
       // SetMouse();
    }
    private void Update()
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

    public void SetMouse()
    {
        isvisible = !isvisible;
        Cursor.visible = isvisible;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
