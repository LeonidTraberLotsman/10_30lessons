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
        yield return new WaitForSeconds(grenadeTime);
        boom.Play();

        foreach (enemy that_enemy in MyBattleManager.enemies)
        {
            if (Vector3.Distance(transform.position, that_enemy.transform.position)    <5)
            {
                that_enemy.Damage(100);
                Debug.Log(that_enemy.transform.name);
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
