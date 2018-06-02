using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RangedEnemy : MonoBehaviour, IEnemy {

    [SerializeField]
    public Transform target;
    protected NavMeshAgent ThisAgent = null;
    private float firingCD = 1.0f;

    public float health;
    public List<Bullet> bulletList;
    public Rigidbody rb;
    //public Collider3D collider;

    void Start()
    {
        health = 40;
        ThisAgent = GetComponent<NavMeshAgent>();
    }

	public void Attack () 
    {
		
	}

<<<<<<< HEAD:SummerProject/Assets/Scripts/RangedEnemy.cs
    new void Move () {
=======
	public void Move () 
    {
>>>>>>> 2bf5fb8d30b9108e8c11e439f7ee317887a39708:SummerProject/Assets/Scripts/Enemy/RangedEnemy.cs
        ThisAgent.SetDestination(target.position);
	}

    bool InRange()
    {
        return false;
    }

    bool CanSee()
    {
        Vector3 origin = transform.position;
        Vector3 direction = origin - target.position;
        return Physics.Raycast(origin, direction.normalized, Mathf.Infinity, 3);
    }

    void Update()
    {
        if (CanSee())
            Debug.Log("Can see the player");
        Move();
    }
}
