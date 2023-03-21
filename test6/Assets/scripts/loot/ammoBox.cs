using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBox : MonoBehaviour
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
            mover.my_head.BagAmmo += 100;
            mover.my_head.ShowAmmo();
            Debug.Log("ammo touched");
            Active = false;
            Destroy(this.gameObject);
        }
    }
}
