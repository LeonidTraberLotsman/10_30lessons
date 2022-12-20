using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject DogPrefab;
    public Transform playerForDogs;

    void ColorPart(Transform part,Color new_color)
    {
        part.GetComponent<Renderer>().material.color = new_color;
    }
    void SpawnDog()
    {
        Debug.Log("call");
        GameObject new_dog = Instantiate(DogPrefab);
        enemy en = new_dog.GetComponent<enemy>();
        en.player = playerForDogs;
        new_dog.transform.position = transform.position+new Vector3(Random.Range(-5f,5f),0,Random.Range(-5f,5f));
        Color random_color = new Color(Random.Range(-1f, 1f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        foreach (Transform part in en.parts)
        {
            ColorPart(part, random_color);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= 50; i++)
        {
            SpawnDog();
        }
       
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
