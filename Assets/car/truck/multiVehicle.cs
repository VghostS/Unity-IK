using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiVehicle : MonoBehaviour
{
    public Transform[] FrontWheels;
    public WheelCollider[] FrontWheelsCollider;
    [Space(12)]
    public Transform[] BackWheels;
    public WheelCollider[] BackWheelsCollider;

        float Horizontal, Vertical;
            [Space(12)]
    public float MotorForce;
    public float steerAngle;
    public float brakeForce;
    public float brakeTorque;
            [Space(12)]
    public float boostForce;


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

       for(int  i = 0; i < FrontWheels.Length; i++)
       {
        WheelTransform(FrontWheelsCollider[i], FrontWheels[i]);
       } 
          for(int  i = 0; i < BackWheels.Length; i++)
       {
        WheelTransform(BackWheelsCollider[i], BackWheels[i]);
       } 

        Steer();

        if(Input.GetKey(KeyCode.Space))
        {
            Brake();
        }else
        {
            ReleaseBrake();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * boostForce, ForceMode.Impulse);
        }
    }

    void Brake()
    {
        foreach (WheelCollider wc in FrontWheelsCollider)
        {
            wc.brakeTorque = brakeForce;
        }
        foreach (WheelCollider wc in BackWheelsCollider)
        {
            wc.brakeTorque = brakeForce;
        }
    }

    void ReleaseBrake()
    {
        foreach (WheelCollider wc in FrontWheelsCollider)
        {
            wc.brakeTorque = 0;
        }
        foreach (WheelCollider wc in BackWheelsCollider)
        {
            wc.brakeTorque = 0;
        }
    }

        void Steer()
        {
        foreach (WheelCollider wc in FrontWheelsCollider)
        {
            wc.steerAngle = Horizontal * steerAngle;
        }

        }
        void Torque()
    {
        foreach(WheelCollider wc in FrontWheelsCollider)
        {
            wc.motorTorque = MotorForce * Vertical;
        }
        foreach(WheelCollider wc in BackWheelsCollider)
        {
            wc.motorTorque = MotorForce * Vertical;
        }
        
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
