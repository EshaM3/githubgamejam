using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Harp))]
public class HarpHelper : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        Harp instrument = (Harp)target;
        instrument.UpdateColor();
    }
}
