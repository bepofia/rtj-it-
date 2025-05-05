using System.Collections;
using UnityEngine;

public class Saat : MonoBehaviour
{
    public GameObject yelkovan;
    public float süre = 50f;
    public MüþteriScript musteriScript; // Müþteri script'e referans

    private Coroutine saatCoroutine;
    private float toplamDonus = 0f;
    private bool calisiyor = true;

    private bool yavsakOldu = false;
    private bool kizginOldu = false;

    void Start()
    {
        saatCoroutine = StartCoroutine(SaatBasla());
        musteriScript = FindObjectOfType<MüþteriScript>();
    }

    

    private IEnumerator SaatBasla()
    {
        float derecePerSecond = 360f / süre;

        while (calisiyor)
        {
            float deltaRotation = derecePerSecond * Time.deltaTime;
            yelkovan.transform.Rotate(0f, 0f, -deltaRotation);
            toplamDonus += Mathf.Abs(deltaRotation);

            float oran = toplamDonus / 360f;

            if (!yavsakOldu && oran >= 1f / 3f)
            {
                musteriScript.MusteriYavsakYap();
                yavsakOldu = true;
            }

            if (!kizginOldu && oran >= 2f / 3f)
            {
                musteriScript.MusteriKizginYap();
                kizginOldu = true;
            }

            if (toplamDonus >= 360f)
            {
                calisiyor = false;
                musteriScript.MusteriGit();
                Invoke("YeniMusteriGel", 6f);
            }

            yield return null;
        }
    }

    public void SaatiDurdur()
    {
        if (saatCoroutine != null)
        {
            StopCoroutine(saatCoroutine);
            calisiyor = false;
        }
    }

    public void YeniMusteriGel()
    {
        musteriScript.YeniMusteri();

        toplamDonus = 0f;            // Yeni saat için sýfýrla
        yavsakOldu = false;          // Durumlarý sýfýrla
        kizginOldu = false;
        calisiyor = true;            // Saat tekrar çalýþacak

        yelkovan.transform.rotation = Quaternion.identity; // Yelkovaný sýfýrla

        StartCoroutine(SaatBasla());
    }
}
