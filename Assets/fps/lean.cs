using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lean : MonoBehaviour
{
       public fps fpsSc;
    public float speed;
    float leftRight;
    Quaternion initialRot;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        initialRot = transform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        //leftRight = fpsSc.xVal;

        leftRight = Mathf.SmoothDamp(leftRight, Input.GetAxis("Horizontal"), ref x, Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0,0,leftRight*speed);

    }
}
