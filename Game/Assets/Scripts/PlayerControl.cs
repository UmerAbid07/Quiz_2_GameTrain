using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 15f;
    public float horizontalInput;
    public float verticalInput;
    Rigidbody rb;
    public bool isLadder;
    public float jumpForce = 8f;
    public bool isGrounded;
    public bool nextLevel;
    Animator anim;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager=GameObject.Find("GameManager").GetComponent<ScoreManager>();
        rb= GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //jump
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            isGrounded= false;
        }
        //Movement
        if (horizontalInput != 0)
        {
            rb.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Impulse);
            anim.SetFloat("Speed_f", 1);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
        }
        //climb
        if (isLadder&&isGrounded&&verticalInput>0)
        {
            transform.position +=new Vector3(0,0.5f,0);
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            isLadder= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            isLadder= false;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            nextLevel = true;
            scoreManager.winner();
            Time.timeScale = 0;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded= true;
        }   
    }

}
