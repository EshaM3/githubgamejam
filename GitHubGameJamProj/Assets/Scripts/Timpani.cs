using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timpani : MonoBehaviour
{
    //these values will change based on music note brought to it
    public Material[] timpaniMats;
    public Material[] currentTimpaniMats;
    public AudioClip[] timpaniSfx;
    public float timpaniForce;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;

    SkinnedMeshRenderer skinnedMesh;
    float bounceAmp = 0f;
    bool bounceDir = true;

    private void Start()
    {
        skinnedMesh = GetComponent<SkinnedMeshRenderer>();
    }

    private void Update(){
        AnimateBounce();
    }

    public void UpdateColor(){
        currentTimpaniMats = GetComponent<SkinnedMeshRenderer>().sharedMaterials;
        currentTimpaniMats[0] = timpaniMats[containedMusicNoteValue];
        if (skinnedMesh == null){
            skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        }
        skinnedMesh.materials = currentTimpaniMats;

        //changes timpani bounce "force" based on note
        timpaniForce = (containedMusicNoteValue + 1) * 0.5f;
    }

    public void AnimateBounce(){
        float offset = 600f*Time.deltaTime;

        //Debug.Log("Bouncing Status - AMP: " + bounceAmp + ", DIR: " + bounceDir + ", BLEND0: " + skinnedMesh.GetBlendShapeWeight(0) + ", BLEND1: " + skinnedMesh.GetBlendShapeWeight(1));

        if (bounceAmp < 5f){
            bounceAmp = 0f;
            skinnedMesh.SetBlendShapeWeight(0,0f);
            skinnedMesh.SetBlendShapeWeight(1,0f);
        } else {
            if (bounceDir){
                if (skinnedMesh.GetBlendShapeWeight(1) > 0f){
                    skinnedMesh.SetBlendShapeWeight(1,skinnedMesh.GetBlendShapeWeight(1)-offset);
                } else if (skinnedMesh.GetBlendShapeWeight(0) > bounceAmp) {
                    bounceAmp *= 0.5f;
                    bounceDir = !bounceDir;
                } else {
                    skinnedMesh.SetBlendShapeWeight(0,skinnedMesh.GetBlendShapeWeight(0)+offset);
                }
            } else {
                if (skinnedMesh.GetBlendShapeWeight(0) > 0f){
                    skinnedMesh.SetBlendShapeWeight(0,skinnedMesh.GetBlendShapeWeight(0)-offset);
                } else if (skinnedMesh.GetBlendShapeWeight(1) > bounceAmp) {
                    bounceAmp *= 0.5f;
                    bounceDir = !bounceDir;
                } else {
                    skinnedMesh.SetBlendShapeWeight(1,skinnedMesh.GetBlendShapeWeight(1)+offset);
                }
            }
        }
    }

    public void PopOutAndStore(int newNote)
    {
        //if(containedMusicNoteValue != -1)
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
        GetComponent<AudioSource>().PlayOneShot(timpaniSfx[containedMusicNoteValue],MusicPlayer.SFX_Volume);
    }

    public float StartBounce(){
        PlaySfx();
        bounceDir = true;
        bounceAmp = 100f * (containedMusicNoteValue+1f) / 8f;
        return Mathf.Sqrt(timpaniForce * 30f);
    }
}
