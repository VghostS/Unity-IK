using UnityEngine;
using System.Collections;
 
public class recoil : MonoBehaviour
{
    private float Recoil = 0.0f;
    private float maxRecoil_x = -20f;
    private float maxRecoil_y = 20f;
    private float recoilSpeed = 2f;
 
    public void StartRecoil (float recoilParam, float maxRecoil_xParam, float recoilSpeedParam)
    {
        // in seconds
        Recoil = recoilParam;
        maxRecoil_x = maxRecoil_xParam;
        recoilSpeed = recoilSpeedParam;
        maxRecoil_y = Random.Range(-maxRecoil_xParam, maxRecoil_xParam);
    }
 
    void recoiling ()
    {
        if (Recoil > 0f) {
            Quaternion maxRecoil = Quaternion.Euler (maxRecoil_x, maxRecoil_y, 0f);
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp (transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);
            Recoil -= Time.deltaTime;
        } else {
            Recoil = 0f;
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.identity, Time.deltaTime * recoilSpeed / 2);
        }
    }
 
    // Update is called once per frame
    void Update ()
    {
        recoiling ();
    }
}