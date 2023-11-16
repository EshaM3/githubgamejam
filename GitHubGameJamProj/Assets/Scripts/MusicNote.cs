using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    public int note;
    public Material[] noteMats;
    public AudioClip[] noteSfx;
    Material[] mats;
    float rotateSpeed = 20f;
    public bool shouldRotate = true;

    // Start is called before the first frame update
    void Start()
    {
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    public void UpdateColor(){
        mats = GetComponent<MeshRenderer>().sharedMaterials;
        mats[0] = noteMats[note];
        GetComponent<MeshRenderer>().materials = mats;
    }

    public void changeNote(int newNote)
    {
        note = newNote;
        UpdateColor();
    }
}
