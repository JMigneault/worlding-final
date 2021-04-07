using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float speed = 1.0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        float rotateValue = Input.GetAxis("Mouse X") * speed;
        transform.Rotate(Vector3.up, rotateValue);
    }
}
