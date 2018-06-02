using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MovementAbility 
{

    public float dashDistance = 5.0f;
    public float dashDuration = .2f;

    [SerializeField]
    private LayerMask collisonLayerMask;
    [Tooltip("The y offset from the charcthers feet from which we want to send a ray to check if the charcther would go through geometry")]
    [SerializeField]
    private float collisionRayFeetOffSetY = .1f;
    [SerializeField]
    private float coolDownDuration = .5f;

    private float startTimeAbility = float.MinValue;
    private Vector3 positionAtStartAbility;
    private Vector3 targetPosition;
    private CapsuleCollider capsuleCollider;

    // Use this for initialization
    void Start () {
        abilityOn = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public override void StartAbility()
    {
        abilityOn = true;
        Vector3 dashVector = transform.forward * dashDistance;
        Ray dashRay = new Ray(transform.position, transform.forward);
        RaycastHit rayHit;
        //Check for dash collision 
        if(Physics.Raycast(dashRay, out rayHit, dashDistance, collisonLayerMask.value))
        {
            //Stop dash from tunneling into objects 
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

    public override void UpdateMovement()
    {
        //linearly interpolated movement for dash 
        float timeSinceAbility = Time.time - startTimeAbility;
        Vector3 dashVector = targetPosition - positionAtStartAbility;
        Vector3 interpolatedPos = positionAtStartAbility + (timeSinceAbility / dashDuration) * dashVector;
        transform.position = interpolatedPos;
        //stops interpolating when dash finishes 
        if(timeSinceAbility > dashDuration)
        {
            StopAbility();
        }
    }

    public override void StopAbility()
    {
        abilityOn = false;
    }

    public override bool CanStartAbility()
    {
        return Time.time - startTimeAbility > dashDuration + coolDownDuration;
    }
}
