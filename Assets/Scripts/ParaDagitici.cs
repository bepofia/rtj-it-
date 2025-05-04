using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ParaDagitici : MonoBehaviour
{
    [System.Serializable]
    public class ParaBirim
    {
        public string ad; // Örn: Kedi, Köpek, Ahtapot
        public List<GameObject> demirParalar;
        public List<GameObject> kagitParalar;
    }

    [Header("Tüm Para Birimleri")]
    public List<ParaBirim> paraBirimleri;

    [Header("Dağıtım Noktaları")]
    public Transform spawnNoktasi;
    public Transform[] hedefNoktalar;

    [Header("UI")]
    public Text toplamTutarText;

    private int hedefIndex = 0;
    private List<GameObject> aktifParalar = new List<GameObject>();
    private string mevcutBirim = "";
    private float toplamTutar = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DagitRastgelePara();
        }
    }

    void DagitRastgelePara()
    {
        if (paraBirimleri.Count == 0) return;

        // Rastgele para birimi seç
        int index = Random.Range(0, paraBirimleri.Count);
        ParaBirim secilen = paraBirimleri[index];

        // Eski paraları sil
        foreach (GameObject para in aktifParalar)
        {
            Destroy(para);
        }
        aktifParalar.Clear();
        hedefIndex = 0;
        toplamTutar = 0;
        toplamTutarText.text = "0";

        // Demir + kağıtları birleştir
        List<GameObject> tumParalar = new List<GameObject>();
        tumParalar.AddRange(secilen.demirParalar);
        tumParalar.AddRange(secilen.kagitParalar);

        // Listeyi karıştır
        ShuffleList(tumParalar);

        // En az 1, en fazla 5 adet para seç
        int adet = Random.Range(1, Mathf.Min(6, tumParalar.Count + 1));
        List<GameObject> secilecekler = new List<GameObject>();

        for (int i = 0; i < adet; i++)
        {
            secilecekler.Add(tumParalar[i]);
        }

        StartCoroutine(ParalariDagit(secilen.ad, secilecekler));
    }

    IEnumerator ParalariDagit(string birimAdi, List<GameObject> paralar)
    {
        mevcutBirim = birimAdi;
        toplamTutar = 0;

        foreach (GameObject prefab in paralar)
        {
            GameObject para = Instantiate(prefab, spawnNoktasi.position, Quaternion.identity);

            var ps = para.GetComponent<ParaSurukle>();
            if (ps != null)
                ps.orijinalPrefab = prefab;

            var bilgi = para.GetComponent<ParaBilgi>();
            if (bilgi != null)
                toplamTutar += bilgi.miktar;

            aktifParalar.Add(para);

            Transform hedef = hedefNoktalar[hedefIndex % hedefNoktalar.Length];
            hedefIndex++;

            StartCoroutine(ParayiGotur(para.transform, hedef.position));
            yield return new WaitForSeconds(0.2f);
        }

        toplamTutarText.text = toplamTutar + " " + mevcutBirim;
    }

    IEnumerator ParayiGotur(Transform para, Vector3 hedef)
    {
        float zaman = 0f;
        Vector3 baslangic = para.position;

        while (zaman < 1f)
        {
            zaman += Time.deltaTime * 2f;
            para.position = Vector3.Lerp(baslangic, hedef, zaman);
            yield return null;
        }
    }

    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }

    public void ParaDegeriEkle(float miktar)
    {
        toplamTutar += miktar;
        toplamTutarText.text = toplamTutar + " " + mevcutBirim;
    }

    public void ParaDegerindenCikar(float miktar)
    {
        toplamTutar -= miktar;
        toplamTutar = Mathf.Max(0, toplamTutar);
        toplamTutarText.text = toplamTutar + " " + mevcutBirim;
    }
}