using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class YRotationScript : MonoBehaviour
{
    void Reset()
    {
        var rot = Random.Range(0, 3);

        var transform = GetComponent<Transform>();

        transform.Rotate(Vector3.up, rot * 90);
    }
}
