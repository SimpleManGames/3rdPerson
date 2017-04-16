using System;
using UnityEngine;

[Serializable]
public struct CameraSettings
{
    public bool lockCursor;

    public float sensitivity;

    public float distance;

    public Vector2 pitchMinMax;
    public Vector2 scrollMinMax;

    public float rotationSmoothTime;


    public void ActOnSettings()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void AdjustDistance(float zoomAmount)
    {
        distance += zoomAmount;
        distance = Mathf.Clamp(distance, scrollMinMax.x, scrollMinMax.y);
    }

    public void SetDefaultValues()
    {
        sensitivity = 10f;
        distance = 2f;
        pitchMinMax = new Vector2(-40, 80);
        scrollMinMax = new Vector2(.5f, 5.0f);
        rotationSmoothTime = .12f;
    }
}
