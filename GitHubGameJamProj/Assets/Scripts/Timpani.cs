using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timpani : MonoBehaviour
{
    //these values will change based on music note brought to it
    public Material[] timpaniMats;
    public Material[] currentTimpaniMats;
    public float timpaniForce;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;

    private void Start()
    {
    }

    private void Update(){
        UpdateColor();
    }

    public void UpdateColor(){
        currentTimpaniMats = GetComponent<SkinnedMeshRenderer>().sharedMaterials;
        currentTimpaniMats[0] = timpaniMats[containedMusicNoteValue];
        GetComponent<SkinnedMeshRenderer>().materials = currentTimpaniMats;

        //changes timpani bounce "force" based on note
        timpaniForce = (containedMusicNoteValue + 1) * 0.5f;
    }

    public void PopOutAndStore(int newNote)
    {
        /*if(containedMusicNoteValue != -1)
        {
            var poppedOutMusicNote = Instantiate(containedMusicNote);
            poppedOutMusicNote.transform.position = transform.position - transform.right + transform.forward;
            poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        }*/
        containedMusicNoteValue = newNote;
    }
}
