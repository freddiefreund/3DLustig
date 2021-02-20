using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab = default;
    [SerializeField] float liveTime = 3;
    [SerializeField] float bulletSpeed = 40;

    float timeStamp = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeStamp)
        {
            timeStamp = Time.time + liveTime;
            var bullet = Instantiate(bulletPrefab, transform.position, Camera.main.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            Destroy(bullet.gameObject, liveTime);
        }
    }

}
