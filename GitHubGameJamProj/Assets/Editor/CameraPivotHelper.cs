using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraController))]
public class CameraPivotHelper : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        CameraController cam = (CameraController)target;
        cam.UpdateCamera();
    }
}
