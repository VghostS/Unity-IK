using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform WheelForwardLeft, WheelForwardRight, WheelBackwardLeft, WheelBackwardRight;
    public WheelCollider WheelColliderFrontLeft, WheelColliderFrontRight, WheelColliderbackLeft, wheelColliderbackRight;
    float Horizontal, Vertical;
    [Space(12)]
    public float MotorForce;
    public float steerAngle;
    public float brakeForce;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Torque();
        WheelTransform(WheelColliderFrontLeft, WheelForwardLeft);
        WheelTransform(WheelColliderFrontRight, WheelForwardRight);
        WheelTransform(WheelColliderbackLeft, WheelBackwardLeft);
        WheelTransform(wheelColliderbackRight, WheelBackwardRight);

        WheelColliderFrontLeft.steerAngle = Horizontal * steerAngle;
        WheelColliderFrontRight.steerAngle = Horizontal * steerAngle;

        if(Input.GetKey(KeyCode.Space))
        {
            Brake();
        }else
        {
            ReleaseBrake();
        }
    }

    void Torque()
    {
        WheelColliderFrontLeft.motorTorque = Vertical * MotorForce;
        WheelColliderbackLeft.motorTorque = Vertical * MotorForce;
        WheelColliderFrontRight.motorTorque = Vertical * MotorForce;
        wheelColliderbackRight.motorTorque = Vertical * MotorForce;
    }

    void Brake()
    {
        WheelColliderbackLeft.brakeTorque = brakeForce;
        wheelColliderbackRight.brakeTorque = brakeForce;
        WheelColliderFrontLeft.brakeTorque = brakeForce;
        WheelColliderFrontRight.brakeTorque = brakeForce;

    }

    void ReleaseBrake()
    {
        WheelColliderbackLeft.brakeTorque = 0;
        wheelColliderbackRight.brakeTorque = 0;
        WheelColliderFrontLeft.brakeTorque = 0;
        WheelColliderFrontRight.brakeTorque = 0;

    }

    void WheelTransform(WheelCollider wheelCollider, Transform WheelTransform)
    {
        Vector3 pos; Quaternion Rot;
        wheelCollider.GetWorldPose(out pos, out Rot);
        WheelTransform.position = pos;
        WheelTransform.rotation = Rot;
    }

    void GetInput()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
}
