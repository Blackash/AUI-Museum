using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    private Material defaultMaterial;

    private Transform _selection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            if(Input.GetMouseButtonDown(0))
                {
                if(_selection.gameObject.GetComponent<DialogueTrigger>() != null)
                    _selection.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                if (_selection.gameObject.GetComponent<SelectableDialogue>() != null)
                    _selection.gameObject.GetComponent<SelectableDialogue>().dialogue();
                FindObjectOfType<PlayerMovement>().BlockMovement();
                }

            Renderer selectionRender = _selection.GetComponent<Renderer>();
            if(defaultMaterial != null)
                selectionRender.material = defaultMaterial;
            _selection = null;
            defaultMaterial = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                Renderer selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
            }
        }
    }
}
