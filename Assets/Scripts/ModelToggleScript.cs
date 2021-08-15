using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelToggleScript : GuardedActivatable
{
    public Renderer WhenOn;

    public Renderer WhenOff;

    public bool DefaultValue = true;

    public override void Activate(ActivationContender activatableTriggerer) => Toggle();

    public override void Activate() => Toggle();

    private void Toggle()
    {
        WhenOn.enabled = !WhenOn.enabled;
        WhenOff.enabled = !WhenOff.enabled;
    }
}
