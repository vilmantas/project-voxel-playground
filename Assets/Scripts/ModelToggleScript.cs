using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelToggleScript : Activatable
{
    public Renderer WhenOn;

    public Renderer WhenOff;

    public bool DefaultValue = true;

    public override void Activate()
    {
        WhenOn.enabled = !WhenOn.enabled;
        WhenOff.enabled = !WhenOff.enabled;
    }

    private void Toggle()
    {

    }
}
