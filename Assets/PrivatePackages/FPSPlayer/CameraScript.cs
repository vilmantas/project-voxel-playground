using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Bomb;

    public LayerMask HitMask;

    public LayerMask Mask;

    public GameObject ObjectToPlace;

    public GameObject Sphere;

    public float explosionRadius = 5f;

    private GameObject exploder;

    private RaycastHit lastHit;

    public float Force;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out lastHit, 5000, Mask))
        //{
        //    ObjectToPlace.transform.position = lastHit.point;

        //    Debug.DrawRay(lastHit.point, Vector3.up * 15, Color.green);


        //}
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(lastHit.point, explosionRadius);
    }
}
