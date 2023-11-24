using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harp : MonoBehaviour
{
    public Material[] harpMats;
    public Material[] currentHarpMats;
    public AudioClip[] harpSfx;
    public float bounceForce;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;

    SkinnedMeshRenderer skinnedMesh;
    float bounceAmp = 0f;
    bool bounceDir = true;
    // Start is called before the first frame update
    void Start()
    {
        skinnedMesh = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateBounce();
        UpdateColor();
    }

    public void UpdateColor(){
        if (skinnedMesh == null){
            skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        }
        currentHarpMats = skinnedMesh.sharedMaterials;
        currentHarpMats[1] = harpMats[containedMusicNoteValue];
        skinnedMesh.materials = currentHarpMats;

        transform.rotation = Quaternion.Euler(-90f, containedMusicNoteValue*90f/7f, 0f);
    }

    public void AnimateBounce(){
        float offset = 800f*Time.deltaTime;

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
        GetComponent<AudioSource>().PlayOneShot(harpSfx[containedMusicNoteValue],MusicPlayer.SFX_Volume);
    }

    public Vector3 StartBounce(Vector3 direction){
        PlaySfx();
        Debug.Log(direction.normalized + " ===== " + transform.up + " ===== " + Vector3.Angle(direction,transform.up));
        if (Vector3.Angle(direction,transform.up) < 90f){
            bounceDir = false;
        } else {
            bounceDir = true;
        }
        bounceAmp = 100f;
        return Mathf.Sqrt(bounceForce * 30f)*direction.normalized;
    }
}
