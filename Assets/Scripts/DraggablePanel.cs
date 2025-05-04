using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class DraggablePanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 pointerOffset;
    public Image image;

    [Header("DOTween Ayarlarý")]
    public float tweenSpeed = 0.1f;
    public Ease tweenEase = Ease.OutQuad;

    [SerializeField] Sprite panelBlue;
    [SerializeField] Sprite panelRed;
    [SerializeField] Sprite panelGreen;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        image.sprite = panelBlue;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 localMousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localMousePos
        );

        pointerOffset = rectTransform.anchoredPosition - localMousePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPointerPosition))
        {
            Vector2 targetPos = localPointerPosition + pointerOffset;
            rectTransform.DOKill(); // önceki tween’i iptal et
            rectTransform.DOAnchorPos(targetPos, tweenSpeed).SetEase(tweenEase);
        }
    }

    public void BlueButton()
    {
        image.sprite = panelBlue;
    }
    public void RedButton()
    {
        image.sprite = panelRed;
    }
    public void GreenButton()
    {
        image.sprite = panelGreen;
    }

}
