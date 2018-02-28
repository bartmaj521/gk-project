using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 20.0F;

    public float rotationSpeed = 180;

    private Vector3 moveDirection = Vector3.zero;

    private new Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        camera.GetComponent<CameraMovement>().player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformVector(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        RaycastHit hitResult;

        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitResult, 1 << 8);

        Quaternion currentRotation = transform.rotation;
        hitResult.point = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z);
        Vector3 destinedDirection = hitResult.point - transform.position;
        Quaternion destinedRotation = Quaternion.LookRotation(destinedDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(currentRotation, destinedRotation, rotationSpeed * Time.deltaTime);
    }
}
