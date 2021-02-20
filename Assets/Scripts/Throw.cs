using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] GameObject ball;
    
    [SerializeField] float shootPowerMultiplier = 1f;
    [SerializeField] float maxChargeTime = 2f;
    
    float timeStamp = 0;
    float shootPower;
    
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
            var spawnLocation = camera.position + camera.forward * 1;   
            var obj = Instantiate(ball, spawnLocation, camera.rotation);
            obj.GetComponent<Rigidbody>().velocity = camera.forward * shootPower * 50;
        }
    }
}
