using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour, IEnemy {

    [SerializeField]
    public Transform target;
    protected NavMeshAgent ThisAgent = null;
    private float meleeCD = 1.0f;
    private float meleeDistance = 5;

    public float health;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        health = 60;
        ThisAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Death();
        }

		if (InRange()) {
            // Perform attack animation here and call Attack();
            Attack();
        }

        Move();
	}

    public void Attack() {

    }

    /**
     * Simply move towards the player
     */
    public void Move() {
        ThisAgent.SetDestination(target.position);
    }

    /**
     * Play the death animation, then delete the model after it finishes
     */
    public void Death() {
        Animation death = GetComponent<Animation>(); // Need to get actual animations lol
        death.Play();
        Destroy(gameObject, death.clip.length);
    }

    /**
     * Checks if enemy is in range of player to perform an attack
     */
    private bool InRange() {
        if (Vector3.Distance(target.position, transform.position) > meleeDistance) {
            return false;
        }

        return true;
    }



}
