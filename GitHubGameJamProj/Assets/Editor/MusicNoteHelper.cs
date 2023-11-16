using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MusicNote))]
public class MusicNoteHelper : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        MusicNote musicNote = (MusicNote)target;
        musicNote.UpdateColor();
    }
}
