using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator ani;
    private Rigidbody rb;
    public float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        rb.velocity = new Vector3(xSpeed, 0, zSpeed);
        transform.LookAt(transform.position + rb.velocity);
        
        if (xInput !=0 || zInput !=0)
        {
            ani.SetTrigger("Walk");
        }
        else ani.SetBool("Idle",true);
       
    }

    public void Die()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gameObject.SetActive(false);
        gm.EndGame();
    }
}
