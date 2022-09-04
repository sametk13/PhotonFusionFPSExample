using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraHandler : MonoBehaviour
{
    public Transform CameraAnchorPoint;

    Vector2 viewInput;

    float cameraRotationX = 0;
    float cameraRotationY = 0;


    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;

    Camera localCamera;

    private void Awake()
    {
        localCamera = GetComponent<Camera>();
        networkCharacterControllerPrototypeCustom = GetComponentInParent<NetworkCharacterControllerPrototypeCustom>();
    }

    private void Start()
    {
        if (localCamera.enabled)
        {
            localCamera.transform.parent = null;
        }
    }

    private void LateUpdate()
    {
        if (CameraAnchorPoint ==null)
        {
            return;
        }

        if (!localCamera.enabled)
        {
            return;
        }

        localCamera.transform.position = CameraAnchorPoint.position;

        cameraRotationX += viewInput.y * Time.deltaTime * networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);

        cameraRotationY += viewInput.x * Time.deltaTime * networkCharacterControllerPrototypeCustom.rotationSpeed;

        localCamera.transform.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0);

    }

    public void SetViewInputVector(Vector2 _viewInput)
    {
        viewInput = _viewInput;
    }
}
