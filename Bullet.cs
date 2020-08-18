using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 8f;
    public const float levelSpeed = 8f;

 

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(!gm.isGameover)
        {
            rb = GetComponent<Rigidbody>();

            if (gm.SurviveTime >= 0 && gm.SurviveTime < 10f) speed = levelSpeed;
            else if (gm.SurviveTime >= 10f && gm.SurviveTime < 20f) speed = levelSpeed + 2f;
            else if (gm.SurviveTime >= 20f && gm.SurviveTime < 30f) speed = levelSpeed + 4f;
            else if (gm.SurviveTime >= 30f && gm.SurviveTime < 60f) speed = levelSpeed + 6f;

            rb.velocity = transform.forward * speed;
            Destroy(gameObject, 3f);
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            PlayerController pc = collider.GetComponent<PlayerController>();
            if(pc != null)
            {
                pc.Die();
            }
        }
        else if(collider.CompareTag("Skill"))
        {
            Destroy(gameObject);
        }
    }

}
