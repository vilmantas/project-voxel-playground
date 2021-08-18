using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActivationContendersManager
{
    private static readonly EmptyContenderState EmptyContenderState = new EmptyContenderState();

    public readonly Activatable Activatable;

    public Dictionary<int, ContenderState> ActivationContenders = new Dictionary<int, ContenderState>();

    public ActivationContendersManager(Activatable activatable)
    {
        Activatable = activatable;
    }

    public ContenderState GetContenderState(ActivationContender contender)
    {
        if (!IsContenderPresent(contender)) return EmptyContenderState;

        ActivationContenders.TryGetValue(GetContenderIdentity(contender), out var result);

        return result;
    }

    public ContenderState SaveState(ActivationContender contender, ActivatableGuard[] guards)
    {
        if (guards.Any(x => x.CanActivate))
        {
            if (IsContenderPresent(contender)) return GetContenderState(contender);

            var result = new ContenderState(contender, guards);

            ActivationContenders.Add(GetContenderIdentity(contender), result);

            return result;
        } 
        else
        {
            RemoveContender(contender);
            return EmptyContenderState;
        }
    }

    private void RemoveContender(ActivationContender contender)
    {
        ActivationContenders.Remove(GetContenderIdentity(contender));
    }

    private bool IsContenderPresent(ActivationContender contender)
    {
        var identity = GetContenderIdentity(contender);

        return ActivationContenders.ContainsKey(identity);
    }

    private int GetContenderIdentity(ActivationContender contender)
    {
        return contender.GetInstanceID();
    }
}

public class ContenderState
{
    public readonly ActivationContender Contender;
    public readonly ActivatableGuard[] Guards;

    public ContenderState(ActivationContender contender, ActivatableGuard[] guards)
    {
        Contender = contender;
        Guards = guards;
    }

    public ContenderState()
    {

    }
}

public class EmptyContenderState : ContenderState
{

}
