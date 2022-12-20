using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{   
    [Header("Чувствительность мыши")]
     
    public float sensitivityMouse = 200f;
    public Transform Player;

    public bool active = true;

    float xRotation = 0;

    private void Start()
    {
        Cursor. lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (active)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivityMouse;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse;

            xRotation = xRotation - mouseY;
            xRotation = Mathf.Clamp(xRotation, -40, 40);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            Player.Rotate(Vector3.up * mouseX);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    Debug.Log(hit.transform.name);
                    enemy that_enemy = hit.transform.GetComponent<enemy>();
                    if (that_enemy)
                    {
                        Debug.Log("hit");
                        that_enemy.Damage(35);
                    }
                }
            }
        }
    }
}