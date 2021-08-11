using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activatable))]
public class CollisionTriggerer : ActivatableTriggerer
{
    
    public Activatable Activatable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "piggy")
        {
            Debug.Log(Activatable.HasGuards);
            Debug.Log(Activatable.CanActivate);
            Debug.Log(Activatable.TryToggle(this));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
    }
}
