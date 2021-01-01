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
        if (_trasform.position.z > 4)
        {
            playerController.MoveFront(true);
        }
        else
        {

            if (_trasform.position.z < -4)
            {
                playerController.MoveBack(true);
            }
            else
            {
                playerController.MoveBack(false); //se chiamato con il false, fa rimare fermo il player
            }
        }
        if (_shoulderLeftTrasform.position.z - _shoulderRightTrasform.position.z > 0.07f)
            mouseManager.CameraRotationRight(true);
        else
        {
            if (_shoulderLeftTrasform.position.z - _shoulderRightTrasform.position.z < -0.07f)
                mouseManager.CameraRotationLeft(true);
            else
            {
                mouseManager.CameraRotationRight(false); //blocca la rotazione se passato un valore false
            }
        }

    }
}
