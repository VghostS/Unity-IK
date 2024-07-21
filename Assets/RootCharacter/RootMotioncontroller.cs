using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotioncontroller : MonoBehaviour
{
    public Animator anim;
                            float sprintMult;
                            bool facingRight;
    public float sprintSpeed;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis ("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(hor * sprintMult));

        if(Input.GetKey(KeyCode.LeftShift))
        sprintMult = Mathf.Lerp(sprintMult, 2, Time.deltaTime*sprintSpeed);
        else sprintMult = Mathf.Lerp(sprintMult, 1, Time.deltaTime*sprintSpeed);

        //Flip
        if (hor > 0 && facingRight) {//if you press left and yor are facing right face left
    			flip ();
    		} else if (hor < 0 && !facingRight) { // vice versa
    			flip ();
    		}

            if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("jump",true);
            }

    }

    void resetJump()
    {
                        anim.SetBool("jump",false);

    }

        void flip(){
      if(!facingRight)
      transform.localRotation = Quaternion.Euler(0, 0, 0);
        else transform.localRotation = Quaternion.Euler(0, 180, 0);
      facingRight = !facingRight;
      //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
