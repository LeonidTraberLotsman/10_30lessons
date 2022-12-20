using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hodba : MonoBehaviour
{
    public int hp = 100;
    public Text HPtext;

    public bool db;
    public head my_head;
    public int speed=10;
    public int runspeed=30; 
    public Rigidbody rb;
    public int jumpPower=250;
    public bool ground = true;
    public bool Alive = true;
    // Start is called before the first frame update
    void Start()
    {
        ShowHP();
           rb =GetComponent<Rigidbody>();
    }
    public void ShowHP()
    {
        HPtext.text = hp.ToString();
    }
    // Update is called once per frame
    void Update() 
    {      
        if (Alive){
        if (Input.GetKey(KeyCode.W)){
            
                rb.AddForce(transform.forward * (speed * 30));
                Debug.Log("W");
                //transform.localPosition += transform.forward*speed*Time.deltaTime;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //transform.localPosition += transform.forward*runspeed*Time.deltaTime;  
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.forward * (speed * 25));
                if (Input.GetKey(KeyCode.LeftShift))
                {

                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(transform.right * (speed * 25));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-transform.right * (speed * 25));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ground)
                {
                    rb.AddForce(transform.up * jumpPower);
                }
                if (db)
                {
                    rb.AddForce(transform.up * jumpPower);
                    db = false;
                }

            }
        }
    }
    
    


    public void Die()
    {
       my_head.active= Alive = false;
        rb.freezeRotation = false;
        rb.AddForce(transform.up * jumpPower);
        transform.Rotate(new Vector3(100, 100, 100));

    }
    public void Damage(int num)
    {
        Debug.Log(hp);
        hp = hp - num;
        ShowHP();
        if (hp < 1)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
            db = false;
        }
        if (collision.gameObject.tag == "Boost")
        {
            speed = 30;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
            db = true;
        }
        speed = 10;
    }
}
