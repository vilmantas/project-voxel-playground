using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : ActivatableItem
{
    public BomBscript Throwable;

    public float Force;

    public override void Activate(ActivationContender triggerer)
    {
        var pos = transform.position + transform.forward * 3;

        var instance = Instantiate(Throwable, pos, Random.rotation);

        var body = instance.GetComponent<Rigidbody>();

        body.AddForce(transform.forward * Force);

        IsExhausted = true;
    }

    public override void Activate()
    {
        var pos = transform.position + transform.forward * 3;

        var instance = Instantiate(Throwable, pos, Random.rotation);

        var body = instance.GetComponent<Rigidbody>();

        body.AddForce(transform.forward * Force);

        IsExhausted = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
