using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraController))]
public class CameraControllerEditor : Editor
{
    private CameraController cameraController;

    void OnEnable()
    {
        cameraController = (CameraController)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Set Default Values"))
            cameraController.settings.SetDefaultValues();

    }
}
