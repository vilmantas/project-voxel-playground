using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class RotatorScript : MonoBehaviour
{

    public float RotationSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        var innerModel = GetComponentsInChildren<Transform>();

        foreach (var transform in innerModel)
        {
            if (transform.parent && transform.parent.name == name)
            {
                transform.Rotate(Vector3.left, 45);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }
}
