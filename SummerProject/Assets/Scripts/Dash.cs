using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    [SerializeField]
    private LayerMask collisonLayerMask;
    public float dashDistance = 5.0f;
    public float dashDuration = .2f;
    public bool abilityOn;
    [Tooltip("The y offset from the charcthers feet from which we want to send a ray to check if the charcther would go through geometry")]
    [SerializeField]
    private float collisionRayFeetOffSetY = .1f;
    [SerializeField]
    private float collisionOffsetDistance = .1f;

    private float startTimeAbility = float.MinValue;
    private Vector3 positionAtStartAbility;
    private Vector3 targetPosition;
    private CapsuleCollider capsuleCollider;

    // Use this for initialization
    void Start () {
        abilityOn = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void StartAbility()
    {
        abilityOn = true;
        Vector3 dashVector = transform.forward * dashDistance;
        Vector3 rayOrigin = collisionRayFeetOffSetY * Vector3.up;
        Ray dashRay = new Ray(transform.position, transform.forward);
        RaycastHit rayHit;
        if(Physics.Raycast(dashRay, out rayHit, dashDistance, collisonLayerMask.value))
        {
            //targetPosition = rayHit.point + rayHit.normal * (capsuleCollider.radius + collisionRayFeetOffSetY) - collisionOffsetDistance * Vector3.up;
            float distanceOffSet = capsuleCollider.radius;
            targetPosition = rayHit.point - Vector3.up * collisionRayFeetOffSetY - transform.forward * capsuleCollider.radius;
            while(rayHit.collider.Raycast(dashRay, out rayHit, rayHit.distance - distanceOffSet))
            {
                targetPosition -= transform.forward * capsuleCollider.radius;
                distanceOffSet += capsuleCollider.radius;
            }
        }
        else
        {
            targetPosition = transform.position + dashVector;
        }

        startTimeAbility = Time.time;
        positionAtStartAbility = transform.position;
    }

    public void UpdateMovement()
    {
        float timeSinceAbility = Time.time - startTimeAbility;
        Vector3 dashVector = targetPosition - positionAtStartAbility;
        Vector3 interpolatedPos = positionAtStartAbility + (timeSinceAbility / dashDuration) * dashVector;
        transform.position = interpolatedPos;

        if(timeSinceAbility > dashDuration)
        {
            StopAbility();
        }
    }

    public void StopAbility()
    {
        abilityOn = false;
    }
}
