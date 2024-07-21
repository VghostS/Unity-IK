using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fppCtrl : MonoBehaviour
{
    public float mouseSensitivity = 60;
    public float speed;
    [Space(12)]
    public float xMouseMost;
    public float xMouseLeast;
    [Space(12)]
    public Transform playerBody;
    [Space(12)]
    public CharacterController characterController;
    public Animator anim;
    public float smoother;
    [Space(12)]
    public float sprintValue = 2;
    public float sprintSmoother;
    float sprintMult, sprintMultTo;
    [Space(12)]
    public Transform groundCheck;
    public float groundCheckDistance;
    public float jumpspeed;
    public float gravity;
                                float xRot;
                                float animMove;
                                Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -=mouseY;

        xRot = Mathf.Clamp(xRot, xMouseLeast, xMouseMost);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");

        Vector3 move = (playerBody.right * InputX + playerBody.forward * InputY).normalized;
        characterController.Move(move * Time.deltaTime * speed * sprintMult);

        animMove = Mathf.Lerp(animMove, move.magnitude * sprintMult, smoother * Time.deltaTime);
        anim.SetFloat("speed", animMove);

        sprintMult = Mathf.Lerp(sprintMult, sprintMultTo, Time.deltaTime * sprintSmoother);
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            velocity.y = jumpspeed;
        }else 
        {
            velocity.y += gravity * Time.deltaTime;
        }

        characterController.Move(velocity * Time.deltaTime);


        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprintMultTo = sprintValue;
        }else
        {
            sprintMultTo = 1;
        }
    }

    bool isGrounded()
    {
        RaycastHit hit;
        if(Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundCheckDistance))
        {
            return true;
        }else return false;
    }
}
