using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Timpani))]
public class TimpaniHelper : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        Timpani instrument = (Timpani)target;
        instrument.UpdateColor();
    }
}
