using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spectator : MonoBehaviour
{

    public Transform player;
    public Renderer renderer;
    public float distance;

    bool CanSee()
    {
        if (Vector3.Distance(transform.position, player.position) > distance) return false;
        RaycastHit hit;

        Vector3 direction = player.position - transform.position;

        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < 0) angle = -angle;
        if (angle > 60) return false; 

        if(Physics.Raycast(transform.position,direction,out hit))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform== player)
            {
                return true;
            }
        }

        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if(CanSee())
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = Color.red;
        }
    }
}
