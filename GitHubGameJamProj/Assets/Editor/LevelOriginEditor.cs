using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelBuilderScript))]
public class LevelOriginEditor : Editor
{
    
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        LevelBuilderScript levelData = (LevelBuilderScript)target;
        levelData.SpawnMusicBox();
    }

}
