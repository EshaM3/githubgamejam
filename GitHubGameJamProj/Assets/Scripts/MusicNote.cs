using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    public int note;
    public Material[] noteMats;
    Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<MeshRenderer>().materials;
        mats[0] = noteMats[note];
        GetComponent<MeshRenderer>().materials = mats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeNote(int newNote)
    {
        mats = GetComponent<MeshRenderer>().materials;
        mats[0] = noteMats[newNote];
        GetComponent<MeshRenderer>().materials = mats;

        note = newNote;
    }
}
