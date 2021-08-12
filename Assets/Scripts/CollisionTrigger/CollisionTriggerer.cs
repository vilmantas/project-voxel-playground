using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activatable))]
[RequireComponent(typeof(ActivatableTriggererType))]
public class CollisionTriggerer : ActivatableTriggerer
{
    public Activatable Target;

    public ActivatableTriggerer Collider;

    [Header("How to trigger the target")]
    public TriggerType Type;

    public ActivatableTriggererType TriggerTypeComponent;

    public bool TryActivate;

    void OnTriggerEnter(Collider other)
    {
        if (TryActivate)
        {
            Activate(other);
        }
        else
        {
            var otherTriggerer = other.GetComponent<ActivatableTriggerer>();

            if (otherTriggerer == Collider)
            {
                var type = TriggerTypeComponent as FlagActivatableTriggererType;

                type.TrySetFlag(Target, Collider);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (TryActivate)
        {
            Activate(other);
        }
        else
        {
            var otherTriggerer = other.GetComponent<ActivatableTriggerer>();

            if (otherTriggerer == Collider)
            {
                var type = TriggerTypeComponent as FlagActivatableTriggererType;

                type.TryUnsetFlag(Target, Collider);
            }
        }
    }

    private void Activate(Collider other)
    {
        var otherTriggerer = other.GetComponent<ActivatableTriggerer>();

        if (otherTriggerer == Collider)
        {
            var type = TriggerTypeComponent as FlagActivatableTriggererType;

            type.TryActivate(Target, Collider);
        }
    }
}
