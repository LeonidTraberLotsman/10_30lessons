using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBox : MonoBehaviour
{
    bool Active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (!Active) return;
        Debug.Log(collision.transform.name);

        CubeMover mover = collision.transform.GetComponent<CubeMover>();
        if (mover)
        {
            mover.hp = 100;
            mover.ShowHP();
            Active = false;
        }
    }
}
