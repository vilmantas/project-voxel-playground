using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIsMovingScript : MonoBehaviour
{
    public MovementScript Movement;

    public Text Text;

    // Update is called once per frame
    void Update()
    {
        Text.text = Movement.IsMoving.ToString();
    }
}
