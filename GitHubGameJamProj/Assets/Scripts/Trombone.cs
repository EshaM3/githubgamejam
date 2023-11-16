using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombone : MonoBehaviour
{
    public Material[] tromboneMats;
    public Material[] currentTromboneMats;
    public GameObject tromboneCollider;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        //tromboneCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
    }

    public void UpdateColor(){
        currentTromboneMats = GetComponent<SkinnedMeshRenderer>().sharedMaterials;

        float xPos0 = -0.00426f;
        float xPos7 = -0.01438f;
        
        float xScale0 = 0.011017f;
        float xScale7 = 0.03237786f;

        float gap = xPos7-xPos0;
        float scaleGap = xScale7-xScale0;

        tromboneCollider.transform.localPosition = new Vector3(xPos0 + (gap*(containedMusicNoteValue/7f)),
            tromboneCollider.transform.localPosition.y, tromboneCollider.transform.localPosition.z);
        tromboneCollider.transform.localScale = new Vector3(xScale0 + (scaleGap*(containedMusicNoteValue/7f)),
            tromboneCollider.transform.localScale.y, tromboneCollider.transform.localScale.z);

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 100f*containedMusicNoteValue/7f);
        currentTromboneMats[1] = tromboneMats[containedMusicNoteValue];
        GetComponent<SkinnedMeshRenderer>().materials = currentTromboneMats;
    }

    public void PopOutAndStore(int newNote)
    {
        /*if (containedMusicNoteValue != -1)
        {
            var poppedOutMusicNote = Instantiate(containedMusicNote);
            poppedOutMusicNote.transform.position = transform.position + (transform.right*2) + transform.forward;
            poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        }*/
        containedMusicNoteValue = newNote;
    }

}
