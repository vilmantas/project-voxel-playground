using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wtf : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(4 * Time.deltaTime, 0, 0);
    }
}
