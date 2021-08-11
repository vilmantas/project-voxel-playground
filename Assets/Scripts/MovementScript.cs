using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementScript : MonoBehaviour
{
    private CharacterController Character;

    [Range(1, 100)]
    public float MovementSpeed = 5f;

    public float MouseSpeed = 25;

    [Range(1, 100)]
    public float Gravity = 9.8f;

    public bool UseGravity = true;

    public KeyCode Forward = KeyCode.W;

    public KeyCode Backward = KeyCode.S;

    public KeyCode Left = KeyCode.A;

    public KeyCode Right = KeyCode.D;


    [HideInInspector]
    public bool IsMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //var MouseX = Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime;
        ////var MouseY = -Input.GetAxis("Mouse Y") * 5 * Time.deltaTime;
        //transform.rotation *= Quaternion.Euler(0, MouseX, 0);
        //HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 s = Vector3.zero;
        s += HandleMovementKey(Forward, Character.transform.forward);
        s += HandleMovementKey(Backward, -Character.transform.forward);
        s += HandleMovementKey(Left, -Character.transform.right);
        s += HandleMovementKey(Right, Character.transform.right);

        var velocity = transform.forward * Input.GetAxis("Vertical") * 25;
        var vSpeed = 0f;
        if (Character.isGrounded)
        {
            vSpeed = 0; // grounded character has vSpeed = 0...
            if (Input.GetKeyDown("space"))
            { // unless it jumps:
                vSpeed = 20;
            }
        }
        // apply gravity acceleration to vertical speed:
        vSpeed -= Gravity * Time.deltaTime;
        s.y = vSpeed; // include vertical speed in vel

        Character.Move(s * Time.deltaTime);

        IsMoving = Character.velocity != Vector3.zero;

        GetComponent<Animator>().SetBool("IsMoving", IsMoving);
    }

    private Vector3 HandleMovementKey(KeyCode input, Vector3 direction)
    {
        if (Input.GetKeyDown(input) || Input.GetKey(input))
        {
            return direction * MovementSpeed;
        }

        return Vector3.zero;
    }

    //private Color startcolor;
    //void OnMouseEnter()
    //{
    //    startcolor = GetComponentInChildren<Renderer>().material.color;

    //    var comps = GetComponentsInChildren<Renderer>();

    //    for (var i = comps.Length - 1; i >= 0; i--)
    //    {
    //        comps[i].material.color = Color.yellow;
    //    }
    //}
    //void OnMouseExit()
    //{
    //    var comps = GetComponentsInChildren<Renderer>();
    //    for (var i = comps.Length-1; i >= 0; i--)
    //    {
    //        comps[i].material.color = startcolor;
    //    }
    //}
}
