using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaza : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

            rb.useGravity = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {

        


    }
}
