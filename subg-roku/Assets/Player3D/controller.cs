using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float mvmnt = 5f;         
    public float jump= 5f;         
    public float sensa = 2f;         
    public Transform cm;    
    public LayerMask gronded;         

    private Rigidbody rb;
    private float rotationX = 0f;     
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; 



        //////////////////////////////////////////////
    }






    void Update()
    {
        Move();
        Jump();
        LookAround();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * mvmnt;
        float z = Input.GetAxis("Vertical") * mvmnt;

        Vector3 move = transform.TransformDirection(x, 0, z);
        //move.Normalize();
        rb.MovePosition(rb.position + move * Time.deltaTime);
    }

    private void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, gronded);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensa;
        float mouseY = Input.GetAxis("Mouse Y") * sensa;

            rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);





        cm.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
