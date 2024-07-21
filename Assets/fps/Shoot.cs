using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    public Animator anim;
    public ParticleSystem ShootVfx, smokeVfx;
    bool canshoot;
    [Space(12)]
    public int shots;
    public int magzineCapacity;
    public int totalShots;
    [Space(12)]
    public Camera fpsCam;
     private float range = 1000f;
     public int numberOfProjectilesPerShot = 8;
     public int damagePerProjectile = 10;
     public float spreadPrimary = 0.2f;
     [Space(12)]
     public GameObject bloodSplash;
    // Start is called before the first frame update
    void Start()
    {
        canshoot = true;
        shots = magzineCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canshoot && shots > 0)
        {
            anim.Play("shoot");
            ShootVfx.Play();
            smokeVfx.Stop(); smokeVfx.Play();
            canshoot = false;

                for(int i = 0; i < numberOfProjectilesPerShot; i++)
            {
                RaycastShoot();
            }
        }
    }

    void RaycastShoot()
    {
        RaycastHit hit;
        Vector3 direction = fpsCam.transform.forward; // your initial aim.
        Vector3 spread = Vector3.zero;
        spread+= fpsCam.transform.up * Random.Range(-1f, 1f); // add random up or down (because random can get negative too)
        spread+= fpsCam.transform.right * Random.Range(-1f, 1f); // add random left or right

        // Using random up and right values will lead to a square spray pattern. If we normalize this vector, we'll get the spread direction, but as a circle.
        // Since the radius is always 1 then (after normalization), we need another random call. 
        direction += spread.normalized * Random.Range(0f, spreadPrimary);

        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
        {
            Debug.DrawLine(fpsCam.transform.position, hit.point, Color.green, 1f);

        }
        else
        {
            Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.position + direction * range, Color.red, 1f);
        }
    }

    public void stopShot()
    {
                    anim.SetBool("shoot", false);

    }

    public void resetShot()
    {
        canshoot = true;
    }
}
