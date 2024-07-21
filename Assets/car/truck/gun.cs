using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public ParticleSystem particleSystem1, particleSystem2;
    bool canShoot = true;
    public float Firerate = 0.2f;
    public Transform firePoint1, firePoint2;
    public GameObject shot;
    [Space(12)]
    public Transform aimPos;
    public LayerMask aimMask;
    public float AimSmoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canShoot)
        {
            Instantiate(shot, firePoint1.position, firePoint1.rotation);
            canShoot = false;
            particleSystem1.Play();
            Invoke("shootSec",0.15f);
        }

                Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if(Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, AimSmoothSpeed * Time.deltaTime);
        }

    }

    void shootSec()
    {
        Instantiate(shot, firePoint2.position, firePoint2.rotation);

        particleSystem2.Play();
        Invoke("resetShot", Firerate);
    }

    void resetShot()
    {
        canShoot = true;
    }
}
