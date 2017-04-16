using System;
using UnityEngine;

[Serializable]
public struct PlayerSettings
{
    public float walkSpeed;
    public float runSpeed;

    public float gravity;
    public float jumpHeight;

    [Range(0, 1)]
    public float airControlPercent;

    public float turnSmoothTime;
    public float speedSmoothTime;

    public void SetDefaultValues()
    {
        walkSpeed = 2f;
        runSpeed = 6f;
        gravity = -12f;
        jumpHeight = 1;

        turnSmoothTime = 0.2f;
        speedSmoothTime = 0.1f;
    }
}
