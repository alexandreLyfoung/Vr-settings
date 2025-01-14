using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groubdLayer;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;
    public void Update()
    {
        bool _isGrounded = isGrounded();
        
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded)
        {
            Jump();
        }
        movement.y += gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groubdLayer);

    }


}
