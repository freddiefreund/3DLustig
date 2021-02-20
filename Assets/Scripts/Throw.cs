using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    [SerializeField] Transform cam = default;
    [SerializeField] GameObject ball = default;
    
    [SerializeField] float shootPowerMultiplier = 1f;
    [SerializeField] float maxChargeTime = 1.5f;

    [SerializeField] private Image crosshair;
    [SerializeField] float liveTime = 2f;
    
    float timeStamp = 0;
    private const float defaultCrosshairAlpha = 0.1f;
    private bool clicking = false;
    private float shootPower;

    private void Start()
    {
        setCrosshairAlpha();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeStamp = Time.time;
            clicking = true;
        }
        
        if (clicking)
        {
            shootPower = Time.time - timeStamp;
            shootPower = Mathf.Clamp(shootPower, 0.1f, maxChargeTime) * 1.5f;
            setCrosshairAlpha(shootPower / 3);
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
            var spawnLocation = cam.position + cam.forward * shootPowerMultiplier;   
            var obj = Instantiate(ball, spawnLocation, cam.rotation);
            obj.GetComponent<Rigidbody>().velocity = cam.forward * shootPower * 50;
            setCrosshairAlpha();
            Destroy(obj.gameObject, liveTime);
        }
    }

    void setCrosshairAlpha(float alpha = 0f)
    {
        Color c = crosshair.color;
        c.a = alpha + defaultCrosshairAlpha;
        crosshair.color = c;
    }
}
