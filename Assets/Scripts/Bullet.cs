using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("_bulletPos", transform.position);
    }

    void OnDestroy()
    {
        Shader.SetGlobalVector("_bulletPos", new Vector4(10000, 10000, 10000, 10000));
    }
}
