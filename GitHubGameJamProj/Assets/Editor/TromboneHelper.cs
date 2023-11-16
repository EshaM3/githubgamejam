using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Trombone))]
public class TromboneHelper : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        Trombone instrument = (Trombone)target;
        instrument.UpdateColor();
    }
}
