using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour

{
    public float speed = 6f;            
    public float gravity = 0;
    private CharacterController _charController;
    Vector3 movement;                   
    Animator anim;
    private Rigidbody rb;       
    public static float playerx, playery, playerz;       


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }


    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Vector3 movement = new Vector3(h, gravity, v);
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
                movement = transform.TransformDirection(movement);  
         rb.MovePosition(transform.position + movement);
       // rb.AddForce(movement * speed);

        playerx = this.transform.position.x;
        playery = this.transform.position.y;
        playerz = this.transform.position.z;

 //       Animating(h, v);
    }


   /*
    void Animating(float h, float v)
    {
      
        bool walking = h != 0f || v != 0f;

   
        anim.SetBool("IsWalking", walking);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("golds"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("123123123");
            ScoreManage.score = ScoreManage.score +materialgold;
        }
    }
    */
}
