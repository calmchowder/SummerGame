using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbility : MonoBehaviour, IAbility
{
    public bool abilityOn;

    public virtual void StartAbility()
    {
        abilityOn = true;
    }

    public virtual void StopAbility()
    {
        abilityOn = false;
    }

    public virtual void UpdateMovement() { }
}
