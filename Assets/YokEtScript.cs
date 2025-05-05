using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokEtScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "götmasyon")
        {
            Transform hedef = collision.transform;

            // Ayný anda scale küçült ve alpha sýfýrla
            hedef.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
            SpriteRenderer sr = hedef.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.DOFade(0f, 0.5f).SetEase(Ease.InQuad);
            }

            // Animasyon bitince objeyi yok et
            Destroy(collision.gameObject, 0.55f);
        }
    }
}
