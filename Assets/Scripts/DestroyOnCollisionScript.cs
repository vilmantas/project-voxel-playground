using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionScript : MonoBehaviour
{
    [Range(0, 5)]
    public float DestroyInSeconds = 2;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, DestroyInSeconds);
    }
}
