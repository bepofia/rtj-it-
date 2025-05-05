using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
