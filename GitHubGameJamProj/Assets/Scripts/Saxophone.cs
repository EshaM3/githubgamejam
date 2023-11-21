using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saxophone : MonoBehaviour
{
    public GameObject raspberry;
    public Transform launchPoint;
    [SerializeField] float RaspberryLaunchHeight;
    public bool bearIsPresent;

    public Material[] saxophoneMats;
    public Material[] currentSaxophoneMats;
    public AudioClip[] saxophoneSfx;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;
    float amountRotated = 0f;
    public float verticalRotation;
    SkinnedMeshRenderer skinnedMesh;

    // Start is called before the first frame update
    void Start()
    {
        skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        StartCoroutine(spacedOut());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateColor(){
        currentSaxophoneMats = GetComponent<SkinnedMeshRenderer>().sharedMaterials;

        transform.rotation = Quaternion.identity;
        transform.RotateAround(transform.position, Vector3.right, -90f);
        transform.RotateAround(transform.position, Vector3.up, verticalRotation);

        float angle0 = -70f;
        float angle7 = 25f;

        //transform.RotateAround(transform.position, transform.up, -amountRotated);
        //amountRotated = -30 + (-12 * containedMusicNoteValue);
        amountRotated = angle0 + ((angle7-angle0) * containedMusicNoteValue/7f);
        transform.RotateAround(transform.position, transform.up, amountRotated);

        //transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -30 + (-12 * containedMusicNoteValue));


        //saxophone color changes based on note
        currentSaxophoneMats[1] = saxophoneMats[containedMusicNoteValue];
        if (skinnedMesh == null){
            skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        }
        skinnedMesh.materials = currentSaxophoneMats;
    }

    IEnumerator spacedOut()
    {
        if (skinnedMesh == null){
            skinnedMesh = GetComponent<SkinnedMeshRenderer>();
        }

        yield return new WaitForSeconds(0.2f);

        if (skinnedMesh.GetBlendShapeWeight(0) > 0f){
            skinnedMesh.SetBlendShapeWeight(0,67f);
        }
        yield return new WaitForSeconds(0.1f);

        skinnedMesh.SetBlendShapeWeight(0,0f);
        yield return new WaitForSeconds(1.2f);

        skinnedMesh.SetBlendShapeWeight(1,33f);
        yield return new WaitForSeconds(0.1f);

        skinnedMesh.SetBlendShapeWeight(1,100f);
        yield return new WaitForSeconds(0.3f);

        skinnedMesh.SetBlendShapeWeight(1,67f);
        skinnedMesh.SetBlendShapeWeight(0,33f);
        yield return new WaitForSeconds(0.1f);

        skinnedMesh.SetBlendShapeWeight(1,0f);
        skinnedMesh.SetBlendShapeWeight(0,100f);

        PlaySfx();
        var rasp = Instantiate(raspberry, launchPoint.position, raspberry.transform.rotation);
        /*rasp.gameObject.GetComponent<Rigidbody>().velocity = rasp.gameObject.GetComponent<Rigidbody>().velocity +
            transform.forward*RaspberryLaunchHeight*.5f - transform.right*RaspberryLaunchHeight*3;*/
        rasp.gameObject.GetComponent<Rigidbody>().velocity = launchPoint.transform.forward*RaspberryLaunchHeight*1.5f;
        rasp.GetComponent<RaspberryBounce>().creator = this;
        if (bearIsPresent == false)
        {
            StartCoroutine(spacedOut());
        }
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
        GetComponent<AudioSource>().PlayOneShot(saxophoneSfx[containedMusicNoteValue],MusicPlayer.SFX_Volume);
    }
}
