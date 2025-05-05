using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTween kullanýmý için

public class kartsils : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bas")
        {
            // SpriteRenderer var mý kontrol et
            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                // Opaklýk (alpha) 0'a düþürülüyor
                sr.DOFade(0f, 0.5f);
            }

            // Ölçek küçültülüyor
            collision.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                Destroy(collision.gameObject);
            });
        }
    }
}
