using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlagType
{
    InRange,
    Checkpoint
}

public class FlagGuard : ActivatableGuard
{
    public FlagType FlagType;

    public bool TrySetFlag(ActivationContender flagSetter)
    {
        if (IsInterestedIn(flagSetter))
        {
            CanActivate = true;
            return true;
        } else
        {
            return false;
        }
    }

    public bool TryUnsetFlag(ActivationContender flagSetter)
    {
        if (IsInterestedIn(flagSetter))
        {
            CanActivate = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override ActivatableGuard Clone()
    {
        var result = new FlagGuard();
        result.FlagType = FlagType;
        result.ActivationContender = ActivationContender;

        return result;
    }
}
