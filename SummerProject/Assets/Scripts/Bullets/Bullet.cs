using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bullet : MonoBehaviour {

    [SerializeField]
    public Transform bulletSpawn;

    public virtual void Shoot(){}
}
