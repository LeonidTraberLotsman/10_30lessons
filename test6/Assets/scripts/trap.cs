using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public ParticleSystem blow;
    public bool activate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void blowUp()
    {
        Debug.Log("blow up");
        activate = true;
        GetComponent<Renderer>().enabled = false;
        StartCoroutine(dissapear());
        blow.Play();
    }
    IEnumerator dissapear()
    {
        yield return new WaitForSeconds(20);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (activate) return;
        
        Transform orig = other.transform;
        while (orig.parent != null) { orig = orig.parent; }
        enemy en = orig.GetComponent<enemy>();
        if (en != null)
        {

            blowUp();
            en.Damage(100);
        }
        
        hodba h = orig.GetComponent<hodba>();

        if (h != null)
        {

            blowUp();
            h.Damage(100);
        }


    }
}
