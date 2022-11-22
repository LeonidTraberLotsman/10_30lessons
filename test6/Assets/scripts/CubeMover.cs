using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMover : MonoBehaviour
{
    public int hp = 100;
    public Text HPtext;


    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        ShowHP();
        body = GetComponent<Rigidbody>();
    }


    public void ShowHP()
    {
        HPtext.text = hp.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.forward*50);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(-transform.forward * 50);

        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(transform.right * 50);

        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(-transform.right * 50);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            body.AddForce(transform.up * 500);

        }
    }
}
