using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIsMovingScript : MonoBehaviour
{
    public CharacterActionsController Movement;

    public Text Text;

    // Update is called once per frame
    void Update()
    {
        Text.text = Movement.isMovementPrssed.ToString();
    }
}
