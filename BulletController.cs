using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float bulletSpawMin = .5f;
    private float bulletSpawnMax = 3f;

    Transform target;
    private float SpawnRate;
    private float timeSpawnRate;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        SpawnRate = Random.Range(bulletSpawMin, bulletSpawnMax);
        timeSpawnRate = 0;

    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!gm.isGameover)
        {
            timeSpawnRate += Time.deltaTime;
            if (timeSpawnRate >= SpawnRate)
            {
                timeSpawnRate = 0;

                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(target);

                SpawnRate = Random.Range(bulletSpawMin, bulletSpawnMax);
            }
        }
    }
}
