using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distanceshader : MonoBehaviour
{
    public Transform _track;
    public bool lightPlayer = true;
    public bool lightEnemy = false;

    void Start()
    {
        Shader.SetGlobalVector("_enemyPos", new Vector4(10000, 10000, 10000, 10000));
        Shader.SetGlobalVector("_playerPos", new Vector4(10000, 10000, 10000, 10000));
    }

    void Update()
    {
        if (lightEnemy)
            Shader.SetGlobalVector("_enemyPos", _track.position);
        if (lightPlayer)
            Shader.SetGlobalVector("_playerPos", transform.position);
    }
}
