using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ArcReactor.Demo.ArcReactorDemoGunController;

public class CameraRayScript : MonoBehaviour
{

    public GunDefinition gun;

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Enemy")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit Enemy");

                if (gun.continuous)
                {
                    if  (gun.launcher.Rays.Count == 0)
                    {
                        gun.launcher.LaunchRay();
                    }
                }

                hit.transform.gameObject.GetComponent<EnemyHealth>().AddjustCurrentHealth(-1);

            }
        }
        else
        {
            if (gun.continuous && gun.launcher.Rays.Count > 0)
            {
                foreach (ArcReactor_Launcher.RayInfo ray in gun.launcher.Rays)
                {
                    ray.arc.playBackward = true;
                    ray.arc.freeze = false;
                }
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
