using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField] public Canvas canvas;
    [SerializeField] public DressSO dressSO;
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
        gameObject.GetComponent<Image>().sprite = dressSO.dressImageCloset;
        
    }

    //Quando inizia un drag, viene creato un clone della UI dell'oggetto in cui stiamo facendo il drag, questo clone serve per dare l'effetto "l'oggetto rimane nella sua posizione dell'inventario finchè non viene posizionato in un'altra slot o droppato"
    //questo oggetto clone verrà distrutto in OnEndDrag
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

        if(gameObject.GetComponent<Image>().sprite!=null)
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
    //rispetto alla posizione di dove è finito il drag viene avviata una determinata funzione in charInventary: 
    //se l'oggetto è fuori i margini dell'inventary questo verrà droppato chiamando removeItem
    //se l'oggetto è all'interno dei margini verrà riposizionato nella posizione del clone, che è quella iniziale del drag e verrà distrotto il clone, l'oggetto all'interno però potrebbe essere stato switchato, guardare lo script drop.cs per maggiori info
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




    //per fare il click destro
    //Se è stato usato il tasto destro su una cella, questa prova ad azzionare il TryUseItem che c'è dell'oggetto al suo interno
    public void OnPointerClick(PointerEventData eventData)
    {
       
            
            
    }


    public DressType GetDressType()
    {
        return dressSO.dressType;
    }

    public SocialClass  GetSocialClass()
    {
        return dressSO.socialClass;
    }

    public DressSO getDressSO()
    {
        return dressSO;
    }
}
