using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] public Transform carryingPoint;
    private Vector2 movementInput;
    public bool working;
    public GameObject carryingProduct;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x * speed, rb.velocity.y, movementInput.y * speed);
        rb.velocity = movement;
    }
    public void OnMove(InputAction.CallbackContext ctx) 
    {
        movementInput = ctx.ReadValue<Vector2>();
    } 
    public void OnWork(InputAction.CallbackContext ctx)
    {
        working = ctx.ReadValue<float>() > 0.5f;
    }
}
