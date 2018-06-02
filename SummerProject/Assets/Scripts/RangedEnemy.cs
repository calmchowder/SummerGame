using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RangedEnemy : Enemy {

    [SerializeField]
    private float firingCD = 1.0f;

    void Start()
    {
        health = 40;
        ThisAgent = GetComponent<NavMeshAgent>();
    }

	new void Attack () {
		
	}

    new void Move () {
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
