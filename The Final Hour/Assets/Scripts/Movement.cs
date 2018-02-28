using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 20.0F;

    public float rotationSpeed = 180;
    private Vector3 moveDirection = Vector3.zero;

    public Camera camera;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        RaycastHit hitResult;

        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitResult, 1 << 8);

        Quaternion currentRotation = transform.rotation;
        Quaternion destinedRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        //hitResult.point;



        //moveDirection.y = 0;
        //if (moveDirection.magnitude > 0)
        //{
        //    Quaternion currentRotation = transform.rotation;
        //    Quaternion destinedRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        //    transform.rotation = Quaternion.RotateTowards(currentRotation, destinedRotation, rotationSpeed * Time.deltaTime);
        //}
    }
}
