using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    CubeMover PlayerScript;


    // Start is called before the first frame update
    void Start()
    {
           agent = GetComponent<NavMeshAgent>();
        PlayerScript = player.GetComponent<CubeMover>();
        StartCoroutine(CatchPlayer());
    }

    IEnumerator CatchPlayer()
    {
        while (true){
            agent.destination = player.position;
            yield return null;
            if (Vector3.Distance(player.position, transform.position) < 10)
            {
                Debug.Log("Damage");
                PlayerScript.hp -= 5;
                PlayerScript.ShowHP();
                yield return new WaitForSeconds(7);
            }
            

        }
    }
   
}
