using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActivatableGuard : MonoBehaviour
{
    public bool CanActivate;

    public ActivationContender ActivationContender;

    public bool IsInterestedIn(ActivationContender contender)
    {
        return ActivationContender == contender;
    }

    public abstract ActivatableGuard Clone();
}
