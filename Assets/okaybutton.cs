using UnityEngine;

public class okaybutton : MonoBehaviour
{
    private Saat saat;
    AudioSource audioSource;


    void Start()
    {
        saat = FindObjectOfType<Saat>();
        if (saat == null)
        {
            Debug.LogWarning("Saat nesnesi sahnede bulunamadý!");
        }

        audioSource = GetComponent<AudioSource>();  
    }

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(audioSource.clip);
        if (saat != null)
        {
            saat.YeniMusteriGel();
        }
    }

}
