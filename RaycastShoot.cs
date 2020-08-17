using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{

    public float maxDistance = 100f;
    public float recoil = 100f;
    public float shootTime = 1f;
    float shootedTime=0f;
    public int bullets=8;
    public GameObject bulletHolePlane;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        float distance = 0f;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && Time.time  > shootedTime+shootTime )
        {
            distance = hit.point.z - transform.position.z;
            Vector3[] bulletsArray = new Vector3[bullets];
            bulletsArray = BulletLoc(distance, bullets, recoil, hit.point);
            for (int i = 0; i < bullets; i++)
            {
                Instantiate(bulletHolePlane, bulletsArray[i], Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
            shootedTime = Time.time;
        }
    }
    public Vector3[] BulletLoc(float distance, int bullets,float recoil, Vector3 shootLocation)
    {
        Vector3[] bulletsArray = new Vector3[bullets];
        Vector3 createHole = new Vector3(0, 0, 0);
        for (int i = 0; i < bullets; i++)
        { 
            createHole.x = shootLocation.x + distance / recoil;
            float randomPoint = Random.Range(shootLocation.x, createHole.x);
            createHole.x = randomPoint;

            createHole.y = shootLocation.y + distance / recoil;
            float randomPoint2 = Random.Range(shootLocation.y, createHole.y);
            createHole.y = randomPoint2;
            createHole.z = shootLocation.z-0.01f;
            bulletsArray[i] = createHole;
        }
        return bulletsArray;  
    }
  
}
