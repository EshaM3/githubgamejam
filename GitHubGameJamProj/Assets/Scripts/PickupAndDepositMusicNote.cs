using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndDepositMusicNote : MonoBehaviour
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
        //if (currentNote >= 0){
        //    heldNote.SetActive(true);
        //    heldNote.GetComponent<MusicNote>().changeNote(currentNote);
        ////    //Material[] mats = heldNote.GetComponent<MeshRenderer>().materials;
        ////    //mats[0] = musicNotePrefab.GetComponent<MusicNote>().noteMats[currentNote];
        ////    //heldNote.GetComponent<MeshRenderer>().materials = mats;
        ////} else {
        ////    heldNote.SetActive(false);
        //}
    }

    public void CollideWithNote(MusicNote takenNote){
        if (currentNote >= 0){
            SummonMusicNote(currentNote);
        }
        heldNote.SetActive(true);
        currentNote = takenNote.note;
        heldNote.GetComponent<MusicNote>().changeNote(currentNote);
        Destroy(takenNote.gameObject);
    }

    public void SummonMusicNote(int notePitch){
        GameObject go = Instantiate<GameObject>(musicNotePrefab);
        go.transform.position = transform.position - transform.forward + transform.up;
        go.GetComponent<MusicNote>().note = notePitch;
    }
}
