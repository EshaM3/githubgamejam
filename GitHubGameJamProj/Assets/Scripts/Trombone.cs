using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombone : MonoBehaviour
{
    public BoxCollider tromboneCollider;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = -1;

    // Start is called before the first frame update
    void Start()
    {
        tromboneCollider = GetComponent<BoxCollider>();
    }

    public void PopOutAndStore(int newNote)
    {
        if (containedMusicNoteValue != -1)
        {
            var poppedOutMusicNote = Instantiate(containedMusicNote);
            poppedOutMusicNote.transform.position = transform.position + (transform.right*2) + transform.forward;
            poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        }
        containedMusicNoteValue = newNote;
    }

}
