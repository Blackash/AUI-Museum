using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderCheck : MonoBehaviour
{
    public bool isRange = false;

    [SerializeField] GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        isRange = true;
        door.tag = "Selectable";
        Debug.Log(isRange);
    }

    private void OnTriggerExit(Collider other)
    {
        isRange = false;
        door.tag = "Untagged";
        Debug.Log(isRange);
    }
}
