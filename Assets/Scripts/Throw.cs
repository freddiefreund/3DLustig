using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Transform cam = default;
    [SerializeField] GameObject ball = default;
    
    [SerializeField] float shootPowerMultiplier = 1f;
    [SerializeField] float maxChargeTime = 2f;
    
    float timeStamp = 0;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeStamp = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float shootPower = Time.time - timeStamp;
            shootPower = Mathf.Clamp(shootPower, 0.1f, maxChargeTime);
            var spawnLocation = cam.position + cam.forward * shootPowerMultiplier;   
            var obj = Instantiate(ball, spawnLocation, cam.rotation);
            obj.GetComponent<Rigidbody>().velocity = cam.forward * shootPower * 50;
        }
    }
}
