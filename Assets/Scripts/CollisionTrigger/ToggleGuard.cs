using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGuard : ActivatableGuard
{
    public GameObject CollisionTriggerer;

    public bool TryToggle(ActivationContender toggleRequester)
    {
        if (CollisionTriggerer == toggleRequester)
        {
            CanActivate = !CanActivate;
            return true;
        }

        return false;
    }

    public override ActivatableGuard Clone()
    {
        var result = new ToggleGuard();
        result.CollisionTriggerer = CollisionTriggerer;

        return result;
    }
}
