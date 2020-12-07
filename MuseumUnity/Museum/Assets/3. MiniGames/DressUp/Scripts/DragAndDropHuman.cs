using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragAndDropHuman : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private SocialClass socialClass;
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

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        startingPosition = rectTransform.anchoredPosition;
        _lastPointerData = eventData;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    //Sposta l'oggetto selezionato seguendo il mouse
    public void OnDrag(PointerEventData eventData)
    {

        //if (gameObject.GetComponent<Image>().sprite != null)
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

            // Reset position here
        }
    }




    public void OnPointerClick(PointerEventData eventData)
    {

    }


    public SocialClass GetSocialClass()
    {
        return socialClass;
    }

}
