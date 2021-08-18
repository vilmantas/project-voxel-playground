using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class Aimer : MonoBehaviour
{
    public LayerMask Mask;

    private float y;

    PlayerInputActions Actions;

    public Text Text;

    [SerializeField]
    CharacterActionsController CharacterActionsController;

    // Start is called before the first frame update
    void Start()
    {
        Actions.CharacterControls.Enable();

        Actions.CharacterControls.Rotate.started += Handl2eRotation;

        Actions.CharacterControls.Rotate.performed += Handl2eRotation;

        Actions.CharacterControls.Rotate.canceled += Handl2eRotation;
    }

    private void Rotat2e()
    {
        transform.rotation *= Quaternion.Euler(-y * CharacterActionsController.MouseSpeed * Time.deltaTime, 0, 0);

        var newx = transform.rotation.eulerAngles.x;

        if (newx <= 340 && newx >= 45)
        {
            var zz = 0f;
            if (newx > 147.5)
            {
                zz = 340;
            }

            if (newx < 147.5)
            {
                zz = 45;
            }

            transform.rotation = Quaternion.Euler(zz, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }

    private void Handl2eRotation(CallbackContext context)
    {
        var loc = context.ReadValue<Vector2>();
        y = loc.y;
        ////var MouseY = -Input.GetAxis("Mouse Y") * 5 * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward * 20, Color.green);

        Rotat2e();
    }

    private void OnEnable()
    {
        if (Actions != null) Actions.CharacterControls.Enable();
    }

    private void Awake()
    {
        Actions = new PlayerInputActions();
    }

    private void OnDisable()
    {
        if (Actions != null) Actions.CharacterControls.Disable();
    }
}
