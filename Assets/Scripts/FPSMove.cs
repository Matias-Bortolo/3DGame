using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public float jumpSpeed;
    public Rigidbody myRigBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        Vector3 inputVector;
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");
        inputVector.y = Input.GetAxis("Strafe");

        transform.position += (transform.right * inputVector.y + transform.forward * inputVector.z) * moveSpeed * Time.deltaTime;

        transform.Rotate(0, inputVector.x * rotSpeed * Time.deltaTime, 0);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            myRigBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
}
