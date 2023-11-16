using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Saxophone))]
public class SaxophoneHelper : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        Saxophone instrument = (Saxophone)target;
        instrument.UpdateColor();
    }
}
