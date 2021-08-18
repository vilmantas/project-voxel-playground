using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType
{
    Flag,
    Notification
}

public abstract class ActivatableTriggererType : MonoBehaviour
{
    public abstract bool TryActivate(Activatable activatable, ActivationContender triggerer);
}
