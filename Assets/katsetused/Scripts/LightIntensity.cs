using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    public float duration = 1.0F;
    public Light lt;
    public Score sc;

    void Start()
    {
        lt = GetComponent<Light>();
        sc = GameObject.Find("Cube").GetComponent<Score>();
    }

    void Update()
    {

    }
}
