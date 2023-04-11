using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootRain : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> boxes;

    void Start()
    {
        StartCoroutine(lootRainRoutine());
    }

    void LootDrop(){

        GameObject loot = Instantiate(boxes[Random.Range(0, boxes.Count)]);

        loot.transform.position = transform.position+ new Vector3(Random.Range(0, 100.0f),0, Random.Range(0, 100.0f));

    }

    IEnumerator lootRainRoutine()
    {
        yield return null;
        while (true)
        {
            for (int i = 0; i < Random.Range(0, 10); i++)
           
            LootDrop();
            yield return new WaitForSeconds(30);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
