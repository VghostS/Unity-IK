using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class enable : MonoBehaviour
{
    public GameObject [] goPieces;
    public GameObject [] goBuildings;
    public float redius = 50, force = 50;
    public ParticleSystem exp;
    public void destroy()
    {
        exp.Play();
        foreach(GameObject go in goBuildings)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in goPieces)
        {
            go.SetActive(true);

            go.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, redius);
        }
    }
}
