using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Activatable : MonoBehaviour
{
    public abstract void Activate(ActivatableTriggerer triggerer);

    public abstract void Activate();

    [SerializeField]
    public ActivatableGuard[] Guards;
    public bool HasGuards => Guards != null && Guards.Length > 0;

    public bool CanActivate => Guards != null && Guards.All(g => g.CanActivate);

    public bool TryToggle(ActivatableTriggerer activatableTriggerer)
    {
        foreach (var guard in Guards)
        {
            if (guard is ToggleGuard toggleGuard)
                if (toggleGuard.TryToggle(activatableTriggerer))
                    return true;
        }

        return false;
    }

    public bool TrySetFlag(ActivatableTriggerer activatableTriggerer, FlagType flag)
    {
        foreach (var guard in Guards)
        {
            if (guard is FlagGuard flagGuard && flagGuard.FlagType == flag)
                if (flagGuard.TrySetFlag(activatableTriggerer))
                    return true;
        }

        return false;
    }

    public bool TryUnsetFlag(ActivatableTriggerer activatableTriggerer, FlagType flag)
    {
        foreach (var guard in Guards)
        {
            if (guard is FlagGuard flagGuard && flagGuard.FlagType == flag)
                if (flagGuard.TryUnsetFlag(activatableTriggerer))
                    return true;
        }

        return false;
    }
}
