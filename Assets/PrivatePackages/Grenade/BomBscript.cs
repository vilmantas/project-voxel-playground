using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomBscript : MonoBehaviour
{
    public float DetonationTime = 5f;

    public float ExplosionRadius = 5f;

    public LayerMask HitMask;

    public float ExplosionForce = 5f;

    public ParticleSystem ExplosionParticles;

    public GameObject BombMesh;

    // Update is called once per frame
    void Update()
    {
        DetonationTime -= Time.deltaTime;

        if (DetonationTime > 0) return;

        var collisions = Physics.OverlapSphere(transform.position, ExplosionRadius, HitMask);

        foreach (var collision in collisions)
        {
            var col = collision.gameObject.GetComponent<Rigidbody>();

            if (col == null) col = collision.gameObject.GetComponentInChildren<Rigidbody>();

            if (col == null) col = collision.gameObject.GetComponentInParent<Rigidbody>();

            if (col == null) continue;

            col.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
        }

        var particles = Instantiate(ExplosionParticles, transform.position, new Quaternion());

        float totalDuration = particles.main.duration + particles.main.startLifetime.constantMax;

        Destroy(particles.gameObject, totalDuration);

        Destroy(transform.gameObject);
    }
    private void OnGUI()
    {
        //Rect rect = new Rect(0, 0, 50, 100);
        //Vector3 offset = new Vector3(0f, 0f, 0f); // height above the target position
        
        //Vector3 point = Camera.main.WorldToScreenPoint(transform.position + offset);

        //point.x -= 25;

        //GUIStyle x = new GUIStyle();
        //x.alignment = TextAnchor.MiddleCenter;
        //x.fontStyle = FontStyle.Bold;
        //x.normal.textColor = Color.red;

        //rect.x = point.x;
        //rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        //GUI.Label(rect, DetonationTime.ToString("0.0"), x); // display its name, or other string
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
