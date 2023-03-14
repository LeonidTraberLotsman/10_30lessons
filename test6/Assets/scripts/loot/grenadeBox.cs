using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeBox : MonoBehaviour
{
    bool Active = true;
    // Start is called before the first frame update



    void OnCollisionEnter(Collision collision)
    {
        if (!Active) return;
        Debug.Log(collision.transform.name);

        CubeMover mover = collision.transform.GetComponent<CubeMover>();
        if (mover)
        {
            mover.my_head.grenades += 3; 
            
            Debug.Log("gb touched");
            Active = false;
        }
    }
}
