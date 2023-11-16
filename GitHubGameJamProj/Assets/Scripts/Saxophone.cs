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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spacedOut());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColor();
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
        GetComponent<SkinnedMeshRenderer>().materials = currentSaxophoneMats;
    }

    IEnumerator spacedOut()
    {
        yield return new WaitForSeconds(2);
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
        /*if (containedMusicNoteValue != -1)
        {
            var poppedOutMusicNote = Instantiate(containedMusicNote);
            poppedOutMusicNote.transform.position = transform.position + (transform.right * 2) + transform.forward;
            poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        }*/
        containedMusicNoteValue = newNote;
        PlaySfx();
    }

    public void PlaySfx(){
        GetComponent<AudioSource>().PlayOneShot(saxophoneSfx[containedMusicNoteValue]);
    }
}
