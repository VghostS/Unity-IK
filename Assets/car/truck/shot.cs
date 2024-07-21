using UnityEngine;

public class shot : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider hit) {
        GetComponentInChildren<ParticleSystem>().transform.parent = null;
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
