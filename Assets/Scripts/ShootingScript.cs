using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : ActivatableItem
{
    public GameObject ButtletModel;

    public float BulletSpeed;

    public override void Activate(ActivatableTriggerer activatableTriggerer)
    {
        Shoot();
    }

    public override void Activate()
    {
        Shoot();
    }

    private void Shoot()
    {
        var transform = GetComponent<Transform>();

        var bullet = Instantiate(ButtletModel, transform.position, transform.rotation);

        var rb = bullet.GetComponentInChildren<Rigidbody>();

        rb.velocity = bullet.transform.forward * BulletSpeed;
    }
}
