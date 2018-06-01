using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bullet : MonoBehaviour {

    [SerializeField]
    public Transform bulletSpawn;
    public float damage = 1.0f;
    public float speed = 1.0f;
    public float offset = 2.0f;

    public void Shoot()
    {
        GameObject obj = ObjectPool.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = bulletSpawn.position;
        obj.transform.rotation = bulletSpawn.rotation;
        Rigidbody bulletRB = obj.GetComponent<Rigidbody>();
        bulletRB.velocity = bulletSpawn.forward * speed;
        obj.SetActive(true);
    }
}
