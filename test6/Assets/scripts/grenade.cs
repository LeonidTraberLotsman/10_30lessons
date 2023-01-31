using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{

    public ParticleSystem boom;
    public float grenadeTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Grenade());
    }

    IEnumerator Grenade()
    {
        yield return new WaitForSeconds(grenadeTime);
        boom.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
