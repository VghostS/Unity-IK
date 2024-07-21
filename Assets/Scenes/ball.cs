using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject theBall;
    public float force;
    // Start is called before the first frame update
    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody rb = Instantiate(theBall, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward*force);
        }
    }
}
