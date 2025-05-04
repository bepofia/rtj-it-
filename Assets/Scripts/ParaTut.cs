using UnityEngine;
using DG.Tweening;

public class ParaTut : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;

    private Transform hedefTransform; // Artýk otomatik atanacak
    [SerializeField] private float animasyonSuresi = 0.5f;

    void Awake()
    {
        cam = Camera.main;

        // "TransformEþitle" tagli nesneyi bul ve hedef olarak ata
        GameObject hedefObj = GameObject.FindWithTag("TransformEþitle");
        if (hedefObj != null)
        {
            hedefTransform = hedefObj.transform;
        }
        else
        {
            Debug.LogWarning("Tag 'TransformEþitle' olan nesne bulunamadý!");
        }
    }

    public void StartDrag()
    {
        if (cam == null) cam = Camera.main;

        isDragging = true;
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;

                if (hedefTransform != null)
                {
                    transform.DOScale(hedefTransform.localScale, animasyonSuresi);
                    transform.DORotate(hedefTransform.eulerAngles, animasyonSuresi, RotateMode.Fast);
                }
            }
        }
    }
}
