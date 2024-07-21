using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour
{
    Quaternion initialRot;
    float value;
    public float speed;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        initialRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.SmoothDamp(value , Input.GetAxis("Horizontal"), ref x, Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0, 0, value * speed);
    }
}
