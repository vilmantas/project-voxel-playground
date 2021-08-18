using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimerScript : MonoBehaviour
{

    private float Countdown = 10f;

    public Text Text;

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        if (Countdown >= 0)
        {
            Text.text = Countdown.ToString(); ;
        } else
        {
            Text.text = "Done";
        }
    }
}
