using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Activatable : MonoBehaviour
{
    public abstract void Activate();

    [SerializeField]
    public ActivatableGuard[] Guards;
    public bool HasGuards => Guards != null && Guards.Length > 0;

    public bool CanActivate => Guards.All(g => g.CanActivate);

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
}
