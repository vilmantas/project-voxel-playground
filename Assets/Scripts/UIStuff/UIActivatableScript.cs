using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActivatableScript : MonoBehaviour
{
    public Activatable Activatable;

    public Text Text;

    public ActivationContender Contender;

    // Update is called once per frame
    void Update()
    {
        var g = Activatable as GuardedActivatable;


        Text.text = @$"
Has guards: {g.HasGuards}
Contenders count: {g.ContendersManager.ActivationContenders.Count}
Can activate: {Activatable.CanActivate(Contender)}
";
    }
}
