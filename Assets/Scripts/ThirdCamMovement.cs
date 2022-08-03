using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamMovement : MonoBehaviour
{
    [Header("References")]

    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public GameObject characterPrefab;
    public float rotationSpeed;
    public float moveSpeed;

    private void Update()
    {
        Rotation();
        Move();

    }

    private void Rotation()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            player.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }

    public void Move()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
       rb.AddForce(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);



        if (verticalInput > 0)
        {
            characterPrefab.GetComponent<Animator>().SetBool("isWalking", true);
            
        }
        else characterPrefab.GetComponent<Animator>().SetBool("isWalking", false);

        if (horizontalInput > 0)
        {
            characterPrefab.GetComponent<Animator>().SetBool("isWalking", true);

        }
        else characterPrefab.GetComponent<Animator>().SetBool("isWalking", false);









    }

}
