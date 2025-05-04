using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MüşteriScript : MonoBehaviour
{
    public Sprite M1Mutlu, M1Yavsak, M1Kızgın;
    public Sprite M2Mutlu, M2Yavsak, M2Kızgın;
    public Sprite M3Mutlu, M3Yavsak, M3Kızgın;
    public Sprite M4Mutlu, M4Yavsak, M4Kızgın;
    public Sprite M5Mutlu, M5Yavsak, M5Kızgın;

    public Image image;

    private int mevcutMusteriIndex = -1;
    private List<Sprite> mutluMusteriler;

    void Start()
    {
        mutluMusteriler = new List<Sprite> { M1Mutlu, M2Mutlu, M3Mutlu, M4Mutlu, M5Mutlu };
        YeniMusteri();
    }


    public void YeniMusteri()
    {
        mevcutMusteriIndex = Random.Range(0, mutluMusteriler.Count);
        image.sprite = mutluMusteriler[mevcutMusteriIndex];

        image.color = new Color(0f, 0f, 0f, 0f);
        image.DOColor(Color.white, 1f).SetEase(Ease.InOutQuad);
        //yeni para gelmesi için ivokelu method buraya
    }




    public void MusteriYavsakYap()
    {
        switch (mevcutMusteriIndex)
        {
            case 0: image.sprite = M1Yavsak; break;
            case 1: image.sprite = M2Yavsak; break;
            case 2: image.sprite = M3Yavsak; break;
            case 3: image.sprite = M4Yavsak; break;
            case 4: image.sprite = M5Yavsak; break;
        }
    }

    public void MusteriKizginYap()
    {
        switch (mevcutMusteriIndex)
        {
            case 0: image.sprite = M1Kızgın; break;
            case 1: image.sprite = M2Kızgın; break;
            case 2: image.sprite = M3Kızgın; break;
            case 3: image.sprite = M4Kızgın; break;
            case 4: image.sprite = M5Kızgın; break;
        }
    }

    public void MusteriGit()
    {
        image.DOColor(new Color(0f, 0f, 0f, 0f), 1f).SetEase(Ease.InOutQuad);
    }
}
