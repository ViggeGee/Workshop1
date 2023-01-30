using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 newPos;
    float RotationSpeed = 500;
    Vector3 oldPos;
    [SerializeField] Animator anim;
    [SerializeField] int movespeed;
    [SerializeField] int jumpForce;
    [SerializeField] Vector3 velocity;
    [SerializeField] KeyCode jumpButton;

    [SerializeField] GameObject groundCheck;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckBox(
            groundCheck.transform.position,
            groundCheck.GetComponent<Collider>().bounds.size, Quaternion.identity,
            groundMask
            );

        if(Input.GetKeyDown(jumpButton) && isGrounded) 
        { 
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
            anim.Play("JumpOneTake");
        }

        oldPos = transform.position;
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movespeed * Time.deltaTime;
        newPos = transform.position;
        if (newPos != oldPos && isGrounded)
        {
            anim.Play("Run01FWD");
        }
        else { anim.Play("Idle01"); }

        
    }
}
