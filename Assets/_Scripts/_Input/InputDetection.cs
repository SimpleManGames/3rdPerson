using UnityEngine;

public class InputDetection : MonoBehaviour
{
    public bool DebugInputValues = true;

    public Vector2 InputDirection
    {
        get
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    public Vector2 LookDirection
    {
        get
        {
            return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }

    public float ZoomLevel
    {
        get
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }
    }

    public bool RunInput
    {
        get
        {
            if (Input.GetAxisRaw("Run") != 0)
                return true;

            return false;
        }
    }

    void Update()
    {
        if (DebugInputValues)
        {
            Debug.Log("InputDirection: " + InputDirection + "/n" +
                      "LookDirection: " + LookDirection + "/n" +
                      "LookLevel" + ZoomLevel);
        }
    }
}
