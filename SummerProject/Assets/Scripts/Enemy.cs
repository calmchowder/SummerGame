using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    public Transform target;
    protected NavMeshAgent ThisAgent = null;

    public float health;
    public List<Bullet> bulletList;
    public Rigidbody rb;
    //public Collider3D collider;

    public void Attack()
    {
        
    }

    public void Move()
    {

    }
}
