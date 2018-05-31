using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    [SerializeField]
    private LayerMask collisonLayerMask;
    public float dashSpeed = 20.0f;
    public float dashDistance = 5.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartAbility()
    {
        Vector3 dashVector = transform.forward * dashDistance;
        Vector3 targetPosition;

        Ray dashRay = new Ray(transform.position, transform.forward);
        RaycastHit rayHit;
        if(Physics.Raycast(dashRay, out rayHit, dashDistance, collisonLayerMask.value))
        {
            targetPosition = rayHit.point;
        }
        else
        {
            targetPosition = transform.position + dashVector;
        }
        transform.position = targetPosition;
    }
}
