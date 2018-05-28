using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bullet : MonoBehaviour {

    [SerializeField]
    private uint bulletsFired = 0;
    [SerializeField]
    private List<GameObject> bulletPool; //list of bullets current in the scene
    [SerializeField]
    private List<float> lifePool; //list of times the bullets where shoot
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int lifeTime;
    public int damage;
    public float speed = 1.0f;



    public void Start()
    {
        bulletPool = new List<GameObject>();//initialize the list of bullets
        lifePool = new List<float>();//initialize the list of times
    }

    public void Update()
    {
        for(int index = 0; index < bulletsFired; ++index)
        {
            //check the current time vs the time the bullet was shoot plus the lifetime total
            if (Time.time > lifePool[index] + lifeTime)
            {
                Destroy(bulletPool[index]);
                lifePool.RemoveAt(index);
                bulletPool.RemoveAt(index);
                --index;
                --bulletsFired;
            }
        }
    }

    public void Shoot()
    {
        GameObject tempBullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRB = tempBullet.GetComponent<Rigidbody>();
        bulletRB.velocity = bulletSpawn.forward * speed;
        lifePool.Add(Time.time);
        bulletPool.Add(tempBullet);
        ++bulletsFired;
    }

    //public void OnSpawned()
    //{

    //}

    //public void SelfDestruct()
    //{

    //}
}
