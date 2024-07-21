using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sway : MonoBehaviour
{

    public float value;
    public float maxAmount;
    public float swaySpeed;

        Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float x = -Input.GetAxis("Mouse X") * value;
        float y = -Input.GetAxis("Mouse Y") * value;

        x = Mathf.Clamp (x, -maxAmount, maxAmount);
        y = Mathf.Clamp (y, -maxAmount, maxAmount);

        Vector3 LastPosition = new Vector3 (x, y, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, LastPosition + initialPosition, Time.deltaTime * swaySpeed);
    }
}
