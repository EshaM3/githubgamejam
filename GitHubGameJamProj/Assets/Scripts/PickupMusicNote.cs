using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMusicNote : MonoBehaviour
{
    public int currentNote = -1;
    public GameObject musicNotePrefab;
    public GameObject heldNote;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNote >= 0){
            heldNote.SetActive(true);
            Material[] mats = heldNote.GetComponent<MeshRenderer>().materials;
            mats[0] = musicNotePrefab.GetComponent<MusicNote>().noteMats[currentNote];
            heldNote.GetComponent<MeshRenderer>().materials = mats;
        } else {
            heldNote.SetActive(false);
        }
    }

    public void CollideWithNote(MusicNote note){
        if (currentNote >= 0){
             SummonMusicNote(currentNote);
        }
        currentNote = note.note;
        Destroy(note.gameObject);
    }

    private void SummonMusicNote(int notePitch){
        GameObject go = Instantiate<GameObject>(musicNotePrefab);
        go.transform.position = transform.position - transform.forward + transform.up;
        go.GetComponent<MusicNote>().note = notePitch;
    }
}
