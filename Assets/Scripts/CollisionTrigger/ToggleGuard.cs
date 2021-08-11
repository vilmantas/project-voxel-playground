using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivatableTriggerer))]
public class ToggleGuard : ActivatableGuard
{
    public ActivatableTriggerer CollisionTriggerer;

    public bool TryToggle(ActivatableTriggerer toggleRequester)
    {
        if (CollisionTriggerer == toggleRequester)
        {
            CanActivate = !CanActivate;
            return true;
        }

        return false;
    }
}
