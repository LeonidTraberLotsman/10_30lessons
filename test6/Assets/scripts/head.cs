using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    public Transform playerBody;
    public float sens = 1;
    float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* sens;
        float mouseY = Input.GetAxis("Mouse Y")* sens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -40, 40);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up* mouseX);


    }
}
