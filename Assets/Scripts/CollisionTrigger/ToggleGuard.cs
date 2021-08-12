using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGuard : ActivatableGuard
{
    public GameObject CollisionTriggerer;

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
