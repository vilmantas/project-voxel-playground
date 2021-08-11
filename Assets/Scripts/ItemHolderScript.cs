using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ItemHolderScript : MonoBehaviour
{
    public Transform Transform { get; private set; }

    void Awake()
    {
        Transform = GetComponent<Transform>();
    }
}
