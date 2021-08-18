using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Activatable : MonoBehaviour
{
    public abstract void Activate(ActivationContender triggerer);

    public abstract void Activate();

    public virtual bool CanActivate(ActivatableGuard[] guards) => true;

    public virtual bool CanActivate(ActivationContender contender) => true;

    public virtual bool TryToggle(ActivationContender _) => true;

    public virtual bool TrySetFlag(ActivationContender _, FlagType __) => true;

    public virtual bool TryUnsetFlag(ActivationContender _, FlagType __) => true;

    public virtual bool TryNotify(ActivationContender _) => true;

    public virtual bool TryActivate(ActivationContender triggerer, ActivatableTriggererType _)
    {
        Activate(triggerer);
        return true;
    }
}
