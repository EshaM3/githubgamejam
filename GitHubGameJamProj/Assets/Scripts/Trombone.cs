using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trombone : MonoBehaviour
{
    public Material[] tromboneMats;
    public Material[] currentTromboneMats;
    public AudioClip[] tromboneSfx;
    public GameObject tromboneCollider;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;

    float xPos0 = -0.00426f;
    float xPos7 = -0.01438f;

    float xScale0 = 0.011017f;
    float xScale7 = 0.03237786f;

    float gap;
    float scaleGap;

    SkinnedMeshRenderer skinnedMesh;
    float targetBlend = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //tromboneCollider = GetComponent<BoxCollider>();
        currentTromboneMats = GetComponent<SkinnedMeshRenderer>().sharedMaterials;
        gap = xPos7 - xPos0;
        scaleGap = xScale7 - xScale0;
        UpdateColor();
    }

    void Update()
    {
        AnimateSlide();
    }

    public void AnimateSlide(){
        if (skinnedMesh == null){
            skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        }

        float currentBlend = skinnedMesh.GetBlendShapeWeight(0);
        float offset = 200f*Time.deltaTime;
        if (currentBlend > targetBlend + offset){
            currentBlend -= offset;
        } else if (currentBlend < targetBlend - offset){
            currentBlend += offset;
        }
        skinnedMesh.SetBlendShapeWeight(0, currentBlend);
    }

    public void UpdateColor(){
        tromboneCollider.transform.localPosition = new Vector3(xPos0 + (gap * (containedMusicNoteValue / 7f)),
            tromboneCollider.transform.localPosition.y, tromboneCollider.transform.localPosition.z);
        tromboneCollider.transform.localScale = new Vector3(xScale0 + (scaleGap * (containedMusicNoteValue / 7f)),
            tromboneCollider.transform.localScale.y, tromboneCollider.transform.localScale.z);

        targetBlend = 100f * containedMusicNoteValue / 7f;
        AnimateSlide();

        currentTromboneMats[1] = tromboneMats[containedMusicNoteValue];
        skinnedMesh.materials = currentTromboneMats;
    }

    public void PopOutAndStore(int newNote)
    {
        //if (containedMusicNoteValue != -1)
        //{

        //    var poppedOutMusicNote = Instantiate(containedMusicNote);
        //    poppedOutMusicNote.transform.position = playerTransform.position - playerTransform.forward + playerTransform.up;
        //    poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        //}
        containedMusicNoteValue = newNote;
        PlaySfx();
        UpdateColor();
    }

    public void PlaySfx(){
        GetComponent<AudioSource>().PlayOneShot(tromboneSfx[containedMusicNoteValue], MusicPlayer.SFX_Volume);
    }

}
