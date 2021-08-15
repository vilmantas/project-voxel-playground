using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivatableTriggererType))]
public class CollisionTriggerer : ActivationContender
{
    public Activatable Target;

    public ActivationContender Collider;

    [Header("How to trigger the target")]
    public TriggerType Type;

    public ActivatableTriggererType TriggerTypeComponent;

    public bool TryActivateOnEnter;

    public bool TryActivateOnExit;

    void OnTriggerEnter(Collider other)
    {
        var contender = other.GetComponent<ActivationContender>();

        if (contender != Collider) return;

        if (TryActivateOnEnter)
        {
            Target.TryActivate(contender, TriggerTypeComponent);
        }
        else
        {
            switch (TriggerTypeComponent)
            {
                case FlagActivatableTriggererType flagger:
                    flagger.TrySetFlag(Target, contender);
                    break;

                case NotifyActivatableTriggererType notifier:
                    notifier.TryNotify(Target, contender);
                    break;

                default:
                    break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        var contender = other.GetComponent<ActivationContender>();

        if (contender == Collider)
        {
            if (TryActivateOnExit)
            {
                Target.TryActivate(contender, TriggerTypeComponent);
            } 
            else
            {
                switch (TriggerTypeComponent)
                {
                    case FlagActivatableTriggererType flagger:
                        flagger.TryUnsetFlag(Target, contender);
                        break;

                    case NotifyActivatableTriggererType notifier:
                        notifier.TryNotify(Target, contender);
                        break;

                    default:
                        break;
                }
            }

        }
    }

    private void Activate(Collider other)
    {
        var otherTriggerer = other.GetComponent<ActivationContender>();

        if (otherTriggerer == Collider)
        {
            Target.TryActivate(otherTriggerer, TriggerTypeComponent);
        }
    }


}
