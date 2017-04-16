using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private PlayerController playerController;

    private float yaw;
    private float pitch;

    private Vector3 rotationSmoothVelocity;
    private Vector3 currentRotation;

    public CameraSettings settings;

    void Start()
    {
        if (target.GetComponentInParent<PlayerController>())
            playerController = target.GetComponentInParent<PlayerController>();
        else
            Debug.LogError("Target's Parent needs to have a PlayerController component" + target.parent.name);

        settings.ActOnSettings();

        playerController.cameraTransform = transform;
    }

    void Update()
    {
        List<GameObject> newList = TargetSystemManager.Instance.GetObjectsScreenByCamera(GetComponent<Camera>());
    }

    void LateUpdate()
    {
        yaw += playerController.input.LookDirection.x * settings.sensitivity;
        pitch -= playerController.input.LookDirection.y * settings.sensitivity;
        pitch = Mathf.Clamp(pitch, settings.pitchMinMax.x, settings.pitchMinMax.y);

        settings.AdjustDistance(playerController.input.ZoomLevel);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, settings.rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * settings.distance;
    }
}
