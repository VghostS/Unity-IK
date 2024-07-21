using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKLeg : MonoBehaviour
{
    Vector3 StartPos;
    public float MostDistance = 1f;
    public float moveSpeed;
    public bool startMoving;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(StartPos, transform.position);

        if(dist > MostDistance)
        {
            startMoving = true;
        }
        if(dist < 0.1f)
        {
            startMoving = false;
        }

        if(startMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos() {
                StartPos = transform.position;

        Gizmos.DrawWireSphere(StartPos, 0.1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(StartPos, MostDistance);
    }
}
