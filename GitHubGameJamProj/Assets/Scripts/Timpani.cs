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
    public int containedMusicNoteValue = -1;

    private void Start()
    {
        currentTimpaniMats = GetComponent<SkinnedMeshRenderer>().materials;
    }

    public void PopOutAndStore(int newNote)
    {
        if(containedMusicNoteValue != -1)
        {
            var poppedOutMusicNote = Instantiate(containedMusicNote);
            poppedOutMusicNote.transform.position = transform.position - transform.right + transform.forward;
            poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        }
        containedMusicNoteValue = newNote;
    }
}
