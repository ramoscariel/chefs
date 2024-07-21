using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] public Transform carryingPoint;
    [SerializeField] private float rotationSpeed = 10f;
    private Vector2 movementInput = Vector2.zero;

    private float yRotation = 0f;
    public bool interactPressed;
    public bool acceleratePressed;
    public GameObject carryingProduct;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if (acceleratePressed) 
        {
            movement = transform.forward * speed;
        }
        rb.velocity = movement;
    }
    private void Update()
    {
        yRotation += movementInput.x * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    public void OnMove(InputAction.CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
    } 
    public void OnInteract(InputAction.CallbackContext ctx)
    {
        interactPressed = ctx.ReadValue<float>() > 0.5f;
        Debug.Log("Interact Pressed");
    }
    public void OnAccelerate(InputAction.CallbackContext ctx)
    {
        acceleratePressed = ctx.ReadValue<float>() > 0.5f;
    }
}
