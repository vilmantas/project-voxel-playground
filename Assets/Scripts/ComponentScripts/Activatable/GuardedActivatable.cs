using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GuardedActivatable : Activatable
{
    public ActivationContendersManager ContendersManager;

    public GuardedActivatable()
    {
        ContendersManager = new ActivationContendersManager(this);
    }


    [SerializeField]
    public ActivatableGuard[] Guards;
    public bool HasGuards => Guards != null && Guards.Length > 0;

    public override bool CanActivate(ActivatableGuard[] guards) => guards.All(g => g.CanActivate);

    public override bool CanActivate(ActivationContender contender)
    {
        if (!HasGuards) return true;

        if (!RespondsTo(contender)) return false;

        var state = ContendersManager.GetContenderState(contender);

        if (state is EmptyContenderState) return false;

        return CanActivate(state.Guards);
    }

    public bool RespondsTo(ActivationContender contender)
    {
        return Guards.Any(x => x.IsInterestedIn(contender));
    }

    public override bool TryActivate(ActivationContender triggerer, ActivatableTriggererType activatableTriggererType)
    {
        if (CanActivate(triggerer))
        {
            Activate(triggerer);
            return true;
        }
        else if (ResolveTriggerTypeAndAct(triggerer, activatableTriggererType))
        {
            if (CanActivate(triggerer))
            {
                Activate(triggerer);
                return true;
            }
        }

        return false;
    }

    public override bool TryToggle(ActivationContender activatableTriggerer)
    {
        if (!RespondsTo(activatableTriggerer)) return false;

        var state = ContendersManager.GetContenderState(activatableTriggerer);

        var guards = state.Guards;

        if (state is EmptyContenderState) guards = DuplicateGuards().ToArray();

        foreach (var guard in guards)
        {
            if (guard is ToggleGuard toggleGuard)
            {
                if (toggleGuard.TryToggle(activatableTriggerer))
                {
                    ContendersManager.SaveState(activatableTriggerer, guards);
                    return true;
                }
            }
        }

        return false;
    }

    public override bool TrySetFlag(ActivationContender activatableTriggerer, FlagType flag)
    {
        if (!RespondsTo(activatableTriggerer)) return false;

        var state = ContendersManager.GetContenderState(activatableTriggerer);

        var guards = state.Guards;

        if (state is EmptyContenderState) guards = DuplicateGuards().ToArray();

        foreach (var guard in guards)
        {
            if (guard is FlagGuard flagGuard && flagGuard.FlagType == flag)
                if (flagGuard.TrySetFlag(activatableTriggerer))
                {
                    ContendersManager.SaveState(activatableTriggerer, guards);
                    return true;
                }
        }

        return false;
    }

    public override bool TryUnsetFlag(ActivationContender activatableTriggerer, FlagType flag)
    {
        if (!RespondsTo(activatableTriggerer)) return false;

        var state = ContendersManager.GetContenderState(activatableTriggerer);

        var guards = state.Guards;

        if (state is EmptyContenderState) guards = DuplicateGuards().ToArray();

        foreach (var guard in guards)
        {
            if (guard is FlagGuard flagGuard && flagGuard.FlagType == flag)
                if (flagGuard.TryUnsetFlag(activatableTriggerer))
                {
                    ContendersManager.SaveState(activatableTriggerer, guards);
                    return true;
                }
        }

        return false;
    }

    public override bool TryNotify(ActivationContender notifier)
    {
        if (!RespondsTo(notifier)) return false;

        var state = ContendersManager.GetContenderState(notifier);

        var guards = state.Guards;

        if (state is EmptyContenderState) guards = DuplicateGuards().ToArray();

        foreach (var guard in guards)
        {
            if (guard is NotifyGuard notifyGuard)
            {
                if (notifyGuard.Notify(notifier))
                {
                    ContendersManager.SaveState(notifier, guards);
                    return true;
                }
            }
        }

        return false;
    }

    private bool ResolveTriggerTypeAndAct(ActivationContender triggerer, ActivatableTriggererType type)
    {
        if (type is FlagActivatableTriggererType flag)
        {
            return TrySetFlag(triggerer, flag.Type);
        }

        return false;
    }

    private IEnumerable<ActivatableGuard> DuplicateGuards()
    {
        return Guards.Select(g => g.Clone());
    }
}
