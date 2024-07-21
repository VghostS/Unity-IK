using UnityEngine;

public class cyl : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up*speed* Time.deltaTime);  
    }
}
