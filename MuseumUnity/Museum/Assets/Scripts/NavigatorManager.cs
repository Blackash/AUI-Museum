using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigatorManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerController;
    [SerializeField] GameObject shoulderRight;
    [SerializeField] GameObject shoulderLeft;
    private Transform _shoulderRightTrasform;
    private Transform _shoulderLeftTrasform;
    private Transform _trasform;
    private MouseLook mouseManager;
    // Start is called before the first frame update
    void Start()
    {
        _trasform = gameObject.transform;
        mouseManager = playerController.GetComponentInChildren<MouseLook>();
        _shoulderRightTrasform = shoulderRight.transform;
        _shoulderLeftTrasform = shoulderLeft.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MinigameManager.Instance.GetIfCanAction())
            return;
        if (_trasform.position.z > 0.8f)
        {
            playerController.MoveFront(true);
        }
        else
        {

            if (_trasform.position.z < -0.3)
            {
                playerController.MoveBack(true);
            }
            else
            {
                playerController.MoveBack(false); //se chiamato con il false, fa rimare fermo il player
            }
        }
        if (_shoulderLeftTrasform.localPosition.z - _shoulderRightTrasform.localPosition.z > 0.4f)
            mouseManager.CameraRotationRight(true);
        else
        {
            if (_shoulderLeftTrasform.localPosition.z - _shoulderRightTrasform.localPosition.z < -0.4f)
                mouseManager.CameraRotationLeft(true);
            else
            {
                mouseManager.CameraRotationRight(false); //blocca la rotazione se passato un valore false
            }
        }

    }
}
