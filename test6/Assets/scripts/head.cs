using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class head : MonoBehaviour
{
    public Transform playerBody;
    public float sens = 1;
    public int CurAmmo = 31; 
    float xRotation = 0;
    public bool CanMove = true;

    bool isReloading = false;

    public Text AmmoText; 
    // Start is called before the first frame update
    void Start()
    {
        ShowAmmo();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowAmmo()  
    {
        AmmoText.text = CurAmmo.ToString();  
    } 

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * sens;
            float mouseY = Input.GetAxis("Mouse Y") * sens;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -40, 40);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);

            if (Input.GetKeyDown(KeyCode.Mouse0)&&CurAmmo>0)
            {
                CurAmmo -= 1;
                ShowAmmo();

                RaycastHit hit; 
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    Debug.Log(hit.transform.name);
                    enemy that_enemy = hit.transform.GetComponent<enemy>();
                    if (that_enemy)
                    {


                        //that_enemy.Die();//Shot on dog
                        that_enemy.Damage(10);//Shot on dog




                    }
                }
            }
        }

    }
}
