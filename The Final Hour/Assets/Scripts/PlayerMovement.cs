using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 20.0F;

    public float rotationSpeed = 180;

    private Vector3 moveDirection = Vector3.zero;

    public new Camera camera;

    private CharacterController controller;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Shoot();
    }

    //Handles the movement of player
    void Movement()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDirection = transform.TransformVector(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    //Rotates player face towards cursor
    void Rotation()
    {
        RaycastHit hitResult;

        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitResult, 1 << 8);

        Quaternion currentRotation = transform.rotation;
        hitResult.point = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z);
        Vector3 destinedDirection = hitResult.point - transform.position;
        Quaternion destinedRotation = Quaternion.LookRotation(destinedDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(currentRotation, destinedRotation, rotationSpeed * Time.deltaTime);
    }

    //TODO move this region to Gun class or smth
    #region shooting

    public GameObject bulletPrefab;

    public float firerate;

    private float cooldown;

    void Shoot()
    {
        if(Input.GetKey(KeyCode.Mouse0) && cooldown <= 0)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            cooldown = 1 / firerate;
        }
        cooldown -= Time.deltaTime;
    }

    #endregion
}
