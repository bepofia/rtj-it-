using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainParaManager : MonoBehaviour
{
    [Header("Orijinal Paralar")]
    public GameObject[] pembeOrijinalParalar;
    public GameObject[] maviOrijinalParalar;
    public GameObject[] YesilOrijinalParalar;

    [Header("Sahte Paralar")]
    public GameObject[] pembeSahteParalar;
    public GameObject[] maviSahteParalar;
    public GameObject[] YesilSahteParalar;

    [Header("Spawn Ayarlarý")]
    public Transform spawnParent;
    public float spawnRadius = 0.5f;

    private Transform hedefTransform;

    public int toplamParaMiktari;

    void Start()
    {

        Invoke("SpawnParalar", 1f);
    }

    void SpawnParalar()
    {
        GameObject[] orijinallar = maviOrijinalParalar;
        GameObject[] sahteler = maviSahteParalar;

        string paraRengi = "Mavi";


        int totalToSpawn = Random.Range(2, 9);
        List<GameObject> paralarToSpawn = new List<GameObject>();

        bool hepsiOrijinalMi = Random.value < 0.5f;

        if (hepsiOrijinalMi)
        {
            for (int i = 0; i < totalToSpawn; i++)
                paralarToSpawn.Add(orijinallar[Random.Range(0, orijinallar.Length)]);
        }
        else
        {
            int sahteCount = Random.Range(1, totalToSpawn);
            int orijinalCount = totalToSpawn - sahteCount;

            for (int i = 0; i < orijinalCount; i++)
                paralarToSpawn.Add(orijinallar[Random.Range(0, orijinallar.Length)]);

            for (int i = 0; i < sahteCount; i++)
                paralarToSpawn.Add(sahteler[Random.Range(0, sahteler.Length)]);
        }

        ShuffleList(paralarToSpawn);

        float verticalOffset = -0.2f;
        float verticalSpacing = 0.3f;
        Vector3 basePos = transform.position + Vector3.up * verticalOffset;

        toplamParaMiktari = 0;

        for (int i = 0; i < paralarToSpawn.Count; i++)
        {
            GameObject paraPrefab = paralarToSpawn[i];

            Vector3 spawnPos = basePos + Vector3.down * (i * verticalSpacing);

            GameObject yeniPara = Instantiate(paraPrefab, spawnPos, Quaternion.identity);
            yeniPara.tag = "götmasyon";

            SpriteRenderer sr = yeniPara.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sortingOrder = 70;
            }

            OrtakOzellik ozellik = yeniPara.GetComponent<OrtakOzellik>();
            if (ozellik != null)
            {
                toplamParaMiktari += ozellik.ParaMiktari;
            }
        }

        Debug.Log($"Oluþturulan {paraRengi} paralarýn toplam miktarý: {toplamParaMiktari}");
    }


    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randIndex = Random.Range(i, list.Count);
            (list[i], list[randIndex]) = (list[randIndex], list[i]);
        }
    }
}
