using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{

    public ParticleSystem boom;
    public float grenadeTime;

    public BattleManager MyBattleManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Grenade());
    }

    IEnumerator Grenade()
    {
        yield return new WaitForSeconds(grenadeTime / 2);
        foreach (enemy that_enemy in MyBattleManager.enemies)
        {
            
            if (Vector3.Distance(transform.position, that_enemy.transform.position) < 15) {
                //react for grenade

                that_enemy.BeAfraidOfGrenade(this);
            }
        }

        yield return new WaitForSeconds(grenadeTime/2);
        boom.Play();

        foreach (enemy that_enemy in MyBattleManager.enemies)
        {
            if (Vector3.Distance(transform.position, that_enemy.transform.position)    <15)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, that_enemy.transform.position-transform.position, out hit))
                {
                    if(hit.transform== that_enemy.transform)
                    {
                        Debug.Log(hit.transform.name);
                        that_enemy.Damage(100);
                    }
                   
                  
                }
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
