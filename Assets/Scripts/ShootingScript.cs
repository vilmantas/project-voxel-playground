using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : ActivatableItem
{
    public GameObject ButtletModel;

    public float BulletSpeed;

    public override void Activate()
    {
        var transform = GetComponent<Transform>();

        var bullet = Instantiate(ButtletModel, transform.position, transform.rotation);

        var rb = bullet.GetComponentInChildren<Rigidbody>();

        rb.velocity = bullet.transform.forward * BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (false)// (Input.GetKeyUp(KeyCode.E))
        {
            var transform = GetComponent<Transform>();

            var bullet = Instantiate(ButtletModel, transform.position, transform.rotation);

            var rb = bullet.GetComponentInChildren<Rigidbody>();

            rb.velocity = bullet.transform.forward * BulletSpeed;
            //rb.AddForce(Vector3.up * BulletSpeed);
        }
    }
}
