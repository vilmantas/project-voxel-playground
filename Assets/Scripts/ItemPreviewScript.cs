using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreviewScript : MonoBehaviour
{
    public string ItemPreviewParentName = "ItemPreview";

    public GameObject ItemPreview;

    void Start()
    {
        var innerModel = GetComponentsInChildren<Transform>();



        foreach (var transform in innerModel)
        {
            if (transform.name == ItemPreviewParentName)
            {
                var preview = Instantiate(ItemPreview, transform);
                preview.transform.position = transform.position;
                break;
            }

            //if (transform.parent && transform.parent.name == name)
            //{
            //    transform.Rotate(Vector3.left, 45);
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
