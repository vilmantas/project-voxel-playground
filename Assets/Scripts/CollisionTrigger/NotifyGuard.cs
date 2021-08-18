using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyGuard : ActivatableGuard
{
    public bool Notify(ActivationContender notifier)
    {
        if (IsInterestedIn(notifier))
        {
            CanActivate = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override ActivatableGuard Clone()
    {
        var result = new NotifyGuard();

        result.ActivationContender = ActivationContender;

        return result;
    }
}
