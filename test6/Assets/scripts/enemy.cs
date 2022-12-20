using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
    public int HP = 100;
    public NavMeshAgent agent;
    public Transform player;
    hodba a;
    Coroutine cor;
    public List<Transform> parts;
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemy");
        a = player.GetComponent<hodba>();
        agent = GetComponent<NavMeshAgent>();
        cor = StartCoroutine(CatchPlaer());
    }
    IEnumerator CatchPlaer()
    {
        while (true)
        {
            agent.destination = player.position;
            yield return null;
            if (Vector3.Distance(player.position, transform.position) < 10)
            {
                Debug.Log("урон");
                if (HP > 0) 
                {
                    a.Damage(5);
                }
               
                //a.ShowHP();
                yield return new WaitForSeconds(7);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage(int num)
    {
        HP = HP - num;
        if (HP < 1)
        {
            die();
        }
    }
    IEnumerator dissapear()
    {
        yield return new WaitForSeconds(20);
        Destroy(this.gameObject);
    }

    void die()
    {
        Debug.Log("die");
        StopCoroutine(cor);
        GetComponent<Collider>().enabled = false;
        agent.enabled = false;
        foreach (Transform part in parts)
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(Vector3.up * 5 + new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)));
            part.SetParent(null);
        }
        Destroy(this.gameObject);
    }
}