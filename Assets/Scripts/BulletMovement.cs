using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public int bulletSpeed;
    ParticleSystem particle;
    Rigidbody rb;
   // public GameObject bullet;
    //public GameObject tempBullet;


    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(-bulletSpeed * Time.deltaTime, 0f, 0f);
        // rb.AddForce(transform.forward*bulletSpeed);

       // if (Input.GetKeyDown(KeyCode.Space))
        //{
           // GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            //tempBullet.transform.position = transform.position;
            //  Camera camera=GetComponentInChildren<Camera>();
            GetComponent<Rigidbody>().velocity = Camera.main.transform.rotation * Vector3.forward * bulletSpeed;


        //}



    }



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           gameObject.SetActive(false);   // //Making bullet to inactive and back to pool
            print("bullet is made inactive");         //Print statement
            Destroy(collision.gameObject);





            // GameObject effect = Instantiate(particle, Hit.transform.position, Quaternion.identity);
            //  Destroy(effect,1f);


        }
    }
    
        }
    

