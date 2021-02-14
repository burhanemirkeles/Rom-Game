using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Romiee : MonoBehaviour
{
    private const int V = 0;
    public float velocity = 1f;
    public Rigidbody2D rbd2d;
    public bool isDead; //false as default 
    public bool jump = true;
    public bool OnGround = true;
    public float jumpForce;
    public float xForce;
    bool isGrounded = true;
    public GameManager managerGame;

    public GameObject DeathScreen;

    public AudioSource jumpSound;
    public AudioSource dieSound;

    void Start(){
        Time.timeScale =1;
    }

    void Update()
    {
        Jump();
    }
    /*  void FixedUpdate () {
         rbd2d.velocity = Vector2.up * velocity;
       }
  */
    void Jump()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rbd2d.velocity = Vector2.up * velocity;
            jumpSound.Play();
            isGrounded = false;
        }
        /*
        if (Input.GetMouseButtonDown (0)&& isGrounded){
            rbd2d.velocity += jumpForce * Vector2.up;
            rbd2d.velocity += xForce * Vector2.right;
            isGrounded = false;
            }
            */
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" && isGrounded == false)
        {
            isGrounded = true;
        }else if(collision.gameObject.tag == "Deadarea"){
            
            isDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "PointArea"){
            managerGame.UpdateScore();
        }
    }

    

    /* nice try .(
      void Jump(Collision other){
          if(other.gameObject.tag == "Floor"){
              rbd2d.velocity = Vector2.up * velocity;

          }

      }
      void Update() => Jump(Collision);

  */
 
}

