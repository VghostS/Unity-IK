using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
    public bool fullAuto;
                            bool canShoot;
    [Space(12)]
    public Transform shootPoint;
    public GameObject shot;
    public float bulletSpeed;
    [Space(12)]
    public Animator anim;
    [Space(12)]
    public Recoil recoil;
    public float recoiltime;
    public float maxrecoil;
    public float recoilSpeed;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(fullAuto)
        {
            if(Input.GetMouseButton(0) && canShoot)
            {
                canShoot = false;
                anim.Play("assault_shoot");
                GameObject bullet = Instantiate(shot, shootPoint.position, shootPoint.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
                recoil.StartRecoil(recoiltime, maxrecoil, recoilSpeed);
            }
        }else 
        {
            if(Input.GetMouseButtonDown(0) && canShoot)
            {
                canShoot = false;
                anim.Play("assault_shoot");
                GameObject bullet = Instantiate(shot, shootPoint.position, shootPoint.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
                recoil.StartRecoil(recoiltime, maxrecoil, recoilSpeed);

            }
        }
    }

    public void resetShot()
    {
        canShoot = true;
    }
}
