using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagActivatableTriggererType : ActivatableTriggererType
{
    public FlagType Type;

    [HideInInspector]
    public bool FlagSet;

    public override bool TryActivate(Activatable activatable, ActivationContender triggerer)
    {
        if (activatable.CanActivate(triggerer))
        {
            activatable.Activate(triggerer);
            return true;
        }
        else if (activatable is GuardedActivatable guarded)
        {
            if (guarded.TrySetFlag(triggerer, Type))
            {
                if (guarded.CanActivate(triggerer))
                {
                    guarded.Activate(triggerer);
                    return true;
                }
            }


        }

        return false;
    }

    public bool TrySetFlag(Activatable activatable, ActivationContender triggerer)
    {
        bool result;

        result = activatable.TrySetFlag(triggerer, Type);
        if (result)
            FlagSet = true;

        return result;
    }

    public bool TryUnsetFlag(Activatable activatable, ActivationContender triggerer)
    {
        bool result;

        result = activatable.TryUnsetFlag(triggerer, Type);
        if (result)
            FlagSet = false;

        return result;
    }
}
