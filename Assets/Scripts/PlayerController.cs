using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float playerSpeed;  //Declaring a varible playerspeed for player
    public float playerJumpForce; //Declaring a variable player Jumpforce
    public float playerRotationSpeed;
    // Declaring a variable player rotation speed

    Rigidbody rb;                 //Declaring a rigidbody
    CapsuleCollider colliders;    //Collider
    Quaternion camRotation;
    public Camera cam;              //Declaring camera
    Quaternion playerRotation;
    //public Transform bulletLaunch;


    float inputX;
    float inputz;
    public Animator animator;
    //SpawnManager spawnManager;

    public GameObject[] weapons;
    AudioSource audioSource;

    public Transform spawnPoint;
    public GameObject bullet;





    void Start()
    {
        rb = GetComponent<Rigidbody>();
        colliders = GetComponent<CapsuleCollider>();
        //spawnManager = GameObject.Find("SpawnPosition").GetComponent<SpawnManager>();
        audioSource = GetComponent<AudioSource>();
       //spawnPoint = GetComponent<Transform>();
       // weapons = GetComponent<GameObject[]>();
       // weapons[0].SetActive(false);
      //  weapons[0].SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("isReload", !animator.GetBool("isReload"));

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

            { 
                animator.SetBool("isShoot", !animator.GetBool("isShoot"));
                Instantiate(bullet,spawnPoint.transform.position, Quaternion.identity);
               // audioSource.Play();

              //  HitEnemy();

            }

        }

       /* if (Input.GetKeyDown(KeyCode.K))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }*/



    }
    void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal") * playerSpeed;   //Movement of the player in horizantal direction 
        inputz = Input.GetAxis("Vertical") * playerSpeed;     //Movement of the player in vertical direction 

        transform.position += new Vector3(inputX, 0f, inputz);


        float mouseX = Input.GetAxis("Mouse X") * playerRotationSpeed;    //Using mouse to move the player in horizantal direction
        float mouseY = Input.GetAxis("Mouse Y") * playerRotationSpeed;    //Using mouse to move the player in vertical direction

        playerRotation = Quaternion.Euler(0f, mouseX, 0f);
        camRotation = Quaternion.Euler(-mouseY, 0f, 0f);


        transform.localRotation = playerRotation * transform.localRotation;
        cam.transform.localRotation = camRotation * cam.transform.localRotation; // Rotation of the camera

    }

   /* public void HitEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletLaunch.position, bulletLaunch.forward, out hit, 100f))
        {
            GameObject hitEnemy = hit.collider.gameObject;
            if (hitEnemy.gameObject.tag == "Enemy")
            {
                Destroy(hitEnemy);
                print("Enemy hit");
                hitEnemy.GetComponent<GameStateManager>().EnemyDead();
            }
        }

    }*/

   
}















