using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyActivatableTriggererType : ActivatableTriggererType
{
    public bool Notified = false;

    public override bool TryActivate(Activatable activatable, ActivationContender triggerer)
    {
        return true;
    }

    public bool TryNotify(Activatable activatable, ActivationContender triggerer)
    {
        bool result;

        result = activatable.TryNotify(triggerer);
        if (result)
            Notified = true;

        return result;
    }
}
