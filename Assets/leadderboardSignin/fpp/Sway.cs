using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public float swayValue;
    public float maxSway;
    public float swaySpeed;
    Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float x = -Input.GetAxis("Mouse X") * swayValue;
        float y = -Input.GetAxis("Mouse Y") * swayValue;

        x = Mathf.Clamp (x, -maxSway, maxSway);
        y = Mathf.Clamp (y, -maxSway, maxSway);

        Vector3 LastPosition = new Vector3 (x, y, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, LastPosition + initialPos, Time.deltaTime * swaySpeed);

    }
}
