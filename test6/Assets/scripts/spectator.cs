using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spectator : MonoBehaviour
{

    public Transform player;
    public Renderer renderer;
    public float distance;

    public float SpotStatus = 0;


    public BattleManager manager; 
    float CanSee()
    {
        float local_distance = Vector3.Distance(transform.position, player.position);
        if (local_distance > distance) return 0;
        RaycastHit hit;

        Vector3 direction = player.position - transform.position;

        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < 0) angle = -angle;
        if (angle > 60) return 0; 

        if(Physics.Raycast(transform.position,direction,out hit))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform== player)
            {
                return 1/local_distance;
            }
        }

        return 0;
    }

    public void Alarmed()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float seePoints=CanSee();
        Debug.Log(seePoints);
        if (seePoints ==0) seePoints = -1;
        SpotStatus += seePoints;
        if (SpotStatus <0) SpotStatus = 0;
        if (SpotStatus > 100) {
            SpotStatus = 100;

            manager.Alarm();


        }


        float color=SpotStatus/ 100;

        renderer.material.color = new Color(1-color,color,0);
       
    }
}
