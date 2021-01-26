using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragAndDropOffering : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private OfferingSO offeringSO;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private PointerEventData _lastPointerData;
    private Vector2 startingPosition;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }
    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = offeringSO.offeringImage;
  
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        startingPosition = rectTransform.anchoredPosition;
        _lastPointerData = eventData;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {

        if (gameObject.GetComponent<Image>().sprite != null)
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

      public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = startingPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void CancelDrag()
    {
        if (_lastPointerData != null)
        {
            _lastPointerData.pointerDrag = null;

        }
    }




    public void OnPointerClick(PointerEventData eventData)
    {


    }


    public God GetGodOffering()
    {
        return offeringSO.godOffering;
    }
}
