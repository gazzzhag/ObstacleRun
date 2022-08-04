using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamMovement : MonoBehaviour
{
    [Header("References")]

    public Transform orientation;
    public Transform playerObj;

    public Animator animator;
    public Rigidbody rb;

    public float rotationSpeed;
    public float moveSpeed;

    private void Update()
    {
        Rotation();
        Move();
    }

    private void Rotation()
    {
        Vector3 inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (inputDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);

        const float threshold = .01f;
        if (rb.velocity.sqrMagnitude > threshold)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}