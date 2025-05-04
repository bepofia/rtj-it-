using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtakOzellik : MonoBehaviour
{
    public float esasAgirlik;
    public float esasUzunlukX;
    public float esasUzunlukY;

    [Header("Para Özellikleri")]
    public bool paraMý;
    public bool orjinalParaMý;
    public int paraMiktarý;

    private void Update()
    {
        if(!paraMý)
        {
            orjinalParaMý = false;
            paraMiktarý = 0;
        }
    }
}
