using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote : MonoBehaviour
{
    public int note;
    public Material[] noteMats;
    // Start is called before the first frame update
    void Start()
    {
        Material[] mats = GetComponent<MeshRenderer>().materials;
        mats[0] = noteMats[note];
        GetComponent<MeshRenderer>().materials = mats;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
