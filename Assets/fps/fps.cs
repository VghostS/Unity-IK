using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{

  public float mouseSensitivity = 100f;

  public Transform playerbody;
  public bool aiming;
  [Space(12)]
  public float XrotLimiterLeast = -50f;
  public float XrotLimiterMost = 50f;
        float xRotation = 0f;

        float mouseX,mouseY;
public CharacterController controller;
public float speed;
public float sprintSpeed;
public Animator anim;
public float smoother;
public camWalk camWalk;
        float AnimMove;
        float sprintMult, sprintMultTo;

    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       float mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime ;
       float mouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime ;

      xRotation -= mouseY;
      xRotation = Mathf.Clamp (xRotation, XrotLimiterLeast, XrotLimiterMost);


      transform.localRotation = Quaternion.Euler (xRotation, 0,0);

      playerbody.Rotate (Vector3.up * mouseX);

      		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
        
		Vector3 move = (playerbody.right * x + playerbody.forward * z).normalized;

        AnimMove = Mathf.Lerp(AnimMove, move.magnitude, smoother * Time.deltaTime);

        anim.SetFloat("moveSpeed", AnimMove * sprintMult);
        
    if(move.magnitude > 0.1f)
    camWalk.shake = true;else camWalk.shake = false;
		controller.Move (move * speed * sprintMult * Time.deltaTime);



    }

    private void Update() {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprintMultTo = sprintSpeed;
            camWalk.walkingBobbingSpeed = 17;
        }else 
        {
            sprintMultTo = 1;
            camWalk.walkingBobbingSpeed = 10;
        }

        sprintMult = Mathf.Lerp(sprintMult, sprintMultTo, smoother * Time.deltaTime);
    }

}