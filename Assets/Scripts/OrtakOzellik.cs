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
    public int ParaMiktari;

    private void Update()
    {
        if(!paraMý)
        {
            orjinalParaMý = false;
            ParaMiktari = 0;
        }
    }
}
