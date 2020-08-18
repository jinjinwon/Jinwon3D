using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(!gm.isGameover)
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
