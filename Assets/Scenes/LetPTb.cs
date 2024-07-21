using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetPTb : MonoBehaviour
{
    public Transform myTarget;
    public float distToTargetReq;
    public bool inPlace;
    public bool wasOutside;
    [Space(12)]
    public float spped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, myTarget.position);
        if (dist > distToTargetReq)
        {
            wasOutside = true;
        }
            if(!inPlace && wasOutside)
            myTarget.position = Vector3.MoveTowards(myTarget.position, transform.position, spped * Time.deltaTime);

        if(myTarget.position == transform.position)
        {
            inPlace = true;
            wasOutside = false;
        }else 
        {
            inPlace = false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, distToTargetReq);
    }
}
