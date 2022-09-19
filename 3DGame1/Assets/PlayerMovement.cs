using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationSpeed = 90f;
    private float gravity = -20f;
    public float jumpHeight = 15f;

    public CharacterController characterController;
    Vector3 movementVector;
    Vector2 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            movementVector = transform.forward * movementSpeed * verticalInput;
            rotationVector = transform.up * rotationSpeed * horizontalInput;

            if (Input.GetButtonDown("Jump"))
            {
                movementVector.y = jumpHeight;
            }
        }

        movementVector.y += gravity * Time.deltaTime;
        characterController.Move(movementVector * Time.deltaTime);
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
